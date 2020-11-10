using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class ShipMaster
    {
        public int DocumentId { get; set; }
        public DateTime? DateStamp { get; set; }
        public int? Trailer { get; set; }
        public string Carrier { get; set; }
        public int? TotalQuantity { get; set; }
        public int? TotalQtyLoaded { get; set; }
        public int? Status { get; set; }
        public string UserId { get; set; }
        public string ComputerId { get; set; }
        public int? Dock { get; set; }
        public int? TrailerQty { get; set; }
    }
}
