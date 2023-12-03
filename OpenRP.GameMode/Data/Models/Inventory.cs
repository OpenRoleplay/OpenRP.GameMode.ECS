using System.Collections.Generic;

namespace OpenRP.GameMode.Data.Models
{
    public class Inventory
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Max weight in Grams
        /// </summary>
        public uint? MaxWeight { get; set; }
        public List<InventoryItem> Items { get; set; }
    }
}