﻿using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class SalSalesperson
    {
        public SalSalesperson()
        {
            ArCustomerSalSalesperson = new HashSet<ArCustomer>();
            ArCustomerSalSalesperson1 = new HashSet<ArCustomer>();
            ArCustomerSalSalesperson2 = new HashSet<ArCustomer>();
            ArCustomerSalSalespersonNavigation = new HashSet<ArCustomer>();
            ArInvoice = new HashSet<ArInvoice>();
            SorMaster = new HashSet<SorMaster>();
        }

        public string Branch { get; set; }
        public string Salesperson { get; set; }
        public string Name { get; set; }
        public decimal SalesBudget1 { get; set; }
        public decimal SalesBudget2 { get; set; }
        public decimal SalesBudget3 { get; set; }
        public decimal SalesBudget4 { get; set; }
        public decimal SalesBudget5 { get; set; }
        public decimal SalesBudget6 { get; set; }
        public decimal SalesBudget7 { get; set; }
        public decimal SalesBudget8 { get; set; }
        public decimal SalesBudget9 { get; set; }
        public decimal SalesBudget10 { get; set; }
        public decimal SalesBudget11 { get; set; }
        public decimal SalesBudget12 { get; set; }
        public decimal SalesBudget13 { get; set; }
        public decimal SalesActual1 { get; set; }
        public decimal SalesActual2 { get; set; }
        public decimal SalesActual3 { get; set; }
        public decimal SalesActual4 { get; set; }
        public decimal SalesActual5 { get; set; }
        public decimal SalesActual6 { get; set; }
        public decimal SalesActual7 { get; set; }
        public decimal SalesActual8 { get; set; }
        public decimal SalesActual9 { get; set; }
        public decimal SalesActual10 { get; set; }
        public decimal SalesActual11 { get; set; }
        public decimal SalesActual12 { get; set; }
        public decimal SalesActual13 { get; set; }
        public decimal CommissionPct { get; set; }
        public string SalespersonColl { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<ArCustomer> ArCustomerSalSalesperson { get; set; }
        public virtual ICollection<ArCustomer> ArCustomerSalSalesperson1 { get; set; }
        public virtual ICollection<ArCustomer> ArCustomerSalSalesperson2 { get; set; }
        public virtual ICollection<ArCustomer> ArCustomerSalSalespersonNavigation { get; set; }
        public virtual ICollection<ArInvoice> ArInvoice { get; set; }
        public virtual ICollection<SorMaster> SorMaster { get; set; }
    }
}
