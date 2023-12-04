using OpenRP.GameMode.Data;
using OpenRP.GameMode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenRP.GameMode.Features.Inventories.Helpers
{
    public static class InventoryItemHelper
    {
        public static Inventory GetInventory(this InventoryItem item)
        {
            using (var context = new DataContext())
            {
                return context.Inventories.Find(item.InventoryId);
            }
        }

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

            if (inventoryItem.GetItem().IsItemInventory())
            {
                total_weight += (uint)inventoryItem.GetInventory().GetInventoryItems().Sum(i => i.GetTotalWeight());
            }

            return total_weight;
        }
    }
}
