﻿using OpenRP.GameMode.Features.Accounts.Helpers;
using OpenRP.GameMode.Features.Chat.Constants;
using OpenRP.GameMode.Helpers;
using SampSharp.Entities.SAMP;

namespace OpenRP.GameMode.Features.MainMenu.Dialogs
{
    public static class LoginStepTwoDialog
    {
        public static void Open(Player player, IDialogService dialogService, string username)
        {
            InputDialog loginDialog = new InputDialog();

            loginDialog.Caption = DialogHelper.GetTitle("Log in to " + ChatColor.CornflowerBlue + username, "Password"); 
            loginDialog.Content = ChatColor.White + "You are logging in to the account with the username " + ChatColor.CornflowerBlue + username + ChatColor.White + ". What is your password?";
            loginDialog.Button1 = DialogHelper.Next;
            loginDialog.Button2 = DialogHelper.Previous;
            loginDialog.IsPassword = true;

            void StepOneDialogHandler(InputDialogResponse r)
            {
                if (r.Response == DialogResponse.LeftButton)
                {
                    if (!AccountHelper.TryToLoginPlayer(player, dialogService, username, r.InputText))
                    {
                        LoginStepOneDialog.Open(player, dialogService);
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
