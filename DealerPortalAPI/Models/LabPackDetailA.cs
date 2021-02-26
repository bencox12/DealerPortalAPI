using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class LabPackDetailA
    {
        public string SalesOrder { get; set; }
        public int? SalesOrderLine { get; set; }
        public long LablSerNo { get; set; }
        public long? ShipmentNo { get; set; }
        public long? DeliveryNo { get; set; }
        public string LabPrintFlag { get; set; }
        public DateTime? LablPrintDate { get; set; }
        public string TrailerNo { get; set; }
        public string PrintedBy { get; set; }
        public string ProdModel { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public int? LablStatus { get; set; }
        public string JobNumber { get; set; }
        public string StockCode { get; set; }
        public string StockDescription { get; set; }
    }
}
