using OpenRP.GameMode.Data.Models;
using SampSharp.Entities;

namespace OpenRP.GameMode.Features.Accounts.Components
{
    public class CharacterComponent : Component
    {
        public Character CharacterPlayingAs { get; set; }

        public CharacterComponent()
        {
            CharacterPlayingAs = null;
        }
    }
}
