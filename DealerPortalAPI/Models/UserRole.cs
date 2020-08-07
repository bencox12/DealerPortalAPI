using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public string RoleType { get; set; }
        public string Name { get; set; }
    }
}
