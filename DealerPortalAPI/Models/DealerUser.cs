using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class DealerUser
    {
        public int DealerUserId { get; set; }
        public int UserRoleId { get; set; }
        public string SysproDealerId { get; set; }
        public string SysproRepCode { get; set; }
        public string Name { get; set; }
        public string Permissions { get; set; }
        public string UserType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
