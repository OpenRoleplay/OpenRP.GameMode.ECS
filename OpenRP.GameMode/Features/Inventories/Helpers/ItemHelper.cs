using OpenRP.GameMode.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.Inventories.Helpers
{
    public static class ItemHelper
    {
        public static bool IsItemWallet(this Item item)
        {
            if (item.Type.Name == "Wallet")
            {
                return true;
            }
            return false;
        }

        public static bool IsItemInventory(this Item item)
        {
            return item.IsItemWallet();
        }

    }
}
