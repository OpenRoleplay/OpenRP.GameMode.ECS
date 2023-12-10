using OpenRP.GameMode.Features.Accounts.Components;
using OpenRP.GameMode.Features.Characters.Helpers;
using OpenRP.GameMode.Features.Chat.Constants;
using OpenRP.GameMode.Features.Chat.Enums;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using System;
using System.Text;
using System.Text.RegularExpressions;

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
                        player.SendTalkMessage(entityManager, text);
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


        public static void SendTalkMessage(this Player player, IEntityManager entityManager, string text)
        {
            CharacterComponent characterComponent = player.GetComponent<CharacterComponent>();

            foreach (Player foreachPlayer in entityManager.GetComponents<Player>())
            {
                string new_text = text;

                float distance = foreachPlayer.GetDistanceFromPoint(player.Position);

                if (distance <= 5.0 && foreachPlayer.VirtualWorld == player.VirtualWorld)
                {
                    Color min_color = Color.FromString("F5F5F5", ColorFormat.RGB);
                    Color max_color = Color.FromString("C0C0C0", ColorFormat.RGB);
                    Color result_color;

                    if (distance >= 3.0)
                    {
                        Random change_words_perc = new Random();
                        if (change_words_perc.Next(0, 100) <= 5)
                        {
                            new_text = Regex.Replace(new_text, "([Ff])at(?!tie)", "$1attie");
                            new_text = Regex.Replace(new_text, "[Gg]reat(?! [pP]olzin(?:i)?)", "Great Polzini");
                            new_text = Regex.Replace(new_text, "([Kk])im ([Jj])ong ([Uu])n", "$1ir $2ong $3n");
                            new_text = Regex.Replace(new_text, "([Kk])im", "$1ir");
                        }

                        new_text = new_text.Muffle(distance, 3, 5);

                        //float distance_in_perc = (100 / 2) * distance;

                        //double resultRed = min_color.R + distance_in_perc * (max_color.R - min_color.R);
                        //double resultGreen = min_color.G + distance_in_perc * (max_color.G - min_color.G);
                        //double resultBlue = min_color.B + distance_in_perc * (max_color.B - min_color.B);

                        //result_color = new Color(Convert.ToByte(resultRed), Convert.ToByte(resultGreen), Convert.ToByte(resultBlue));

                        result_color = min_color;
                    }
                    else
                    {
                        result_color = min_color;
                    }

                    StringBuilder sb = new StringBuilder();

                    sb.Append(String.Format("{0}{1} ", result_color.ToString(), characterComponent.CharacterPlayingAs.GetCharacterName()));

                    if (!String.IsNullOrEmpty(characterComponent.CharacterPlayingAs.Accent))
                    {
                        sb.Append(String.Format("[{0} accent] ", characterComponent.CharacterPlayingAs.Accent));
                    }

                    sb.Append(String.Format("says: {0}", new_text));

                    player.SendClientMessage(sb.ToString());
                }
            }
        }


        public static string Muffle(this string text, float percentage)
        {
            char[] char_array = text.ToCharArray();

            Random random_percentage = new Random();

            for (int i = 0; i < char_array.Length; i++)
            {
                if (char_array[i] != ' ')
                {
                    if (random_percentage.Next(0, 100) <= percentage)
                    {
                        char_array[i] = '.';
                    }
                }
            }

            return new string(char_array);
        }

        public static string Muffle(this string text, float player_distance, float acceptable_distance = 3.0f, float max_distance = 5.0f)
        {
            if (player_distance >= acceptable_distance)
            {
                float percentage = (30 / (max_distance - acceptable_distance) * (player_distance - acceptable_distance));

                return text.Muffle(percentage);
            }
            return text;
        }
    }
}
