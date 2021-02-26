using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class ArCustomer1
    {
        public string Customer { get; set; }
        public string Dlevel { get; set; }
        public string Insurable { get; set; }
        public decimal? Dunsnumber { get; set; }
        public byte[] TimeStamp { get; set; }
        public string CustomerNameLine2 { get; set; }
        public string CustomerLine3 { get; set; }
        public string Comments { get; set; }
        public string ShippingAttTo { get; set; }
        public string ShipToPhone { get; set; }
        public string AttentionTo { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
