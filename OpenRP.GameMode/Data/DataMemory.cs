using Microsoft.EntityFrameworkCore;
using OpenRP.GameMode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenRP.GameMode.Data
{
    public static class DataMemory
    {
        private static List<Item> Items { get; set; } = null;
        private static List<ItemType> ItemTypes { get; set; } = null;

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
    }
}
