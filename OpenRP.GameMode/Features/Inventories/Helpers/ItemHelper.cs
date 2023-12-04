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
            if (item.UseType.Name == "Wallet")
            {
                return true;
            }
            return false;
        }
        public static bool IsItemSkin(this Item item)
        {
            if (item.UseType.Name == "Skin")
            {
                return true;
            }
            return false;
        }
        public static bool IsItemAttachment(this Item item)
        {
            if (item.UseType.Name == "Attachment")
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
