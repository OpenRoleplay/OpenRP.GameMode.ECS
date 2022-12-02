using OpenRP.GameMode.Definitions.Constants;
using OpenRP.GameMode.Features.Accounts.Helpers;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.MainMenu.Systems
{
    public class MainMenuSystem : ISystem
    {

        [Event]
        public void OnPlayerConnect(Player player, IDialogService dialogService)
        {
            // Toggles
            player.ToggleSpectating(true);
            player.ToggleControllable(false);

            switch (new Random().Next(2))
            {
                case 0: // Angel Pine North Gas Station
                    player.Position = new Vector3(-1508.2727, -2991.9058, 0.0);
                    player.CameraPosition = new Vector3(-1508.2727, -2991.9058, 93.6866);
                    player.SetCameraLookAt(new Vector3(-1508.5916, -2990.9526, 93.5015));
                    player.InterpolateCameraPosition(new Vector3(-1508.2727, -2991.9058, 93.6866), new Vector3(-1717.8026, -2789.3159, 121.2620), 60000, CameraCut.Move);
                    player.InterpolateCameraLookAt(new Vector3(-1508.5916, -2990.9526, 93.5015), new Vector3(-1716.9001, -2788.8755, 120.8320), 60000, CameraCut.Move);
                    break;
                case 1: // Flint County Farm
                    player.Position = new Vector3(-269.4498, -1614.9242, 0.0);
                    player.CameraPosition = new Vector3(-269.4498, -1614.9242, 58.0998);
                    player.SetCameraLookAt(new Vector3(-270.2507, -1614.3184, 57.8497));
                    player.InterpolateCameraPosition(new Vector3(-269.4498, -1614.9242, 58.0998), new Vector3(-255.4192, -1487.0031, 50.0984), 60000, CameraCut.Move);
                    player.InterpolateCameraLookAt(new Vector3(-270.2507, -1614.3184, 57.8497), new Vector3(-256.3769, -1486.7010, 50.0233), 60000, CameraCut.Move);
                    break;
            }

            OpenMainMenuDialog(player, dialogService);
        }

        public void OpenMainMenuDialog(Player player, IDialogService dialogService)
        {
            ListDialog mainMenuDialog = new ListDialog(ChatColor.White + "Welcome to Open Roleplay! What would you like to do?", "Continue", "Quit");

            bool doesAccountExist = AccountHelper.DoesAccountExist(player.Name);

            void TestDialogHandler(ListDialogResponse r)
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
                            //OpenRegisterDialogStep1(player);
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
                            //OpenRegisterDialogStep1(player);
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

            dialogService.Show(player.Entity, mainMenuDialog, TestDialogHandler);
        }
    }
}
