using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using OpenRP.GameMode.Configuration;
using OpenRP.GameMode.Data;
using OpenRP.GameMode.Data.Models;
using SampSharp.Entities.SAMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenRP.GameMode.Features.Inventories.Helpers
{
    public static class InventoryHelper
    {
        public static Inventory CreateInventory(string inventoryName, uint? maxWeightInGrams)
        {
            try
            {
                using (var context = new DataContext())
                {
                    Inventory newInventory = new Inventory() { Name =  inventoryName, MaxWeight = maxWeightInGrams };
                    context.Inventories.Add(newInventory);
                    context.SaveChanges();

                    return newInventory;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static Inventory GetParentInventory(this Inventory inventory)
        {
            using (var context = new DataContext())
            {
                List<Inventory> inventories = context.Inventories
                    .Include(i => i.Items)
                    .ToList();

                return inventories.SingleOrDefault(i => i.GetInventoryItems().Any(j => j.GetItem().IsItemInventory() && ItemAdditionalData.Parse(j.AdditionalData).GetString("INVENTORY") == inventory.Id.ToString()));
            }
        }

        public static string GetInventoryDialogName(this Inventory inventory, bool show_weight = true)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}", inventory.Name);

            if (show_weight)
            {
                sb.AppendFormat(" ({0}g / {1}g)", inventory.GetInventoryItems().Sum(i => i.GetTotalWeight()), inventory.MaxWeight.ToString());
            }

            return sb.ToString();
        }

        public static List<InventoryItem> GetInventoryItems(this Inventory inventory)
        {
            if (inventory.Items != null)
            {
                return inventory.Items;
            } else {
                using (var context = new DataContext())
                {
                    return context.Inventories.Find(inventory.Id).Items;
                }
            }
        }
    }
}
