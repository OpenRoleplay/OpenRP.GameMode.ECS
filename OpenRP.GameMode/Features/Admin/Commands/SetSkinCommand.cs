using OpenRP.GameMode.Data;
using OpenRP.GameMode.Data.Models;
using OpenRP.GameMode.Features.Accounts.Components;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Entities.SAMP.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.Admin.Commands
{
    public class SetSkinCommand : ISystem
    {
        [PlayerCommand]
        public void SetSkin(Player player, int skin_id)
        {
            CharacterComponent characterComponent = player.GetComponent<CharacterComponent>();

            if (characterComponent != null)
            {
                using (var context = new DataContext())
                {
                    Character character = context.Characters.Find(characterComponent.CharacterPlayingAs.Id);

                    player.Skin = character.Skin = characterComponent.CharacterPlayingAs.Skin = skin_id;
                    context.SaveChanges();
                }
            }
        }
    }
}
