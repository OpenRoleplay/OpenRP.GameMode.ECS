using OpenRP.GameMode.Features.Accounts.Components;
using OpenRP.GameMode.Features.Characters.Helpers;
using OpenRP.GameMode.Features.Inventories.Components;
using OpenRP.GameMode.Features.Inventories.Helpers;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.Inventories.Dialogs
{
    public static class InventoryDialog
    {
        public static void Open(Player player, IDialogService dialogService, IEntityManager entityManager, InventoryArgument[] args = null)
        {
            CharacterComponent characterComponent = player.GetComponent<CharacterComponent>();
            if (characterComponent != null)
            {
                OpenInventoryComponent openInventoryComponent = player.AddComponent<OpenInventoryComponent>();

                openInventoryComponent.openedInventory = characterComponent.CharacterPlayingAs.GetCharacterInventory();
                openInventoryComponent.openedInventoryItems = openInventoryComponent.openedInventory.GetInventoryItems();

                InventoryItemsDialog.Open(player, openInventoryComponent.openedInventoryItems, dialogService, entityManager, args);
            }
        }
    }
}
