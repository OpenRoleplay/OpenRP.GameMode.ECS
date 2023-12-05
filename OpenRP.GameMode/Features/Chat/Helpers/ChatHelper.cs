using OpenRP.GameMode.Features.Accounts.Components;
using OpenRP.GameMode.Features.Characters.Helpers;
using OpenRP.GameMode.Features.Chat.Constants;
using OpenRP.GameMode.Features.Chat.Enums;
using SampSharp.Entities;
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

        public static void SendPlayerChatMessage(this Player player, IEntityManager entityManager, PlayerChatMessageType type, string text)
        {

            CharacterComponent characterComponent = player.GetComponent<CharacterComponent>();

            if (characterComponent != null)
            {
                switch (type)
                {
                    case PlayerChatMessageType.OOC:
                        string CHAT_ACTION_OOC = String.Format("(( OOC | {0}: {1} ))", characterComponent.CharacterPlayingAs.GetCharacterName(), text);

                        foreach (Player foreachPlayer in entityManager.GetComponents<Player>())
                        {
                            foreachPlayer.SendClientMessage("{D3D3D3}" + CHAT_ACTION_OOC);
                        }

                        //DiscordBot.Functions.Messages.SendGeneralChatMessage(CHAT_ACTION_OOC);
                        break;
                    case PlayerChatMessageType.ME:
                        string CHAT_ACTION_ME = String.Format("{0}* {1} {2} *", "{F6A5FA}", characterComponent.CharacterPlayingAs.GetCharacterName(), text);

                        player.SendClientRangedMessage(entityManager, 20, CHAT_ACTION_ME);
                        break;
                    case PlayerChatMessageType.DO:
                        string CHAT_ACTION_DO = String.Format("{0}{1} (( {2} ))", "{F6A5FA}", text, characterComponent.CharacterPlayingAs.GetCharacterName());

                        player.SendClientRangedMessage(entityManager, 20, CHAT_ACTION_DO);
                        break;
                    case PlayerChatMessageType.AME:
                        string CHAT_ACTION_AME = String.Format("{0}* {1} {2} *", "{F6A5FA}", characterComponent.CharacterPlayingAs.GetCharacterName(), text);

                        player.SendClientMessage(CHAT_ACTION_AME);
                        player.SetChatBubble(CHAT_ACTION_AME, Color.White, 20, CHAT_ACTION_AME.Length * 60);
                        break;
                    case PlayerChatMessageType.TALK:
                        //player.SendTalkMessage(text);
                        break;
                }
            }
        }

        private static void SendClientRangedMessage(this Player player, IEntityManager entityManager, float range, string text)
        {
            foreach (Player foreachPlayer in entityManager.GetComponents<Player>())
            {
                if (foreachPlayer.IsInRangeOfPoint(range, player.Position) && player.VirtualWorld == foreachPlayer.VirtualWorld)
                {
                    foreachPlayer.SendClientMessage(text);
                }
            }
        }
    }
}
