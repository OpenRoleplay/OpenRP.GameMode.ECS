using OpenRP.GameMode.Extensions;
using OpenRP.GameMode.Features.Accounts.Components;
using OpenRP.GameMode.Features.Characters.Helpers;
using OpenRP.GameMode.Features.Chat.Enums;
using OpenRP.GameMode.Features.Chat.Helpers;
using OpenRP.GameMode.Features.Inventories.Components;
using OpenRP.GameMode.Features.Inventories.Helpers;
using OpenRP.GameMode.Helpers;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.Inventories.Dialogs
{
    public class InventoryItemSelectedDialog
    {
        public static void Open(Player player, OpenInventoryComponent openInventoryComponent, IDialogService dialogService, IEntityManager entityManager)
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

            listItems.ForEach(item => { 
                listDialog.Add(item); 
            });
            openInventoryComponent.actionsList = listItems;

            void InventoryItemSelectedItemActionsDialogHandler(ListDialogResponse r)
            {
                if (r.Response == DialogResponse.LeftButton)
                {
                    CharacterComponent characterComponent = player.GetComponent<CharacterComponent>();

                    switch (openInventoryComponent.actionsList[r.ItemIndex])
                    {
                        case "Wear":
                            if (openInventoryComponent.selectedInventoryItem.GetItem().IsItemSkin())
                            {
                                if (characterComponent.CharacterPlayingAs.SetCharacterWearingInventorySkin(openInventoryComponent.selectedInventoryItem, entityManager))
                                {
                                    player.SendPlayerChatMessage(entityManager, PlayerChatMessageType.ME, "changed their clothes.");
                                    player.SendPlayerInfoMessage(PlayerInfoMessageType.INFO, "You have succesfully changed your clothes.");
                                }
                                else
                                {
                                    player.SendPlayerInfoMessage(PlayerInfoMessageType.ERROR, "An unknown problem occured and we could not change your clothes.");
                                }
                            }
                            else if (openInventoryComponent.selectedInventoryItem.GetItem().IsItemAttachment())
                            {
                                if (characterComponent.CharacterPlayingAs.SetCharacterWearingInventorySkin(openInventoryComponent.selectedInventoryItem, entityManager))
                                {
                                    player.SendPlayerChatMessage(entityManager, PlayerChatMessageType.ME, "changed their clothes.");
                                    player.SendPlayerInfoMessage(PlayerInfoMessageType.INFO, "You have succesfully changed your clothes.");
                                }
                                else
                                {
                                    player.SendPlayerInfoMessage(PlayerInfoMessageType.ERROR, "An unknown problem occured and we could not change your clothes.");
                                }
                            }
                            break;/*
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
