using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using System;
using System.Globalization;

namespace OpenRP.GameMode
{
    public class SetupServer : ISystem
    {
        [Event]
        public void OnGameModeInit(IServerService serverService)
        {
            // Gamemode Message
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" Open Roleplay by Koert Lichtendonk");
            Console.WriteLine("----------------------------------\n");

            // AddPlayerClass
            serverService.AddPlayerClass(8, new Vector3(0, 0, 7), 0);

            // Default Settings
            serverService.SetGameModeText("Strict Roleplay");
            serverService.EnableStuntBonus(false);
            serverService.DisableInteriorEnterExits();
            serverService.ShowPlayerMarkers(PlayerMarkersMode.Off);
            serverService.ShowNameTags(true);
            serverService.ManualVehicleEngineAndLights();

            // CultureInfo
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
        }
    }
}