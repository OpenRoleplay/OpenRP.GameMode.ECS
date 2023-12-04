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
        public static Inventory GetItemInventory(this InventoryItem item)
        {
            using (var context = new DataContext())
            {
                if (item.GetItem().IsItemInventory())
                {
                    ItemAdditionalData itemAdditionalData = ItemAdditionalData.Parse(item.AdditionalData);

                    string inventoryId = itemAdditionalData.GetString("INVENTORY");
                    if (String.IsNullOrEmpty(inventoryId))
                    {
                        Inventory inventory = InventoryHelper.CreateInventory(item.GetItem().Name, 1000);
                        if (inventory != null)
                        {
                            inventoryId = inventory.Id.ToString();
                            itemAdditionalData.SetString("INVENTORY", inventoryId);

                            InventoryItem updateItem = context.InventoryItems.Find(item.Id);
                            updateItem.AdditionalData = item.AdditionalData = itemAdditionalData.ToString();
                            context.SaveChanges();
                        }
                    }
                    return context.Inventories.Find(inventoryId);
                }
                return null;
            }
        }

        public static Inventory GetInventoryIn(this InventoryItem item)
        {
            using (var context = new DataContext())
            {
                return context.Inventories.Find(item.InventoryId);
            }
        }

        public static string GetName(this InventoryItem inventoryItem)
        {
            return inventoryItem.Item.Name;
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
                total_weight += (uint)inventoryItem.GetItemInventory().GetInventoryItems().Sum(i => i.GetTotalWeight());
            }

            return total_weight;
        }
    }
}
