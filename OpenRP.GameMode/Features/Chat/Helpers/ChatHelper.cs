using OpenRP.GameMode.Features.Chat.Constants;
using OpenRP.GameMode.Features.Chat.Enums;
using SampSharp.Entities.SAMP;
using System;

namespace OpenRP.GameMode.Features.Chat.Helpers
{
    public static class ChatHelper
    {
        public static void SendPlayerInfoMessage(this Player player, PlayerInfoMessageType type, string text)
        {
            string message = ChatHelper.ReturnPlayerInfoMessage(type, text);

            player.SendClientMessage(message);
        }

        public static string ReturnPlayerInfoMessage(PlayerInfoMessageType type, string text)
        {
            string message = String.Empty;

            switch (type)
            {
                case PlayerInfoMessageType.INFO:
                    message = String.Format("{0}{1}", PlayerInfoMessagePrefix.INFO, text);
                    break;
                case PlayerInfoMessageType.ERROR:
                    message = String.Format("{0}{1}", PlayerInfoMessagePrefix.ERROR, text);
                    break;
                case PlayerInfoMessageType.SYNTAX:
                    message = String.Format("{0}{1}", PlayerInfoMessagePrefix.SYNTAX, text);
                    break;
            }

            return message;
        }
    }
}
