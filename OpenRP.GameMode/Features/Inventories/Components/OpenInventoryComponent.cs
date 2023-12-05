using OpenRP.GameMode.Data.Models;
using SampSharp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.Inventories.Components
{
    public class OpenInventoryComponent : Component
    {
        public Inventory openedInventory { get; set; }
        public List<InventoryItem> openedInventoryItems { get; set; }
        public InventoryItem selectedInventoryItem { get; set; }
        public List<string> actionsList { get; set; }

        public OpenInventoryComponent()
        {
            openedInventory = null;
            openedInventoryItems = null;
            selectedInventoryItem = null;
            actionsList = null;
        }
    }
}
