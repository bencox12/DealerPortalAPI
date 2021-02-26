using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class CustomInsideSalesRep
    {
        public CustomInsideSalesRep()
        {
            CustomRepMaster = new HashSet<CustomRepMaster>();
        }

        public int InsideSalesRepId { get; set; }
        public string InsideSalesRepName { get; set; }
        public string InsideSalesRepEmpId { get; set; }
        public string InsideSalesRepEmailAddr { get; set; }
        public decimal? InsideSalesRepBonusP { get; set; }
        public string Active { get; set; }

        public virtual ICollection<CustomRepMaster> CustomRepMaster { get; set; }
    }
}
