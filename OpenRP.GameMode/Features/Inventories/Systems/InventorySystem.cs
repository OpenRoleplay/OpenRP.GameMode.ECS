using OpenRP.ColAndreas;
using OpenRP.GameMode.Data;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Streamer.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OpenRP.GameMode.Features.Inventories.Systems
{
    public class InventorySystem : ISystem
    {
        [Event]
        public void OnGameModeInit(IServerService serverService, IStreamerService streamerService)
        {
            // Load Dropped Inventory Bundles
            DataMemory.GetDroppedInventoryItemBundles(streamerService);
        }
    }
}
