using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Data.Models
{
    public class InventoryItem
    {
        public ulong Id { get; set; }
        #region Item
        public ulong ItemId { get; set; }
        private Item Item { get; set; }
        #endregion
        public uint Amount { get; set; }
        public uint UsesRemaining { get; set; }
        public bool KeepOnDeath { get; set; }
        public bool CanDrop { get; set; }
        public bool CanDestroy { get; set; }
        public ulong InventoryId { get; set; }
        public string AdditionalData { get; set; }
    }
}
