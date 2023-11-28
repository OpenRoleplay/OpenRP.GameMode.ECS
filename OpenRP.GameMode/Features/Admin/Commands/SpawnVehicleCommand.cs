using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Entities.SAMP.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.Admin.Commands
{
    public class SpawnVehicleCommand : ISystem
    {
        [PlayerCommand]
        public void SpawnVeh(Player player, VehicleModelType model, IWorldService worldService)
        {
            var vehicle = worldService.CreateVehicle(model, player.Position, 0, 0, 0);
            vehicle.Engine = true;
            player.PutInVehicle(vehicle);
        }

        [PlayerCommand]
        public void SV(Player player, VehicleModelType model, IWorldService worldService)
        {
            SpawnVeh(player, model, worldService);
        }
    }
}
