using OpenRP.GameMode.Data.Models;
using OpenRP.GameMode.Features.Accounts.Components;
using OpenRP.GameMode.Features.Chat.Constants;
using OpenRP.GameMode.Features.Inventories.Components;
using OpenRP.GameMode.Features.Inventories.Helpers;
using OpenRP.GameMode.Helpers;
using SampSharp.Entities.SAMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenRP.GameMode.Features.Inventories.Dialogs
{
    public class InventoryItemsDialog
    {
        public static void Open(Player player, List<InventoryItem> inventoryItemsToShow, IDialogService dialogService, InventoryArgument[] args = null)
        {
            /*CharacterComponent characterComponent = player.GetComponent<CharacterComponent>();
            if (characterComponent != null)
            {
                OpenInventoryComponent openInventoryComponent = player.AddComponent<OpenInventoryComponent>();

                if(openInventoryComponent != null && openInventoryComponent.openedInventory != null)
                {
                    openInventoryComponent.openedInventoryItems = inventoryItemsToShow.OrderByDescending(i => i.GetTotalWeight()).ToList();

                    StringBuilder inventory_name_builder = new StringBuilder();

                    inventory_name_builder.Append(DialogHelper.dialogPrefix);
                    Inventory parentInventory = this.GetParentInventory();
                    if (parentInventory != null)
                    {
                        inventory_name_builder.Append(parentInventory.GetInventoryDialogName(false));
                        inventory_name_builder.Append(ChatColor.CornflowerBlue + " -> " + ChatColor.White);
                    }
                    inventory_name_builder.Append(this.GetInventoryDialogName());

                    string inventory_name = inventory_name_builder.ToString();

                    // Fill Headers
                    List<string> inventoryColumnHeaders = new List<string>();

                    inventoryColumnHeaders.Add(ChatColor.CornflowerBlue + "Item");
                    inventoryColumnHeaders.Add(ChatColor.CornflowerBlue + "Amount");

                    if (args == null || !args.Contains(InventoryArgument.HideTotalWeight))
                    {
                        inventoryColumnHeaders.Add(ChatColor.CornflowerBlue + "Total Weight");
                    }

                    if (args == null || !args.Contains(InventoryArgument.HideExtraInformation))
                    {
                        inventoryColumnHeaders.Add(ChatColor.CornflowerBlue + "Extra Information");
                    }
                }
            }*/
        }
    }
}
