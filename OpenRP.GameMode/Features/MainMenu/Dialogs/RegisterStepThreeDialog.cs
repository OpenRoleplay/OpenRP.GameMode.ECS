using MySql.Data.MySqlClient;
using OpenRP.GameMode.Configuration;
using OpenRP.GameMode.Features.Accounts.Components;
using OpenRP.GameMode.Features.Chat.Constants;
using OpenRP.GameMode.Helpers;
using SampSharp.Entities.SAMP;

namespace OpenRP.GameMode.Features.MainMenu.Dialogs
{
    public static class RegisterStepThreeDialog
    {
        public static void Open(Player player, IDialogService dialogService)
        {
            InputDialog registerDialog = new InputDialog();

            registerDialog.Caption = DialogHelper.GetTitle("Registration", "Password Confirmation");
            registerDialog.Content = ChatColor.White + "Confirm your password.";
            registerDialog.Button1 = DialogHelper.Next;
            registerDialog.Button2 = DialogHelper.Previous;
            registerDialog.IsPassword = true;

            void StepTwoDialogHandler(InputDialogResponse r)
            {
                if (r.Response == DialogResponse.LeftButton)
                {
                    AccountComponent accountComponent = player.GetComponent<AccountComponent>();

                    if (BCrypt.Net.BCrypt.Verify(r.InputText, accountComponent?.Account?.Password))
                    {
                        MessageDialog passwordSetDialog = new MessageDialog(DialogHelper.GetTitle("Registration", "Password Confirmation"), ChatColor.White + "Your password has been set. You may now log in to your account.", DialogHelper.Next);

                        void PasswordSetDialogHandler(MessageDialogResponse r)
                        {
                            MySqlConnection sqlConnecton = new MySqlConnection(ConfigManager.Instance.Data.ConnectionString);
                            sqlConnecton.Open();

                            MySqlCommand insertAccount = new MySqlCommand("INSERT INTO accounts (Username, Password) VALUES(@account_username, @account_password)", sqlConnecton);
                            insertAccount.Parameters.AddWithValue("@account_username", accountComponent.Account.Username);
                            insertAccount.Parameters.AddWithValue("@account_password", accountComponent.Account.Password);
                            insertAccount.ExecuteNonQuery();

                            sqlConnecton.Close();

                            LoginStepTwoDialog.Open(player, dialogService, accountComponent.Account.Username);
                        };

                        dialogService.Show(player.Entity, passwordSetDialog, PasswordSetDialogHandler);
                    } 
                    else
                    {
                        MessageDialog passwordsDoNotMatchDialog = new MessageDialog(DialogHelper.GetTitle("Registration", "Password Confirmation"), ChatColor.White + "The passwords you have entered do not match.", DialogHelper.Retry);

                        void PasswordsDoNotMatchDialogHandler(MessageDialogResponse r)
                        {
                            RegisterStepTwoDialog.Open(player, dialogService);
                        };

                        dialogService.Show(player.Entity, passwordsDoNotMatchDialog, PasswordsDoNotMatchDialogHandler);
                    }
                }
                else
                {
                    RegisterStepTwoDialog.Open(player, dialogService);
                }
            }

            dialogService.Show(player.Entity, registerDialog, StepTwoDialogHandler);
        }
    }
}
