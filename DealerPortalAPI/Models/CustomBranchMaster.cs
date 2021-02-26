using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class CustomBranchMaster
    {
        public CustomBranchMaster()
        {
            CustomRepMaster = new HashSet<CustomRepMaster>();
        }

        public int BranchId { get; set; }
        public string BranchNumber { get; set; }
        public int RegionId { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<CustomRepMaster> CustomRepMaster { get; set; }
    }
}
