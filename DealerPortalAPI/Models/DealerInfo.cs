using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class DealerInfo
    {
        public string DealerId { get; set; }
        public string Name { get; set; }
        public string SalesRep { get; set; }
        public string PrimaryEmail { get; set; }
        public string ContactEmail { get; set; }
        public Address SoldToAddress { get; set; }
        public List<Address> ShipToAddresses { get; set; }
        public string CSSpecialist { get; set; }
    }

    public partial class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }
}
