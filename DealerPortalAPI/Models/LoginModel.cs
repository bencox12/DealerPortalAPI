using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DealerPortalAPI.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirm { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Message { get; set; }
    }
}
