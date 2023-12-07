using Microsoft.EntityFrameworkCore;
using OpenRP.ColAndreas;
using OpenRP.GameMode.Data;
using OpenRP.GameMode.Data.Models;
using SampSharp.Entities.SAMP;
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

                    string stringInventoryId = itemAdditionalData.GetString("INVENTORY");
                    if (String.IsNullOrEmpty(stringInventoryId))
                    {
                        Inventory inventory = InventoryHelper.CreateInventory(item.GetItem().Name, 1000);
                        if (inventory != null)
                        {
                            stringInventoryId = inventory.Id.ToString();
                            itemAdditionalData.SetString("INVENTORY", stringInventoryId);

                            InventoryItem updateItem = context.InventoryItems.Find(item.Id);
                            updateItem.AdditionalData = item.AdditionalData = itemAdditionalData.ToString();
                            context.SaveChanges();
                        }
                    }

                    if (ulong.TryParse(stringInventoryId, out ulong inventoryId))
                    {
                        return context.Inventories
                            .Include(i => i.Items)
                            .FirstOrDefault(i => i.Id == inventoryId);
                    }
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
            return inventoryItem.GetItem().Name;
        }

        public static void Drop(this InventoryItem inventoryItem, Vector3 position, uint amount)
        {
            using (var context = new DataContext())
            {
                if (ColAndreasHelper.FindZ_For2DCoord(position.X, position.Y, out float z))
                {
                    Vector3 result_position = new Vector3(position.X, position.Y, z);
                    if (inventoryItem.Amount == amount)
                    {
                        InventoryItem inventoryItemToUpdate = context.InventoryItems.Find(inventoryItem.Id);
                        inventoryItemToUpdate.InventoryId = 1;

                        context.DroppedInventoryItems.Add(new DroppedInventoryItem()
                        {
                            InventoryItemId = inventoryItemToUpdate.Id
                            , PosX = result_position.X
                            , PosY = result_position.Y
                            , PosZ = result_position.Z
                            , RotX = 0
                            , RotY = -90
                            , RotZ = 0
                        });
                    } else
                    {

                    }
                    context.SaveChanges();
                }
            }
        }

        public static uint GetWeight(this InventoryItem inventoryItem)
        {
            return inventoryItem.GetItem().Weight;
        }

        public static Item GetItem(this InventoryItem inventoryItem)
        {
            return DataMemory.GetItems().FirstOrDefault(i => i.Id == inventoryItem.ItemId);
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
