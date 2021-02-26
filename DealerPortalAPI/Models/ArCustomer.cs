using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class ArCustomer
    {
        public ArCustomer()
        {
            ArInvoice = new HashSet<ArInvoice>();
            ArMasterSub = new HashSet<ArMasterSub>();
            ArMultAddress = new HashSet<ArMultAddress>();
            SorMaster = new HashSet<SorMaster>();
            WipMaster = new HashSet<WipMaster>();
        }

        public string Customer { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string ExemptFinChg { get; set; }
        public string MaintHistory { get; set; }
        public string CustomerType { get; set; }
        public string MasterAccount { get; set; }
        public string StoreNumber { get; set; }
        public string PrtMasterAdd { get; set; }
        public string CreditStatus { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal InvoiceCount { get; set; }
        public string Salesperson { get; set; }
        public string Salesperson1 { get; set; }
        public string Salesperson2 { get; set; }
        public string Salesperson3 { get; set; }
        public string PriceCode { get; set; }
        public string CustomerClass { get; set; }
        public string Branch { get; set; }
        public string TermsCode { get; set; }
        public string InvDiscCode { get; set; }
        public string BalanceType { get; set; }
        public string Area { get; set; }
        public string LineDiscCode { get; set; }
        public string TaxStatus { get; set; }
        public string TaxExemptNumber { get; set; }
        public string SpecialInstrs { get; set; }
        public string PriceCategoryTable { get; set; }
        public DateTime? DateLastSale { get; set; }
        public DateTime? DateLastPay { get; set; }
        public decimal OutstOrdVal { get; set; }
        public decimal NumOutstOrd { get; set; }
        public string Telephone { get; set; }
        public string Contact { get; set; }
        public string AddTelephone { get; set; }
        public string Fax { get; set; }
        public string Telex { get; set; }
        public string TelephoneExtn { get; set; }
        public string Currency { get; set; }
        public string UserField1 { get; set; }
        public decimal UserField2 { get; set; }
        public string GstExemptFlag { get; set; }
        public string GstExemptNum { get; set; }
        public string GstLevel { get; set; }
        public string DetailMoveReqd { get; set; }
        public string InterfaceFlag { get; set; }
        public string ContractPrcReqd { get; set; }
        public string BuyingGroup1 { get; set; }
        public string BuyingGroup2 { get; set; }
        public string BuyingGroup3 { get; set; }
        public string BuyingGroup4 { get; set; }
        public string BuyingGroup5 { get; set; }
        public string StatementReqd { get; set; }
        public string BackOrdReqd { get; set; }
        public string ShippingInstrs { get; set; }
        public string ShippingInstrsCod { get; set; }
        public string StateCode { get; set; }
        public DateTime? DateCustAdded { get; set; }
        public string StockInterchange { get; set; }
        public string MaintLastPrcPaid { get; set; }
        public string IbtCustomer { get; set; }
        public string SoDefaultDoc { get; set; }
        public string CounterSlsOnly { get; set; }
        public string PaymentStatus { get; set; }
        public string Nationality { get; set; }
        public decimal HighestBalance { get; set; }
        public string CustomerOnHold { get; set; }
        public string InvCommentCode { get; set; }
        public string EdiSenderCode { get; set; }
        public decimal RelOrdOsValue { get; set; }
        public string EdiFlag { get; set; }
        public string SoDefaultType { get; set; }
        public string Email { get; set; }
        public string ApplyOrdDisc { get; set; }
        public string ApplyLineDisc { get; set; }
        public string FaxInvoices { get; set; }
        public string FaxStatements { get; set; }
        public decimal HighInvDays { get; set; }
        public string HighInv { get; set; }
        public string DocFax { get; set; }
        public string DocFaxContact { get; set; }
        public string SoldToAddr1 { get; set; }
        public string SoldToAddr2 { get; set; }
        public string SoldToAddr3 { get; set; }
        public string SoldToAddr3Loc { get; set; }
        public string SoldToAddr4 { get; set; }
        public string SoldToAddr5 { get; set; }
        public string SoldPostalCode { get; set; }
        public decimal SoldToGpsLat { get; set; }
        public decimal SoldToGpsLong { get; set; }
        public string ShipToAddr1 { get; set; }
        public string ShipToAddr2 { get; set; }
        public string ShipToAddr3 { get; set; }
        public string ShipToAddr3Loc { get; set; }
        public string ShipToAddr4 { get; set; }
        public string ShipToAddr5 { get; set; }
        public string ShipPostalCode { get; set; }
        public decimal ShipToGpsLat { get; set; }
        public decimal ShipToGpsLong { get; set; }
        public string State { get; set; }
        public string CountyZip { get; set; }
        public string City { get; set; }
        public string State1 { get; set; }
        public string CountyZip1 { get; set; }
        public string City1 { get; set; }
        public string DefaultOrdType { get; set; }
        public string PoNumberMandatory { get; set; }
        public string CreditCheckFlag { get; set; }
        public string CompanyTaxNumber { get; set; }
        public string DeliveryTerms { get; set; }
        public decimal TransactionNature { get; set; }
        public string DeliveryTermsC { get; set; }
        public decimal TransactionNatureC { get; set; }
        public string RouteCode { get; set; }
        public string FaxQuotes { get; set; }
        public decimal RouteDistance { get; set; }
        public string TpmCustomerFlag { get; set; }
        public string SalesWarehouse { get; set; }
        public string TpmPricingFlag { get; set; }
        public string ArStatementNo { get; set; }
        public string TpmCreditCheck { get; set; }
        public string WholeOrderShipFlag { get; set; }
        public decimal MinimumOrderValue { get; set; }
        public string MinimumOrderChgCod { get; set; }
        public string UkVatFlag { get; set; }
        public string UkCurrency { get; set; }
        public string LanguageCode { get; set; }
        public string ShippingLocation { get; set; }
        public string AltMethodFlag { get; set; }
        public string SalesAllowed { get; set; }
        public string UnappPayAllowed { get; set; }
        public string PaymentsAllowed { get; set; }
        public string QuotesAllowed { get; set; }
        public string CrNotesAllowed { get; set; }
        public string DrNotesAllowed { get; set; }
        public string QueryAllowed { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual SalSalesperson SalSalesperson { get; set; }
        public virtual SalSalesperson SalSalesperson1 { get; set; }
        public virtual SalSalesperson SalSalesperson2 { get; set; }
        public virtual SalSalesperson SalSalespersonNavigation { get; set; }
        public virtual ICollection<ArInvoice> ArInvoice { get; set; }
        public virtual ICollection<ArMasterSub> ArMasterSub { get; set; }
        public virtual ICollection<ArMultAddress> ArMultAddress { get; set; }
        public virtual ICollection<SorMaster> SorMaster { get; set; }
        public virtual ICollection<WipMaster> WipMaster { get; set; }
    }
}
