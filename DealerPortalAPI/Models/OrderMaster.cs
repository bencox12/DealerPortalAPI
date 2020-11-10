using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class OrderMaster
    {
        public int Ponum { get; set; }
        public string CustomerPo { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal Poamount { get; set; }
        public bool PoamountConfirmed { get; set; }
        public decimal FreightCharges { get; set; }
        public decimal TaxCharges { get; set; }
        public string Qs { get; set; }
        public string SubmitterEmail { get; set; }
        public int Status { get; set; }
        public string Branch { get; set; }
        public string State { get; set; }
        public string DealerCode { get; set; }
        public string DealerEmail { get; set; }
        public string RepCode { get; set; }
        public string RepEmail { get; set; }
        public string SpiffPayee { get; set; }
        public bool AutoSpiff { get; set; }
        public string SpiffType { get; set; }
        public string SaleSupportId { get; set; }
        public string SaleSupportEmail { get; set; }
        public string Fc { get; set; }
        public string OrderType { get; set; }
        public string ArTerms { get; set; }
        public string Sq { get; set; }
        public string Spr { get; set; }
        public string Sr { get; set; }
        public string Gpo { get; set; }
        public string SalesOrder { get; set; }
        public string TagLines { get; set; }
        public string Sitags { get; set; }
        public string Aitags { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? ArriveDate { get; set; }
        public string BillToAddressLine1 { get; set; }
        public string BillToAddressLine2 { get; set; }
        public string BillToCity { get; set; }
        public string BillToProvinceState { get; set; }
        public string BillToPostalZip { get; set; }
        public string BillToCountry { get; set; }
        public string BillToTelephone { get; set; }
        public string ShipToName { get; set; }
        public string ShipToAddressLine1 { get; set; }
        public string ShipToAddressLine2 { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToProvinceState { get; set; }
        public string ShipToPostalZip { get; set; }
        public string ShipToCountry { get; set; }
        public string ShipToTelephone { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Discount { get; set; }
        public decimal? FreightCharges1 { get; set; }
        public decimal? InstallationIns { get; set; }
        public decimal? CartonCharges { get; set; }
        public decimal? Surcharge { get; set; }
        public decimal? Assembled { get; set; }
        public decimal? InsideDelivery { get; set; }
        public decimal? StorageFees { get; set; }
        public decimal? TxmasAdmin { get; set; }
        public decimal? TxmasRebate { get; set; }
        public string OrderSource { get; set; }
        public DateTime? CleanOrderDate { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
