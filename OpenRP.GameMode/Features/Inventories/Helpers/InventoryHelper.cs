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
                //return Inventory.All.SingleOrDefault(i => i.GetInventoryItems().Any(i => i.GetItem().IsItemInventory() && i.inventory_item_use_value == this.inventory_id));//  i.GetInventory() == this));
                return context.Inventories.FirstOrDefault(i => i.Items.Any(j => j.Item.IsItemInventory() && ItemAdditionalData.Parse(j.AdditionalData).GetString("INVENTORY") == inventory.Id.ToString()));
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
            using (var context = new DataContext())
            {
                return context.Inventories.Find(inventory.Id).Items;
            }
        }

        public static void OpenDialog(this Inventory inventory, Player for_player)
        {
            //for_player.openedInventoryItems = inventory.GetInventoryItems();

            //this.OpenInventoryItemsDialog(for_player, for_player.openedInventoryItems, args);
        }
    }
}
