using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class CustomRepMaster
    {
        public int SalesPersonId { get; set; }
        public string SalesPersonName { get; set; }
        public string SalesPersonShortName { get; set; }
        public string RepCode { get; set; }
        public int RegionId { get; set; }
        public int BranchId { get; set; }
        public int? TerritoryMgrId { get; set; }
        public int? TerritoryId { get; set; }
        public int Rsdid { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string Active { get; set; }
        public DateTime? TimeStamp { get; set; }
        public int? InsideSalesRepId { get; set; }
        public string IncludeSales { get; set; }
        public int GovRsdId { get; set; }
        public string Grpid { get; set; }

        public virtual CustomBranchMaster Branch { get; set; }
        public virtual CustomInsideSalesRep InsideSalesRep { get; set; }
        public virtual CustomRegionMaster Region { get; set; }
        public virtual CustomRsdmaster Rsd { get; set; }
        public virtual CustomTerritoryMaster Territory { get; set; }
        public virtual CustomTerritoryMgrMaster TerritoryMgr { get; set; }
    }
}
