using OpenRP.GameMode.Data.Models;
using OpenRP.GameMode.Features.Accounts.Components;
using OpenRP.GameMode.Features.Accounts.Helpers;
using OpenRP.GameMode.Features.Characters.Components;
using OpenRP.GameMode.Features.Chat.Constants;
using OpenRP.GameMode.Helpers;
using SampSharp.Entities.SAMP;
using System;

namespace OpenRP.GameMode.Features.MainMenu.Dialogs
{
    public static class CreateCharacterLastNameDialog
    {
        public static void Open(Player player, IDialogService dialogService)
        {
            InputDialog characterDialog = new InputDialog();

            characterDialog.Caption = DialogHelper.GetTitle("Character Creation", "Last name");
            characterDialog.Content = ChatColor.White + "Pick a last name for your character. The first name of your character can be up to 35 characters long.";
            characterDialog.Button1 = DialogHelper.Next;
            characterDialog.Button2 = DialogHelper.Previous;

            void CreateCharacterLastNameDialogHandler(InputDialogResponse r)
            {
                if (r.Response == DialogResponse.LeftButton)
                {
                    CharacterCreationComponent charCreationComponent = player.GetComponent<CharacterCreationComponent>();

                    if (string.IsNullOrEmpty(r.InputText))
                    {
                        MessageDialog firstNameRequired = new MessageDialog(DialogHelper.GetTitle("Character Creation", "Last name"), ChatColor.White + "The last name for your character is required!", DialogHelper.Retry);

                        void LastNameRequiredDialogHandler(MessageDialogResponse r)
                        {
                            Open(player, dialogService);
                        };

                        dialogService.Show(player.Entity, firstNameRequired, LastNameRequiredDialogHandler);
                    }
                    else if (r.InputText.Length > 35)
                    {
                        MessageDialog lastNameTooLongDialog = new MessageDialog(DialogHelper.GetTitle("Character Creation", "Last name"), ChatColor.White + "The last name for your character may not be longer than 35 characters.", DialogHelper.Retry);
                        
                        void LastNameTooLongDialogHandler(MessageDialogResponse r)
                        {
                            Open(player, dialogService);
                        };

                        dialogService.Show(player.Entity, lastNameTooLongDialog, LastNameTooLongDialogHandler);
                    } else
                    {
                        charCreationComponent.CreatingCharacter.LastName = r.InputText.Trim();

                        CreateCharacterDateOfBirthDialog.Open(player, dialogService);
                    }
                }
                else
                {
                    CreateCharacterMiddleNameDialog.Open(player, dialogService);
                }
            }

            dialogService.Show(player.Entity, characterDialog, CreateCharacterLastNameDialogHandler);
        }
    }
}
