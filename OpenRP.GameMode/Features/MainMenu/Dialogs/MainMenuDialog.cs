using OpenRP.GameMode.Definitions.Constants;
using OpenRP.GameMode.Features.Accounts.Helpers;
using SampSharp.Entities.SAMP;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.MainMenu.Dialogs
{
    public static class MainMenuDialog
    {
        public static void Open(Player player, IDialogService dialogService)
        {
            ListDialog mainMenuDialog = new ListDialog(ChatColor.White + "Welcome to Open Roleplay! What would you like to do?", DialogConstants.Next, DialogConstants.Previous);

            bool doesAccountExist = AccountHelper.DoesAccountExist(player.Name);

            void MainMenuDialogHandler(ListDialogResponse r)
            {
                if (r.Response == DialogResponse.LeftButton)
                {
                    if (doesAccountExist)
                    {
                        if (r.ItemIndex == 0) // Log in to [CURRENT USERNAME]
                        {
                            //OpenLoginDialogStep2(player, player.Name);
                        }
                        else if (r.ItemIndex == 1) // Log in to a different username
                        {
                            //OpenLoginDialogStep1(player);
                        }
                        else if (r.ItemIndex == 2) // Create a new account
                        {
                            RegisterStepOneDialog.Open(player, dialogService);
                        }
                    }
                    else
                    {
                        if (r.ItemIndex == 0) // Log in to a different username
                        {
                            //OpenLoginDialogStep1(player);
                        }
                        else if (r.ItemIndex == 1) // Create a new account
                        {
                            RegisterStepOneDialog.Open(player, dialogService);
                        }
                    }
                }
                else
                {
                    player.Kick();
                }
            }

            if (doesAccountExist)
            {
                mainMenuDialog.Add("Log in to " + ChatColor.CornflowerBlue + player.Name);
            }
            mainMenuDialog.Add("Log in to a different username");
            mainMenuDialog.Add("Create a new account");

            dialogService.Show(player.Entity, mainMenuDialog, MainMenuDialogHandler);
        }
    }
}
