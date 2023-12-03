using OpenRP.GameMode.Data.Models;
using OpenRP.GameMode.Features.Accounts.Components;
using OpenRP.GameMode.Features.Chat.Constants;
using OpenRP.GameMode.Features.Chat.Enums;
using OpenRP.GameMode.Features.Chat.Helpers;
using OpenRP.GameMode.Helpers;
using SampSharp.Entities.SAMP;
using System;
using System.Linq;

namespace OpenRP.GameMode.Features.MainMenu.Dialogs
{
    public static class CharacterSelectionDialog
    {
        public static void Open(Player player, IDialogService dialogService)
        {
            ListDialog choiceDialog = new ListDialog(DialogHelper.GetTitle("Character Selection"), DialogHelper.Next, DialogHelper.Quit);

            AccountComponent accountComponent = player.GetComponent<AccountComponent>();

            player.DestroyComponents<CharacterComponent>();
            CharacterComponent characterComponent = player.AddComponent<CharacterComponent>();

            void CharacterSelectionDialogHandler(ListDialogResponse r)
            {
                if (r.Response == DialogResponse.LeftButton)
                {
                    if (r.ItemIndex == accountComponent?.Account?.Characters?.Count)
                    {
                        CreateCharacterFirstNameDialog.Open(player, dialogService);
                    }
                    else {
                        characterComponent.CharacterPlayingAs = accountComponent.Account.Characters.ElementAt(r.ItemIndex);
                        player.SendPlayerInfoMessage(PlayerInfoMessageType.INFO, String.Format("Logged in as {0}{1} {2}{3}!", ChatColor.CornflowerBlue, characterComponent.CharacterPlayingAs.FirstName, characterComponent.CharacterPlayingAs.LastName, ChatColor.White));
                        // player.OnCharacterSelected();

                        // Temporary for testing
                        player.ToggleSpectating(false);
                        player.ToggleControllable(true);
                        player.SetSpawnInfo(0, characterComponent.CharacterPlayingAs.Skin, new Vector3(2273.5562, 82.3747, 26.4844), 358);
                        player.Name = String.Format("{0}_{1}", characterComponent.CharacterPlayingAs.FirstName, characterComponent.CharacterPlayingAs.LastName);
                        player.Spawn();
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
