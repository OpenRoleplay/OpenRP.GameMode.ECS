using OpenRP.GameMode.Data.Models;
using SampSharp.Streamer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.Inventories.Entities
{
    public class DroppedInventoryItemBundle
    {
        public DroppedInventoryItem DroppedInventoryItem { get; set; }
        public DynamicObject DynamicObject { get; set; }
    }
}
