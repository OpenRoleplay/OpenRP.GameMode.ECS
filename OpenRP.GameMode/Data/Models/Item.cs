using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Data.Models
{
    public class Item
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public uint Weight { get; set; }
        public uint MaxUses { get; set; }
        public bool KeepOnDeath { get; set; }
        public bool CanDrop { get; set; }
        public bool CanDestroy { get; set; }
    }
}
