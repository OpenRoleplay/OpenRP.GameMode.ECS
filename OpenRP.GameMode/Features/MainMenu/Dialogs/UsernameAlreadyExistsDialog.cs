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
    public static class UsernameAlreadyExistsDialog
    {
        public static void Open(Player player, IDialogService dialogService)
        {
            MessageDialog usernameExistsDialog = new MessageDialog(DialogConstants.Prefix + "Registration" + DialogConstants.Separator + "Username", ChatColor.White + "You can not use this username because an account already exists under this username! Pick another one!", DialogConstants.Retry);

            void UsernameAlreadyExistsDialogHandler(MessageDialogResponse r)
            {
                RegisterStepOneDialog.Open(player, dialogService);
            }

            dialogService.Show(player.Entity, usernameExistsDialog, UsernameAlreadyExistsDialogHandler);
        }
    }
}
