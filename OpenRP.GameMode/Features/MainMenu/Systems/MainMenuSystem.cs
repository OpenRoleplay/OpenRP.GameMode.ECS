using OpenRP.GameMode.Features.MainMenu.Dialogs;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using System;

namespace OpenRP.GameMode.Features.MainMenu.Systems
{
    public class MainMenuSystem : ISystem
    {

        [Event]
        public void OnPlayerConnect(Player player, IDialogService dialogService)
        {
        }

        [Event]
        public void OnPlayerRequestClass(Player player, int classid, IDialogService dialogService)
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

            MainMenuDialog.Open(player, dialogService);
        }
    }
}
