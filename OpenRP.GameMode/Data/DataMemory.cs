using Microsoft.EntityFrameworkCore;
using OpenRP.GameMode.Data.Models;
using OpenRP.GameMode.Features.Inventories.Entities;
using SampSharp.Streamer.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace OpenRP.GameMode.Data
{
    public static class DataMemory
    {
        private static List<Item> Items { get; set; } = null;
        private static List<ItemType> ItemTypes { get; set; } = null;
        private static List<DroppedInventoryItemBundle> DroppedInventoryItemBundles { get; set; } = null;

        public static List<Item> GetItems()
        {
            if (Items == null)
            {
                using (var context = new DataContext())
                {
                    Items = context.Items
                        .Include(c => c.UseType)
                        .ToList();

                }
            }
            return Items;
        }

        public static List<ItemType> GetItemTypes()
        {
            if (ItemTypes == null)
            {
                using (var context = new DataContext())
                {
                    ItemTypes = context.ItemTypes
                        .ToList();

                }
            }
            return ItemTypes;
        }

        public static List<DroppedInventoryItemBundle> GetDroppedInventoryItemBundles(IStreamerService streamerService)
        {
            if (DroppedInventoryItemBundles == null)
            {
                using (var context = new DataContext())
                {
                    List<DroppedInventoryItem> DroppedInventoryItems = context.DroppedInventoryItems
                        .Include(i => i.InventoryItem)
                        .ToList();

                    DroppedInventoryItemBundles = new List<DroppedInventoryItemBundle>();
                    foreach(DroppedInventoryItem droppedInventoryItem in DroppedInventoryItems)
                    {
                        DroppedInventoryItemBundle droppedInventoryItemBundle = new DroppedInventoryItemBundle();
                        droppedInventoryItemBundle.DroppedInventoryItem = droppedInventoryItem;
                        droppedInventoryItemBundle.DynamicObject = streamerService.CreateDynamicObject(
                            1575
                            , new SampSharp.Entities.SAMP.Vector3(
                                droppedInventoryItem.PosX
                                , droppedInventoryItem.PosY
                                , droppedInventoryItem.PosZ
                            )
                            , new SampSharp.Entities.SAMP.Vector3(
                                droppedInventoryItem.RotX.Value
                                , droppedInventoryItem.RotY.Value
                                , droppedInventoryItem.RotZ.Value
                            )
                        );
                    }
                }
            }
            return DroppedInventoryItemBundles;
        }
    }
}
