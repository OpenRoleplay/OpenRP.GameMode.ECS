using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Entities.SAMP.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.Admin.Commands
{
    public class SetSkinCommand : ISystem
    {
        [PlayerCommand]
        public void SetSkin(Player player, int skin_id, IWorldService worldService)
        {
            player.Skin = skin_id;
        }
    }
}
