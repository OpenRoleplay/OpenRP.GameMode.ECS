using OpenRP.GameMode.Features.Chat.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Helpers
{
    public class DialogHelper
    {
        private const string Prefix = ChatColor.White + "Open Roleplay" + ChatColor.CornflowerBlue + " | " + ChatColor.White;
        private const string Separator = ChatColor.CornflowerBlue + " | " + ChatColor.White;
        public const string Cancel = "Cancel";
        public const string Quit = "Quit";
        public const string Previous = "Previous";
        public const string Next = "Next";
        public const string Retry = "Retry";
        public const string Yes = "Yes";
        public const string No = "No";

        public static string GetTitle(params string[] strings)
        {
            return String.Format("{0}{1}", Prefix, String.Join(Separator, strings));
        }
    }
}
