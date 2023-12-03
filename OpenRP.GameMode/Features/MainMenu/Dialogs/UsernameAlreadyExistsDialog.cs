using OpenRP.GameMode.Features.Chat.Constants;
using OpenRP.GameMode.Helpers;
using SampSharp.Entities.SAMP;

namespace OpenRP.GameMode.Features.MainMenu.Dialogs
{
    public static class UsernameAlreadyExistsDialog
    {
        public static void Open(Player player, IDialogService dialogService)
        {
            MessageDialog usernameExistsDialog = new MessageDialog(DialogHelper.GetTitle("Registration", "Username"), ChatColor.White + "You can not use this username because an account already exists under this username! Pick another one!", DialogHelper.Retry);

            void UsernameAlreadyExistsDialogHandler(MessageDialogResponse r)
            {
                RegisterStepOneDialog.Open(player, dialogService);
            }

            dialogService.Show(player.Entity, usernameExistsDialog, UsernameAlreadyExistsDialogHandler);
        }
    }
}
