using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class SorMaster
    {
        public SorMaster()
        {
            ArInvoice = new HashSet<ArInvoice>();
            SorDetail = new HashSet<SorDetail>();
            WipMaster = new HashSet<WipMaster>();
        }

        public string SalesOrder { get; set; }
        public decimal NextDetailLine { get; set; }
        public string OrderStatus { get; set; }
        public string ActiveFlag { get; set; }
        public string CancelledFlag { get; set; }
        public string DocumentType { get; set; }
        public string Customer { get; set; }
        public string Salesperson { get; set; }
        public string CustomerPoNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? EntrySystemDate { get; set; }
        public DateTime? ReqShipDate { get; set; }
        public DateTime? DateLastDocPrt { get; set; }
        public string ShippingInstrs { get; set; }
        public string ShippingInstrsCod { get; set; }
        public string AltShipAddrFlag { get; set; }
        public decimal InvoiceCount { get; set; }
        public string InvTermsOverride { get; set; }
        public string CreditAuthority { get; set; }
        public string Branch { get; set; }
        public string SpecialInstrs { get; set; }
        public string EntInvoice { get; set; }
        public DateTime? EntInvoiceDate { get; set; }
        public decimal DiscPct1 { get; set; }
        public decimal DiscPct2 { get; set; }
        public decimal DiscPct3 { get; set; }
        public string OrderType { get; set; }
        public string TaxExemptFlag { get; set; }
        public string Area { get; set; }
        public string TaxExemptNumber { get; set; }
        public string TaxExemptOverride { get; set; }
        public string CashCredit { get; set; }
        public string Warehouse { get; set; }
        public string LastInvoice { get; set; }
        public string ScheduledOrdFlag { get; set; }
        public string GstExemptFlag { get; set; }
        public string GstExemptNum { get; set; }
        public string GstExemptOride { get; set; }
        public string IbtFlag { get; set; }
        public string OrdAcknwPrinted { get; set; }
        public string DetCustMvmtReqd { get; set; }
        public string DocumentFormat { get; set; }
        public string FixExchangeRate { get; set; }
        public decimal ExchangeRate { get; set; }
        public string MulDiv { get; set; }
        public string Currency { get; set; }
        public string GstDeduction { get; set; }
        public string OrderStatusFail { get; set; }
        public string ConsolidatedOrder { get; set; }
        public DateTime? CreditedInvDate { get; set; }
        public string Job { get; set; }
        public string SerialisedFlag { get; set; }
        public string CounterSalesFlag { get; set; }
        public string Nationality { get; set; }
        public string DeliveryTerms { get; set; }
        public decimal TransactionNature { get; set; }
        public decimal TransportMode { get; set; }
        public decimal ProcessFlag { get; set; }
        public string JobsExistFlag { get; set; }
        public string AlternateKey { get; set; }
        public string LastOperator { get; set; }
        public string HierarchyFlag { get; set; }
        public string DepositFlag { get; set; }
        public string EdiSource { get; set; }
        public string DeliveryNote { get; set; }
        public string Operator { get; set; }
        public string LineComp { get; set; }
        public decimal CaptureHh { get; set; }
        public decimal CaptureMm { get; set; }
        public DateTime? LastDelNote { get; set; }
        public decimal TimeDelPrtedHh { get; set; }
        public decimal TimeDelPrtedMm { get; set; }
        public decimal TimeInvPrtedHh { get; set; }
        public decimal TimeInvPrtedMm { get; set; }
        public DateTime? DateLastInvPrt { get; set; }
        public string Salesperson2 { get; set; }
        public string Salesperson3 { get; set; }
        public string Salesperson4 { get; set; }
        public decimal CommissionSales1 { get; set; }
        public decimal CommissionSales2 { get; set; }
        public decimal CommissionSales3 { get; set; }
        public decimal CommissionSales4 { get; set; }
        public decimal TimeTakenToAdd { get; set; }
        public decimal TimeTakenToChg { get; set; }
        public string FaxInvInBatch { get; set; }
        public string InterWhSale { get; set; }
        public string SourceWarehouse { get; set; }
        public string TargetWarehouse { get; set; }
        public string DispatchesMade { get; set; }
        public string LiveDispExist { get; set; }
        public decimal NumDispatches { get; set; }
        public string CustomerName { get; set; }
        public string ShipAddress1 { get; set; }
        public string ShipAddress2 { get; set; }
        public string ShipAddress3 { get; set; }
        public string ShipAddress3Loc { get; set; }
        public string ShipAddress4 { get; set; }
        public string ShipAddress5 { get; set; }
        public string ShipPostalCode { get; set; }
        public decimal ShipToGpsLat { get; set; }
        public decimal ShipToGpsLong { get; set; }
        public string State { get; set; }
        public string CountyZip { get; set; }
        public string ExtendedTaxCode { get; set; }
        public string MultiShipCode { get; set; }
        public string WebCreated { get; set; }
        public string Quote { get; set; }
        public decimal QuoteVersion { get; set; }
        public string GtrReference { get; set; }
        public string NonMerchFlag { get; set; }
        public string Email { get; set; }
        public string User1 { get; set; }
        public string CompanyTaxNo { get; set; }
        public string TpmPickupFlag { get; set; }
        public string TpmEvaluatedFlag { get; set; }
        public string StandardComment { get; set; }
        public string DetailStatus { get; set; }
        public string SalesOrderSource { get; set; }
        public string SalesOrderSrcDesc { get; set; }
        public string LanguageCode { get; set; }
        public string ShippingLocation { get; set; }
        public string IncludeInMrp { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual WipMaster JobNavigation { get; set; }
        public virtual ICollection<ArInvoice> ArInvoice { get; set; }
        public virtual ICollection<SorDetail> SorDetail { get; set; }
        public virtual ICollection<WipMaster> WipMaster { get; set; }
    }
}
