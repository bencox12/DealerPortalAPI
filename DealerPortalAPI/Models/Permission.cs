using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class Permission
    {
        public int PermissionId { get; set; }
        public string PermissionType { get; set; }
        public string Name { get; set; }
    }
}
