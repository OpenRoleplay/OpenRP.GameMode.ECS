using OpenRP.GameMode.Data.Models;
using SampSharp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.Characters.Components
{
    public class CharacterCreationComponent : Component
    {
        public Character CreatingCharacter { get; set; }

        public CharacterCreationComponent()
        {
            CreatingCharacter = new Character();
        }
    }
}
