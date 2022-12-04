using OpenRP.GameMode.Features.Accounts.Components;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;

namespace OpenRP.GameMode.Features.MainMenu.Systems
{
    public class AccountSystem : ISystem
    {

        [Event]
        public void OnPlayerConnect(Player player, IDialogService dialogService)
        {
            player.AddComponent<CharacterComponent>();
        }
    }
}
