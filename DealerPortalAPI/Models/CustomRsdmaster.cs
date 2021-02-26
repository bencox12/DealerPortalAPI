using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class CustomRsdmaster
    {
        public CustomRsdmaster()
        {
            CustomRepMaster = new HashSet<CustomRepMaster>();
        }

        public int Rsdid { get; set; }
        public string Rsdname { get; set; }
        public string Active { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Email { get; set; }

        public virtual ICollection<CustomRepMaster> CustomRepMaster { get; set; }
    }
}
