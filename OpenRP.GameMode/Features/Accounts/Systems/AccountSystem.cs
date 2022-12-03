using OpenRP.GameMode.Definitions.Constants;
using OpenRP.GameMode.Features.Accounts.Components;
using OpenRP.GameMode.Features.Accounts.Helpers;
using OpenRP.GameMode.Features.MainMenu.Dialogs;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.MainMenu.Systems
{
    public class AccountSystem : ISystem
    {

        [Event]
        public void OnPlayerConnect(Player player, IDialogService dialogService)
        {
            player.AddComponent<AccountComponent>();
        }
    }
}
