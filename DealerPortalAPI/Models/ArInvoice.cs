using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class ArInvoice
    {
        public string Customer { get; set; }
        public string Invoice { get; set; }
        public string DocumentType { get; set; }
        public decimal NextPaymEntry { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string SalesOrder { get; set; }
        public string CustomerPoNumber { get; set; }
        public string Salesperson { get; set; }
        public string Branch { get; set; }
        public string Area { get; set; }
        public string TermsCode { get; set; }
        public decimal OrigDiscValue { get; set; }
        public decimal InvoiceBal1 { get; set; }
        public decimal InvoiceBal2 { get; set; }
        public decimal InvoiceBal3 { get; set; }
        public decimal InvoiceYear { get; set; }
        public decimal InvoiceMonth { get; set; }
        public decimal YearInvBalZero { get; set; }
        public decimal MonthInvBalZero { get; set; }
        public string LastDelNote { get; set; }
        public string StoreNumber { get; set; }
        public string ProofOfDelivery { get; set; }
        public DateTime? PodEntryDate { get; set; }
        public string PodReference { get; set; }
        public decimal CurrencyValue { get; set; }
        public string PostCurrency { get; set; }
        public decimal ConvRate { get; set; }
        public string MulDiv { get; set; }
        public string AccountCur { get; set; }
        public decimal AccConvRate { get; set; }
        public string AccMulDiv { get; set; }
        public string TriangCurrency { get; set; }
        public decimal TriangRate { get; set; }
        public string TriangMulDiv { get; set; }
        public string RetentionInv { get; set; }
        public string TaxStatus { get; set; }
        public decimal TaxPortion { get; set; }
        public string FixExchangeRate { get; set; }
        public decimal NextRevalNo { get; set; }
        public string TaxCode { get; set; }
        public decimal DiscBal { get; set; }
        public string PaymentRunFlag { get; set; }
        public string CollectionRunFlag { get; set; }
        public string InvoicePdcFlag { get; set; }
        public decimal OrigInvRate { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual ArCustomer CustomerNavigation { get; set; }
        public virtual SalSalesperson SalSalesperson { get; set; }
        public virtual SorMaster SalesOrderNavigation { get; set; }
    }
}
