using OpenRP.GameMode.Data.Models;
using OpenRP.GameMode.Definitions.Constants;
using OpenRP.GameMode.Features.Accounts.Components;
using OpenRP.GameMode.Features.Chat.Constants;
using OpenRP.GameMode.Features.Chat.Enums;
using OpenRP.GameMode.Features.Chat.Helpers;
using SampSharp.Entities.SAMP;
using System;
using System.Linq;

namespace OpenRP.GameMode.Features.MainMenu.Dialogs
{
    public static class CharacterSelectionDialog
    {
        public static void Open(Player player, IDialogService dialogService)
        {
            ListDialog choiceDialog = new ListDialog(ChatColor.White + "Character Selection", DialogConstants.Next, DialogConstants.Quit);

            AccountComponent accountComponent = player.GetComponent<AccountComponent>();

            player.DestroyComponents<CharacterComponent>();
            CharacterComponent characterComponent = player.AddComponent<CharacterComponent>();

            void CharacterSelectionDialogHandler(ListDialogResponse r)
            {
                if (r.Response == DialogResponse.LeftButton)
                {
                    if (r.ItemIndex == accountComponent?.Account?.Characters?.Count)
                    {               
                        //player.main_account.create_character = new Character();
                        //player.main_account.create_character.character_account_id = player.main_account.account_id;

                        //OpenCreateCharacterStep1(player);
                    }
                    else {
                        characterComponent.CharacterPlayingAs = accountComponent.Account.Characters.ElementAt(r.ItemIndex);
                        player.SendPlayerInfoMessage(PlayerInfoMessageType.INFO, String.Format("Logged in as {0}{1} {2}{3}!", ChatColor.CornflowerBlue, characterComponent.CharacterPlayingAs.FirstName, characterComponent.CharacterPlayingAs.LastName, ChatColor.White));
                        // player.OnCharacterSelected();
                    }
                }
                else
                {
                    player.Kick();
                }
            }

            if(accountComponent?.Account?.Characters != null)
            {
                foreach(Character character in accountComponent.Account.Characters)
                {
                    choiceDialog.Add(String.Format("{0}{1} {2}", ChatColor.CornflowerBlue, character.FirstName, character.LastName));
                }
            }

            choiceDialog.Add(ChatColor.White + "Create a new character");

            dialogService.Show(player.Entity, choiceDialog, CharacterSelectionDialogHandler);
        }
    }
}
