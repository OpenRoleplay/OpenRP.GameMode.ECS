using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace OpenRP.GameMode.Data.Models
{
    public class DroppedInventoryItem
    {
        public ulong Id { get; set; }
        #region InventoryItem
        public ulong InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }
        #endregion
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public float? RotX { get; set; } = null;
        public float? RotY { get; set; } = null;
        public float? RotZ { get; set; } = null;
    }
}
