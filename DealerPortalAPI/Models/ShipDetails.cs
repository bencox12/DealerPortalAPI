using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class ShipDetails
    {
        public int DocumentId { get; set; }
        public string SalesOrder { get; set; }
        public int SalesOrderLine { get; set; }
        public string JobNumber { get; set; }
        public string StockCode { get; set; }
        public string StkDescription { get; set; }
        public int? Quantity { get; set; }
        public string Customer { get; set; }
        public string UserId { get; set; }
        public string ComputerId { get; set; }
    }
}
