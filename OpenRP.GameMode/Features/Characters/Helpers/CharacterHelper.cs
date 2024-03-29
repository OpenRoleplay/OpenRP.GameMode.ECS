﻿using Dapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using OpenRP.GameMode.Configuration;
using OpenRP.GameMode.Data;
using OpenRP.GameMode.Data.Models;
using OpenRP.GameMode.Features.Accounts.Components;
using OpenRP.GameMode.Features.Characters.Components;
using OpenRP.GameMode.Features.Inventories.Helpers;
using OpenRP.GameMode.Features.MainMenu.Dialogs;
using Org.BouncyCastle.Asn1.Mozilla;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace OpenRP.GameMode.Features.Characters.Helpers
{
    public static class CharacterHelper
    {
        public static List<Character> LoadCharacters(string username)
        {
            MySqlConnection sqlConnection = new MySqlConnection(ConfigManager.Instance.Data.ConnectionString);
            sqlConnection.Open();

            List<Character> characters = sqlConnection.Query<Character>("SELECT * FROM characters AS c JOIN accounts AS a ON a.Id = c.AccountId WHERE a.Username = @username", new { username }).ToList();

            sqlConnection.Close();

            return characters;
        }

        public static bool CreateCharacter(Player player)
        {
            try
            {
                CharacterCreationComponent charCreationComponent = player.GetComponent<CharacterCreationComponent>();
                AccountComponent accountComponent = player.GetComponent<AccountComponent>();

                if (charCreationComponent != null && charCreationComponent.CreatingCharacter != null)
                {
                    MySqlConnection sqlConnecton = new MySqlConnection(ConfigManager.Instance.Data.ConnectionString);
                    sqlConnecton.Open();

                    MySqlCommand query = new MySqlCommand(@"INSERT INTO characters (FirstName, MiddleName, LastName, DateOfBirth, Accent, InventoryId, AccountId) VALUES (@FirstName, @MiddleName, @LastName, @DateOfBirth, @Accent, @InventoryId, @AccountId)", sqlConnecton);

                    query.Parameters.AddWithValue("@FirstName", charCreationComponent.CreatingCharacter.FirstName);
                    query.Parameters.AddWithValue("@MiddleName", charCreationComponent.CreatingCharacter.MiddleName);
                    query.Parameters.AddWithValue("@LastName", charCreationComponent.CreatingCharacter.LastName);
                    query.Parameters.AddWithValue("@DateOfBirth", charCreationComponent.CreatingCharacter.DateOfBirth);
                    query.Parameters.AddWithValue("@Accent", null);
                    query.Parameters.AddWithValue("@InventoryId", null);
                    query.Parameters.AddWithValue("@AccountId", accountComponent.Account.Id);
                    query.ExecuteNonQuery();

                    sqlConnecton.Close();

                    player.DestroyComponents<CharacterCreationComponent>();

                    accountComponent.Account.Characters = CharacterHelper.LoadCharacters(accountComponent.Account.Username);
                    return true;
                } else
                {
                    Console.WriteLine("There is no character to create!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static Inventory GetCharacterInventory(this Character character)
        {
            using (var context = new DataContext())
            {
                Character characterData = context.Characters
                    .Include(c => c.Inventory)
                    .ThenInclude(c => c.Items)
                    .FirstOrDefault(c => c.Id == character.Id);

                if (characterData.Inventory == null)
                {
                    characterData.Inventory = InventoryHelper.CreateInventory("Character Inventory", 10000);
                }
                context.SaveChanges();
                return characterData.Inventory;
            }
        }

        public static string GetCharacterName(this Character character)
        {
            return String.Format("{0} {1}", character.FirstName, character.LastName);
        }

        public static Player GetCharacterPlayer(this Character character, IEntityManager entityManager)
        {
            foreach (Player player in entityManager.GetComponents<Player>().Where(p => p.GetComponent<CharacterComponent>()?.CharacterPlayingAs?.Id == character.Id))
            {
                return player;
            }
            return null;
        }

        public static List<InventoryItem> GetCharacterInventorySkins(this Character character)
        {
            return character.GetCharacterInventory().GetInventoryItems().Where(i => i.GetItem().IsItemSkin()).ToList();
        }

        public static bool SetCharacterWearingInventorySkin(this Character character, InventoryItem inventoryItem, IEntityManager entityManager)
        {
            try
            {
                using (var context = new DataContext())
                {
                    foreach (InventoryItem skin in character.GetCharacterInventorySkins())
                    {
                        ItemAdditionalData itemAdditionalData = ItemAdditionalData.Parse(skin.AdditionalData);

                        if (itemAdditionalData.GetBoolean("WEARING") != null && itemAdditionalData.GetBoolean("WEARING") == true)
                        {
                            itemAdditionalData.SetBoolean("WEARING", false);

                            InventoryItem inventoryItemToUpdate = context.InventoryItems.Find(skin.Id);
                            inventoryItemToUpdate.AdditionalData = itemAdditionalData.ToString();
                        }
                    }

                    ItemAdditionalData itemAdditionalDataNewSkin = ItemAdditionalData.Parse(inventoryItem.AdditionalData);

                    itemAdditionalDataNewSkin.SetBoolean("WEARING", true);

                    InventoryItem inventoryItemToUpdateNewSkin = context.InventoryItems.Find(inventoryItem.Id);
                    inventoryItemToUpdateNewSkin.AdditionalData = itemAdditionalDataNewSkin.ToString();

                    int? newSkin = itemAdditionalDataNewSkin.GetInt("SKIN");
                    if (newSkin != null)
                    {
                        Character characterToUpdate = context.Characters.Find(character.Id);
                        characterToUpdate.Skin = character.GetCharacterPlayer(entityManager).Skin = newSkin.Value;

                        context.SaveChanges();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
    }
}
