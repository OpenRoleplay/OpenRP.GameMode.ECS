using OpenRP.GameMode.Data.Models;
using OpenRP.GameMode.Data;
using OpenRP.GameMode.Features.Accounts.Components;
using SampSharp.Entities.SAMP.Commands;
using SampSharp.Entities.SAMP;
using System;
using System.Collections.Generic;
using System.Text;
using OpenRP.GameMode.Features.Characters.Helpers;
using SampSharp.Entities;
using OpenRP.GameMode.Features.Inventories.Dialogs;

namespace OpenRP.GameMode.Features.Inventories.Commands
{
    public class InventoryCommand : ISystem
    {
        [PlayerCommand]
        public void Inventory(Player player, IDialogService dialogService, IEntityManager entityManager)
        {
            CharacterComponent characterComponent = player.GetComponent<CharacterComponent>();
            if (characterComponent != null)
            {
                Inventory characterInventory = characterComponent.CharacterPlayingAs.GetCharacterInventory();
                InventoryDialog.Open(player, characterInventory, dialogService, entityManager);
            }
        }
    }
}
