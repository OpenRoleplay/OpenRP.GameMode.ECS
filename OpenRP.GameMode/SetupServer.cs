using OpenRP.GameMode.Features.Chat.Constants;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using System;
using System.Globalization;
using OpenRP.ColAndreas;
using SampSharp.Streamer.Entities;
using OpenRP.GameMode.Data;

namespace OpenRP.GameMode
{
    public class SetupServer : ISystem
    {
        [Event]
        public void OnGameModeInit(IServerService serverService)
        {
            // Attribution may not be removed or modified as per AGPL-3.0 license permissive additional terms.
            Console.WriteLine("\n\nLoading Open Roleplay (open-roleplay.com) by Koert Lichtendonk.");
            Console.WriteLine("Licensed under the AGPL-3.0 license.\n\n");

            // Init ColAndreas
            ColAndreasHelper.Init();

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
            CultureInfo.CurrentCulture = new CultureInfo("nl-NL", false);
        }

        [Event]
        public void OnPlayerConnect(Player player)
        {
            // Attribution may not be removed or modified as per AGPL-3.0 license permissive additional terms.
            player.SendClientMessage(String.Format("{1}Welcome to {0}Open Roleplay {1}({0}open-roleplay.com{1}) by {0}Koert Lichtendonk{1}.", ChatColor.CornflowerBlue, ChatColor.White));
            player.SendClientMessage(String.Format("{1}Licensed under the {0}AGPL-3.0 license{1}.", ChatColor.CornflowerBlue, ChatColor.White));
        }
    }
}