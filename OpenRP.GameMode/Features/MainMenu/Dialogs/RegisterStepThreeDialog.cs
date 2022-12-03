using MySql.Data.MySqlClient;
using OpenRP.GameMode.Configuration;
using OpenRP.GameMode.Data.Models;
using OpenRP.GameMode.Definitions.Constants;
using OpenRP.GameMode.Features.Accounts.Components;
using OpenRP.GameMode.Features.Accounts.Helpers;
using SampSharp.Entities.SAMP;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.MainMenu.Dialogs
{
    public static class RegisterStepThreeDialog
    {
        public static void Open(Player player, IDialogService dialogService)
        {
            InputDialog registerDialog = new InputDialog();

            registerDialog.Caption = DialogConstants.Prefix + "Registration" + DialogConstants.Separator + "Password Confirmation";
            registerDialog.Content = ChatColor.White + "Confirm your password.";
            registerDialog.Button1 = DialogConstants.Next;
            registerDialog.Button2 = DialogConstants.Previous;
            registerDialog.IsPassword = true;

            void StepTwoDialogHandler(InputDialogResponse r)
            {
                if (r.Response == DialogResponse.LeftButton)
                {
                    AccountComponent accountComponent = player.GetComponent<AccountComponent>();

                    if (BCrypt.Net.BCrypt.Verify(r.InputText, accountComponent?.Account?.Password))
                    {
                        MessageDialog passwordSetDialog = new MessageDialog(DialogConstants.Prefix + "Registration" + DialogConstants.Separator + "Password Confirmation", ChatColor.White + "Your password has been set. You may now log in to your account.", DialogConstants.Next);

                        void PasswordSetDialogHandler(MessageDialogResponse r)
                        {
                            MySqlConnection sqlConnecton = new MySqlConnection(ConfigManager.Instance.Data.ConnectionString);
                            sqlConnecton.Open();

                            MySqlCommand insertAccount = new MySqlCommand("INSERT INTO accounts (Username, Password) VALUES(@account_username, @account_password)", sqlConnecton);
                            insertAccount.Parameters.AddWithValue("@account_username", accountComponent.Account.Username);
                            insertAccount.Parameters.AddWithValue("@account_password", accountComponent.Account.Password);
                            insertAccount.ExecuteNonQuery();

                            sqlConnecton.Close();
                        };

                        dialogService.Show(player.Entity, passwordSetDialog, PasswordSetDialogHandler);
                    } 
                    else
                    {
                        MessageDialog passwordsDoNotMatchDialog = new MessageDialog(DialogConstants.Prefix + "Password Confirmation" + DialogConstants.Separator + "Password", ChatColor.White + "The passwords you have entered do not match.", DialogConstants.Retry);

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
