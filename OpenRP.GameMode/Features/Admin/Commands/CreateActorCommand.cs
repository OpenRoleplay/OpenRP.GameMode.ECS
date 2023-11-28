using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Entities.SAMP.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.Admin.Commands
{
    public class CreateActorCommand : ISystem
    {
        [PlayerCommand]
        public void CreateActor(Player player, IWorldService worldService)
        {
            var actor = worldService.CreateActor(player.Skin, player.Position, player.Rotation.Z);
            player.Position = new Vector3(actor.Position.X, actor.Position.Y, actor.Position.Z + 2);
            Console.WriteLine("CreateActor({0}, new Vector3({1}, {2}, {3}), {4});", player.Skin, actor.Position.X, actor.Position.Y, actor.Position.Z, actor.FacingAngle);
        }
    }
}
