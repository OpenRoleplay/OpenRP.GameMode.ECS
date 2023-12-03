using OpenRP.GameMode.Features.Accounts.Helpers;
using OpenRP.GameMode.Features.Chat.Constants;
using OpenRP.GameMode.Helpers;
using SampSharp.Entities.SAMP;

namespace OpenRP.GameMode.Features.MainMenu.Dialogs
{
    public static class LoginStepOneDialog
    {
        public static void Open(Player player, IDialogService dialogService)
        {
            InputDialog loginDialog = new InputDialog();

            loginDialog.Caption = DialogHelper.GetTitle("Login", "Username");
            loginDialog.Content = ChatColor.White + "What is your username?";
            loginDialog.Button1 = DialogHelper.Next;
            loginDialog.Button2 = DialogHelper.Previous;

            void StepOneDialogHandler(InputDialogResponse r)
            {
                if (r.Response == DialogResponse.LeftButton)
                {
                    if (AccountHelper.DoesAccountExist(r.InputText))
                    {
                        LoginStepTwoDialog.Open(player, dialogService, r.InputText);
                    }
                    else
                    {
                        MessageDialog accountDoesNotExist = new MessageDialog(DialogHelper.GetTitle("Login", "Username"), ChatColor.White + "There is no account with this username.", DialogHelper.Retry);
                        void RetryUsernameDialogHandler(MessageDialogResponse r)
                        {
                            LoginStepOneDialog.Open(player, dialogService);
                        };

                        dialogService.Show(player.Entity, accountDoesNotExist, RetryUsernameDialogHandler);
                    }
                }
                else
                {
                    MainMenuDialog.Open(player, dialogService);
                }
            }

            dialogService.Show(player.Entity, loginDialog, StepOneDialogHandler);
        }
    }
}
