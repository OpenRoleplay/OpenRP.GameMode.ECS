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
    public static class CreateCharacterFirstNameDialog
    {
        public static void Open(Player player, IDialogService dialogService)
        {
            InputDialog characterDialog = new InputDialog();

            characterDialog.Caption = DialogHelper.GetTitle("Character Creation", "First name");
            characterDialog.Content = ChatColor.White + "Pick a first name for your character. The first name of your character can be up to 35 characters long.";
            characterDialog.Button1 = DialogHelper.Next;
            characterDialog.Button2 = DialogHelper.Previous;

            void CreateCharacterFirstNameDialogHandler(InputDialogResponse r)
            {
                if (r.Response == DialogResponse.LeftButton)
                {
                    player.DestroyComponents<CharacterCreationComponent>();
                    CharacterCreationComponent charCreationComponent = player.AddComponent<CharacterCreationComponent>();

                    if (string.IsNullOrEmpty(r.InputText))
                    {
                        MessageDialog firstNameRequired = new MessageDialog(DialogHelper.GetTitle("Character Creation", "First name"), ChatColor.White + "The first name for your character is required!", DialogHelper.Retry);

                        void FirstNameRequiredDialogHandler(MessageDialogResponse r)
                        {
                            Open(player, dialogService);
                        };

                        dialogService.Show(player.Entity, firstNameRequired, FirstNameRequiredDialogHandler);
                    }
                    else if (r.InputText.Length > 35)
                    {
                        MessageDialog firstNameTooLongDialog = new MessageDialog(DialogHelper.GetTitle("Character Creation", "First name"), ChatColor.White + "The first name for your character may not be longer than 35 characters.", DialogHelper.Retry);
                        
                        void FirstNameTooLongDialogHandler(MessageDialogResponse r)
                        {
                            Open(player, dialogService);
                        };

                        dialogService.Show(player.Entity, firstNameTooLongDialog, FirstNameTooLongDialogHandler);
                    } else
                    {
                        charCreationComponent.CreatingCharacter.FirstName = r.InputText.Trim();

                        CreateCharacterMiddleNameDialog.Open(player, dialogService);
                    }
                }
                else
                {
                    MainMenuDialog.Open(player, dialogService);
                }
            }

            dialogService.Show(player.Entity, characterDialog, CreateCharacterFirstNameDialogHandler);
        }
    }
}
