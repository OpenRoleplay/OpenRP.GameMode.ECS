using OpenRP.GameMode.Data.Models;
using OpenRP.GameMode.Definitions.Constants;
using OpenRP.GameMode.Features.Accounts.Components;
using OpenRP.GameMode.Features.Accounts.Helpers;
using OpenRP.GameMode.Features.Chat.Constants;
using SampSharp.Entities.SAMP;

namespace OpenRP.GameMode.Features.MainMenu.Dialogs
{
    public static class RegisterStepOneDialog
    {
        public static void Open(Player player, IDialogService dialogService)
        {
            InputDialog registerDialog = new InputDialog();

            registerDialog.Caption = DialogConstants.Prefix + "Registration" + DialogConstants.Separator + "Username";
            registerDialog.Content = ChatColor.White + "What would you like your username to be?";
            registerDialog.Button1 = DialogConstants.Next;
            registerDialog.Button2 = DialogConstants.Previous;

            void StepOneDialogHandler(InputDialogResponse r)
            {
                if (r.Response == DialogResponse.LeftButton)
                {
                    if (r.InputText.Length < 3)
                    {
                        MessageDialog usernameLongerThanThreeCharactersDialog = new MessageDialog(DialogConstants.Prefix + "Registration" + DialogConstants.Separator + "Username", ChatColor.White + "Your username must be longer than 3 characters.", DialogConstants.Retry);
                        
                        void UsernameLongerThanThreeCharactersDialogHandler(MessageDialogResponse r)
                        {
                            Open(player, dialogService);
                        };

                        dialogService.Show(player.Entity, usernameLongerThanThreeCharactersDialog, UsernameLongerThanThreeCharactersDialogHandler);
                    }

                    if (r.InputText.Length > 24)
                    {
                        MessageDialog usernameNoLongerThanTwentyFourCharactersDialog = new MessageDialog(DialogConstants.Prefix + "Registration" + DialogConstants.Separator + "Username", ChatColor.White + "Your username can not be longer than 24 characters.", DialogConstants.Retry);

                        void UsernameNoLongerThanTwentyFourCharactersDialogHandler(MessageDialogResponse r)
                        {
                            Open(player, dialogService);
                        };

                        dialogService.Show(player.Entity, usernameNoLongerThanTwentyFourCharactersDialog, UsernameNoLongerThanTwentyFourCharactersDialogHandler);
                    }

                    if (AccountHelper.DoesAccountExist(r.InputText))
                    {
                        UsernameAlreadyExistsDialog.Open(player, dialogService);
                    }
                    else
                    {
                        player.DestroyComponents<AccountComponent>();
                        AccountComponent accountComponent = player.AddComponent<AccountComponent>();

                        accountComponent.Account = new Account();
                        accountComponent.Account.Username = r.InputText;

                        MessageDialog usernameSet = new MessageDialog(DialogConstants.Prefix + "Registration" + DialogConstants.Separator + "Username", ChatColor.White + "Your username has been set. You must now choose a password.", DialogConstants.Next);

                        void GoToStepTwoDialogHandler(MessageDialogResponse r)
                        {
                            RegisterStepTwoDialog.Open(player, dialogService);
                        };

                        dialogService.Show(player.Entity, usernameSet, GoToStepTwoDialogHandler);
                    }
                }
                else
                {
                    MainMenuDialog.Open(player, dialogService);
                }
            }

            dialogService.Show(player.Entity, registerDialog, StepOneDialogHandler);
        }
    }
}
