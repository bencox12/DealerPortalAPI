using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class CustomTerritoryMgrMaster
    {
        public CustomTerritoryMgrMaster()
        {
            CustomRepMaster = new HashSet<CustomRepMaster>();
        }

        public int TerritoryMgrId { get; set; }
        public string TerritoryMgrName { get; set; }
        public string Active { get; set; }
        public DateTime? TimeStamp { get; set; }

        public virtual ICollection<CustomRepMaster> CustomRepMaster { get; set; }
    }
}
