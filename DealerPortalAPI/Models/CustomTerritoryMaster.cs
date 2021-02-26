using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class CustomTerritoryMaster
    {
        public CustomTerritoryMaster()
        {
            CustomRepMaster = new HashSet<CustomRepMaster>();
        }

        public int TerritoryId { get; set; }
        public int RegionId { get; set; }
        public string TerritoryName { get; set; }

        public virtual ICollection<CustomRepMaster> CustomRepMaster { get; set; }
    }
}
