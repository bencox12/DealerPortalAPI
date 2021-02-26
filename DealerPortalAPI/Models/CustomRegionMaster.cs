using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class CustomRegionMaster
    {
        public CustomRegionMaster()
        {
            CustomRepMaster = new HashSet<CustomRepMaster>();
        }

        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public virtual ICollection<CustomRepMaster> CustomRepMaster { get; set; }
    }
}
