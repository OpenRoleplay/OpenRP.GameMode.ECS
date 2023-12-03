using OpenRP.GameMode.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.Inventories.Helpers
{
    public static class InventoryItemHelper
    {
        public static uint GetWeight(this InventoryItem inventoryItem)
        {
            return inventoryItem.Item.Weight;
        }

        public static Item GetItem(this InventoryItem inventoryItem)
        {
            return inventoryItem.Item;
        }

        public static uint GetTotalWeight(this InventoryItem inventoryItem)
        {
            uint total_weight = inventoryItem.GetWeight() * inventoryItem.Amount;

            return total_weight;
        }
    }
}
