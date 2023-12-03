using MySql.Data.MySqlClient;
using OpenRP.GameMode.Configuration;
using OpenRP.GameMode.Data;
using OpenRP.GameMode.Data.Models;
using SampSharp.Entities.SAMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenRP.GameMode.Features.Inventories.Helpers
{
    public static class InventoryHelper
    {
        public static Inventory CreateInventory(string inventoryName, uint? maxWeightInGrams)
        {
            try
            {
                using (var context = new DataContext())
                {
                    Inventory newInventory = new Inventory() { Name =  inventoryName, MaxWeight = maxWeightInGrams };
                    context.Inventories.Add(newInventory);
                    context.SaveChanges();

                    return newInventory;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static List<InventoryItem> GetInventoryItems(this Inventory inventory)
        {
            using (var context = new DataContext())
            {
                return context.Inventories.Find(inventory.Id).Items;
            }
        }

        public static void OpenDialog(this Inventory inventory, Player for_player)
        {
            //for_player.openedInventoryItems = inventory.GetInventoryItems();

            //this.OpenInventoryItemsDialog(for_player, for_player.openedInventoryItems, args);
        }
    }
}
