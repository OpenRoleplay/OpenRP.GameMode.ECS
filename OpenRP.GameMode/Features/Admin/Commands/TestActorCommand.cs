using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Entities.SAMP.Commands;
using SampSharp.GameMode;
using SampSharp.Streamer.World;
using System;
using System.Collections.Generic;
using System.Text;
using Vector3 = SampSharp.GameMode.Vector3;

namespace OpenRP.GameMode.Features.Admin.Commands
{
    public class TestActorCommand : ISystem
    {
        [PlayerCommand]
        public void TestActor(Player player, IWorldService worldService)
        {
            worldService.CreateActor(26586, new SampSharp.Entities.SAMP.Vector3(-134.4153, 2256.6213, 31.447994), 82.31555f);
            worldService.CreateActor(26588, new SampSharp.Entities.SAMP.Vector3(-134.19919, 2258.0393, 31.493938), 80.39665f);
            Actor actor = worldService.CreateActor(27075, new SampSharp.Entities.SAMP.Vector3(-137.30177, 2255.6594, 31.40712), 301.7758f);
            //DynamicActor victim1 = new DynamicActor(26586, new Vector3(-134.4153, 2256.6213, 31.447994), 82.31555f);
            //DynamicActor victim2 = new DynamicActor(26588, new Vector3(-134.19919, 2258.0393, 31.493938), 80.39665f);
            //DynamicActor polzin = new DynamicActor(27075, new Vector3(-137.30177, 2255.6594, 31.40712), 301.7758f);

            player.Position = actor.Position;//new SampSharp.Entities.SAMP.Vector3(polzin.Position.X, polzin.Position.Y, polzin.Position.Z);

            //FCNPC test = FCNPC.Create("Guard");
            //test.Spawn(1, new Vector3(-136.5212, 2257.8206, 31.3430));
            //test.Angle = 261.6685f;
            //test.AimAt(new Vector3(-134.19919, 2258.0393, 31.493938));
        }
    }
}
