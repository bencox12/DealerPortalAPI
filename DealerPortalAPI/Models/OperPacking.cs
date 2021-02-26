using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class OperPacking
    {
        public DateTime? Date { get; set; }
        public int? PayPeriod { get; set; }
        public string SalesOrder { get; set; }
        public string ModelNo { get; set; }
        public int? Qty { get; set; }
        public bool? Option1 { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public int? DepartmentId { get; set; }
        public int LablSerNo { get; set; }
        public string LablStatus { get; set; }
        public int? EmployeeId { get; set; }
        public bool? Delete { get; set; }
        public bool? Option2 { get; set; }
        public bool? Option3 { get; set; }
        public string LineNum { get; set; }
    }
}
