using OpenRP.GameMode.Features.Chat.Helpers;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.Chat.Systems
{
    public class ChatSystem : ISystem
    {
        [Event]
        public bool OnPlayerText(Player player, string text, IEntityManager entityManager)
        {
            player.SendTalkMessage(entityManager, text);

            return false;
        }
    }
}
