using OpenRP.GameMode.Definitions.Constants;
using OpenRP.GameMode.Features.Accounts.Helpers;
using OpenRP.GameMode.Features.Chat.Constants;
using SampSharp.Entities.SAMP;

namespace OpenRP.GameMode.Features.MainMenu.Dialogs
{
    public static class LoginStepOneDialog
    {
        public static void Open(Player player, IDialogService dialogService)
        {
            InputDialog loginDialog = new InputDialog();

            loginDialog.Caption = DialogConstants.Prefix + "Login" + DialogConstants.Separator + "Username";
            loginDialog.Content = ChatColor.White + "What is your username?";
            loginDialog.Button1 = DialogConstants.Next;
            loginDialog.Button2 = DialogConstants.Previous;

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
                        MessageDialog accountDoesNotExist = new MessageDialog(DialogConstants.Prefix + "Login" + DialogConstants.Separator + "Username", ChatColor.White + "There is no account with this username.", DialogConstants.Retry);
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
