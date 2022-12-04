using OpenRP.GameMode.Data.Models;
using SampSharp.Entities;

namespace OpenRP.GameMode.Features.Accounts.Components
{
    public class AccountComponent : Component
    {
        public Account Account { get; set; }
        public bool LoggedIn { get; set; }
    }
}
