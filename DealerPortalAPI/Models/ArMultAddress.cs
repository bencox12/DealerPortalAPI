using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class ArMultAddress
    {
        public string Customer { get; set; }
        public string AddrCode { get; set; }
        public string ShipToName { get; set; }
        public string ShipToAddr1 { get; set; }
        public string ShipToAddr2 { get; set; }
        public string ShipToAddr3 { get; set; }
        public string ShipToAddr3Loc { get; set; }
        public string ShipToAddr4 { get; set; }
        public string ShipToAddr5 { get; set; }
        public string ShipPostalCode { get; set; }
        public decimal ShipToGpsLat { get; set; }
        public decimal ShipToGpsLong { get; set; }
        public string Area { get; set; }
        public string State { get; set; }
        public string CountyZip { get; set; }
        public string City { get; set; }
        public string RouteCode { get; set; }
        public decimal RouteDistance { get; set; }
        public string Nationality { get; set; }
        public string GeographicArea { get; set; }
        public string TaxRegnNum { get; set; }
        public string LanguageCode { get; set; }
        public string ShippingLocation { get; set; }
        public string DeliveryTerms { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual ArCustomer CustomerNavigation { get; set; }
    }
}
