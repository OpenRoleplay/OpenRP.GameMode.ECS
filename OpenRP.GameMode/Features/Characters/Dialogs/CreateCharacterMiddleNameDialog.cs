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
    public static class CreateCharacterMiddleNameDialog
    {
        public static void Open(Player player, IDialogService dialogService)
        {
            MessageDialog middleNameYesOrNoDialog = new MessageDialog(DialogHelper.GetTitle("Character Creation", "Middle name"), ChatColor.White + "Would you like to set a middle name for your character? This is not required.", DialogHelper.Yes, DialogHelper.No);

            void MiddleNameYesOrNoDialogHandler(MessageDialogResponse r)
            {
                if(r.Response == DialogResponse.LeftButton)
                {
                    InputDialog characterDialog = new InputDialog();

                    characterDialog.Caption = DialogHelper.GetTitle("Character Creation", "Middle name");
                    characterDialog.Content = ChatColor.White + "Pick a middle name for your character. The middle name of your character can be up to 30 characters long. You can also skip this step by not filling a middle name in.";
                    characterDialog.Button1 = DialogHelper.Next;
                    characterDialog.Button2 = DialogHelper.Previous;

                    void CreateCharacterMiddleNameDialogHandler(InputDialogResponse r)
                    {
                        if (r.Response == DialogResponse.LeftButton)
                        {
                            CharacterCreationComponent charCreationComponent = player.GetComponent<CharacterCreationComponent>();

                            if (String.IsNullOrEmpty(r.InputText))
                            {
                                charCreationComponent.CreatingCharacter.MiddleName = null;

                                CreateCharacterLastNameDialog.Open(player, dialogService);
                            }
                            else if (r.InputText.Length > 30)
                            {
                                MessageDialog middleNameTooLongDialog = new MessageDialog(DialogHelper.GetTitle("Character Creation", "Middle name"), ChatColor.White + "The middle name for your character may not be longer than 30 characters.", DialogHelper.Retry);

                                void MiddleNameTooLongDialogHandler(MessageDialogResponse r)
                                {
                                    Open(player, dialogService);
                                };

                                dialogService.Show(player.Entity, middleNameTooLongDialog, MiddleNameTooLongDialogHandler);
                            }
                            else
                            {
                                charCreationComponent.CreatingCharacter.MiddleName = r.InputText.Trim();

                                CreateCharacterLastNameDialog.Open(player, dialogService);
                            }
                        }
                        else
                        {
                            CreateCharacterFirstNameDialog.Open(player, dialogService);
                        }
                    }

                    dialogService.Show(player.Entity, characterDialog, CreateCharacterMiddleNameDialogHandler);
                } else
                {
                    CreateCharacterLastNameDialog.Open(player, dialogService);
                }
            };

            dialogService.Show(player.Entity, middleNameYesOrNoDialog, MiddleNameYesOrNoDialogHandler);
        }
    }
}
