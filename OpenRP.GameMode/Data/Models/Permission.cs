using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Data.Models
{
    public class Permission
    {
        public ulong Id { get; set; }
        public string Command { get; set; }

        #region PermissionGroupId
        public ulong PermissionGroupId { get; set; }
        public PermissionGroup PermissionGroup { get; set; }
        #endregion
    }
}
