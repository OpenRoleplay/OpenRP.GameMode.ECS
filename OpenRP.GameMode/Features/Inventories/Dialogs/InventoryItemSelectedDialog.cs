using OpenRP.GameMode.Extensions;
using OpenRP.GameMode.Features.Inventories.Components;
using OpenRP.GameMode.Features.Inventories.Helpers;
using OpenRP.GameMode.Helpers;
using SampSharp.Entities.SAMP;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.Inventories.Dialogs
{
    public class InventoryItemSelectedDialog
    {
        public static void Open(Player player, OpenInventoryComponent openInventoryComponent, IDialogService dialogService)
        {
            ListDialog listDialog = new ListDialog(DialogHelper.GetTitle(openInventoryComponent.selectedInventoryItem.GetItem().Name), "Select", "Cancel");

            List<string> listItems = new List<string>();

            if (openInventoryComponent.selectedInventoryItem.GetItem().IsItemWallet())
            {
                listItems.Add("Open");
            }
            else if (openInventoryComponent.selectedInventoryItem.GetItem().IsItemSkin()
                          || openInventoryComponent.selectedInventoryItem.GetItem().IsItemAttachment())
            {
                listItems.Add("Wear");
            }
            else
            {
                listItems.Add("Use");
            }
            if (openInventoryComponent.selectedInventoryItem.GetItem().IsItemAttachment())
            {
                listItems.Add("Edit");
            }
            listItems.Add("Description");
            if (openInventoryComponent.selectedInventoryItem.GetItem().CanDestroy)
            {
                listItems.Add("Destroy");
            }
            if (openInventoryComponent.selectedInventoryItem.GetItem().CanDrop)
            {
                listItems.Add("Drop");
            }
            listItems.Sort();

            openInventoryComponent.actionsList = listItems;
            listDialog.Add(String.Join("\n", listItems));

            void InventoryItemSelectedItemActionsDialogHandler(ListDialogResponse r)
            {
                if (r.Response == DialogResponse.LeftButton)
                {
                    switch (openInventoryComponent.actionsList[r.ItemIndex])
                    {
                        /*case "Wear":
                            if (openInventoryComponent.selectedInventoryItem.GetItem().IsItemSkin())
                            {
                                if (player.main_account.current_character.SetCharacterWearingInventorySkin(openInventoryComponent.selectedInventoryItem))
                                {
                                    player.SendPlayerChatMessage(PlayerChatMessage.ME, "changed their clothes.");
                                    player.SendPlayerInfoMessage(Definitions.Enums.PlayerInfoMessage.INFO, "You have succesfully changed your clothes.");
                                }
                                else
                                {
                                    player.SendPlayerInfoMessage(Definitions.Enums.PlayerInfoMessage.ERROR, "An unknown problem occured and we could not change your clothes.");
                                }
                            }
                            else if (player.selectedInventoryItem.GetItem().IsItemAttachment())
                            {
                                if (player.main_account.current_character.SetCharacterWearingInventorySkin(player.selectedInventoryItem))
                                {
                                    player.SendPlayerChatMessage(PlayerChatMessage.ME, "changed their clothes.");
                                    player.SendPlayerInfoMessage(Definitions.Enums.PlayerInfoMessage.INFO, "You have succesfully changed your clothes.");
                                }
                                else
                                {
                                    player.SendPlayerInfoMessage(Definitions.Enums.PlayerInfoMessage.ERROR, "An unknown problem occured and we could not change your clothes.");
                                }
                            }
                            break;
                        case "Open":
                            //openInventoryComponent.selectedInventoryItem.GetParentInventory().OpenInventoryDialog(player);
                            break;*/
                        case "Description":
                            string description = String.Empty;
                            if (String.IsNullOrEmpty(openInventoryComponent.selectedInventoryItem.GetItem().Description))
                            {
                                description = "This item does not have a description.";
                            }
                            else
                            {
                                description = openInventoryComponent.selectedInventoryItem.GetItem().Description.WordWrap(100);
                            }

                            MessageDialog messageDialog = new MessageDialog(DialogHelper.GetTitle(openInventoryComponent.selectedInventoryItem.GetName(), "Description"), description, "Close");
                            dialogService.Show(player, messageDialog);
                            break;
                        /*case "Drop":
                            //player.selectedInventoryItem.Drop(player.Position, player.selectedInventoryItem.inventory_item_amount);
                            break;*/
                    }
                }

                player.DestroyComponents<OpenInventoryComponent>();
            }

            dialogService.Show(player, listDialog, InventoryItemSelectedItemActionsDialogHandler);
        }
    }
}
