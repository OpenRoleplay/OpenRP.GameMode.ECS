using OpenRP.GameMode.Data.Models;
using OpenRP.GameMode.Definitions.Constants;
using OpenRP.GameMode.Features.Accounts.Components;
using OpenRP.GameMode.Features.Accounts.Helpers;
using OpenRP.GameMode.Features.Characters.Components;
using OpenRP.GameMode.Features.Characters.Helpers;
using OpenRP.GameMode.Features.Chat.Constants;
using SampSharp.Entities.SAMP;
using System;
using System.Globalization;

namespace OpenRP.GameMode.Features.MainMenu.Dialogs
{
    public static class CreateCharacterDateOfBirthDialog
    {
        public static void Open(Player player, IDialogService dialogService)
        {
            InputDialog characterDialog = new InputDialog();

            characterDialog.Caption = DialogConstants.Prefix + "Character Creation" + DialogConstants.Separator + "Date of Birth";
            characterDialog.Content = ChatColor.White + "Pick a date of birth for your character. The appropriate format to use is DD/MM/YYYY.";
            characterDialog.Button1 = DialogConstants.Next;
            characterDialog.Button2 = DialogConstants.Previous;

            void CreateCharacterDateOfBirthDialogHandler(InputDialogResponse r)
            {
                if (r.Response == DialogResponse.LeftButton)
                {
                    CharacterCreationComponent charCreationComponent = player.GetComponent<CharacterCreationComponent>();

                    DateTime characterDoB;
                    if (DateTime.TryParse(r.InputText, out characterDoB))
                    {
                        MessageDialog confirmDateOfBirth = new MessageDialog(DialogConstants.Prefix + "Character Creation" + DialogConstants.Separator + "Date of Birth", ChatColor.White + String.Format("Your chosen Date of Birth is {0}, meaning that your character would be {1} years old. Is that correct?", characterDoB.ToString("dd/MM/yyyy"), (DateTime.Today.Year - characterDoB.Year)), DialogConstants.Yes, DialogConstants.No);

                        void ConfirmDialogHandler(MessageDialogResponse confirmResponse)
                        {
                            if(confirmResponse.Response == DialogResponse.LeftButton)
                            {
                                charCreationComponent.CreatingCharacter.DateOfBirth = characterDoB;

                                // Next Step
                                CharacterHelper.CreateCharacter(player);
                                CharacterSelectionDialog.Open(player, dialogService);
                            } else
                            {
                                Open(player, dialogService);
                            }
                        };

                        dialogService.Show(player.Entity, confirmDateOfBirth, ConfirmDialogHandler);
                    }
                    else
                    {
                        MessageDialog incorrectFormatDialog = new MessageDialog(DialogConstants.Prefix + "Character Creation" + DialogConstants.Separator + "Date of Birth", ChatColor.White + "Your chosen format for the Date of Birth is incorrect, please try again.", DialogConstants.Retry);
                        
                        void IncorrectFormatDialogHandler(MessageDialogResponse r)
                        {
                            Open(player, dialogService);
                        };

                        dialogService.Show(player.Entity, incorrectFormatDialog, IncorrectFormatDialogHandler);
                    }
                }
                else
                {
                    CreateCharacterLastNameDialog.Open(player, dialogService);
                }
            }

            dialogService.Show(player.Entity, characterDialog, CreateCharacterDateOfBirthDialogHandler);
        }
    }
}
