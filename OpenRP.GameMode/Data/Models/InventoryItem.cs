using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Data.Models
{
    public class InventoryItem
    {
        public ulong Id { get; set; }
        public Item Item { get; set; }
        public uint Amount { get; set; }
        public uint UsesRemaining { get; set; }
        public bool KeepOnDeath { get; set; }
        public bool CanDrop { get; set; }
        public bool CanDestroy { get; set; }
        public ulong InventoryId { get; set; }
    }
}
