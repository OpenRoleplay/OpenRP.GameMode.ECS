using MySql.Data.MySqlClient;
using OpenRP.GameMode.Configuration;
using OpenRP.GameMode.Data;
using OpenRP.GameMode.Data.Models;
using System;
using System.Collections.Generic;
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
    }
}
