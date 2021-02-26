using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DealerPortalAPI.Models
{
    public partial class SysproCompanyAContext : DbContext
    {
        public SysproCompanyAContext()
        {
        }

        public SysproCompanyAContext(DbContextOptions<SysproCompanyAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArCustomer> ArCustomer { get; set; }
        public virtual DbSet<ArCustomer1> ArCustomer1 { get; set; }
        public virtual DbSet<ArInvoice> ArInvoice { get; set; }
        public virtual DbSet<ArMasterSub> ArMasterSub { get; set; }
        public virtual DbSet<ArMultAddress> ArMultAddress { get; set; }
        public virtual DbSet<ArMultAddress1> ArMultAddress1 { get; set; }
        public virtual DbSet<SalSalesperson> SalSalesperson { get; set; }
        public virtual DbSet<SorDetail> SorDetail { get; set; }
        public virtual DbSet<SorMaster> SorMaster { get; set; }
        public virtual DbSet<WipMaster> WipMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArCustomer>(entity =>
            {
                entity.HasKey(e => e.Customer)
                    .HasName("ArCustomerKey");

                entity.HasIndex(e => new { e.Area, e.Customer })
                    .HasName("ArCustomerIdxArea")
                    .IsUnique();

                entity.HasIndex(e => new { e.Branch, e.Customer })
                    .HasName("ArCustomerIdxBranch")
                    .IsUnique();

                entity.HasIndex(e => new { e.CustomerClass, e.Customer })
                    .HasName("ArCustomerIdxClass")
                    .IsUnique();

                entity.HasIndex(e => new { e.EdiSenderCode, e.Customer })
                    .HasName("ArCustomerIdxEdi")
                    .IsUnique();

                entity.HasIndex(e => new { e.Name, e.Customer })
                    .HasName("ArCustomerIdxFullname")
                    .IsUnique();

                entity.HasIndex(e => new { e.Salesperson, e.Customer })
                    .HasName("ArCustomerIdxSlsp")
                    .IsUnique();

                entity.HasIndex(e => new { e.ShortName, e.Customer })
                    .HasName("ArCustomerIdxName")
                    .IsUnique();

                entity.HasIndex(e => new { e.Telephone, e.Customer })
                    .HasName("ArCustomerIdxPhone")
                    .IsUnique();

                entity.Property(e => e.Customer)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AddTelephone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AltMethodFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ApplyLineDisc)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ApplyOrdDisc)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ArStatementNo)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BackOrdReqd)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BalanceType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Branch)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BuyingGroup1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BuyingGroup2)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BuyingGroup3)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BuyingGroup4)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BuyingGroup5)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.City1)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyTaxNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContractPrcReqd)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CounterSlsOnly)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountyZip)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountyZip1)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CrNotesAllowed)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreditCheckFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreditLimit).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.CreditStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CustomerClass)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerOnHold)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CustomerType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DateCustAdded).HasColumnType("datetime");

                entity.Property(e => e.DateLastPay).HasColumnType("datetime");

                entity.Property(e => e.DateLastSale).HasColumnType("datetime");

                entity.Property(e => e.DefaultOrdType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DeliveryTerms)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DeliveryTermsC)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DetailMoveReqd)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DocFax)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DocFaxContact)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DrNotesAllowed)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EdiFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EdiSenderCode)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ExemptFinChg)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FaxInvoices)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FaxQuotes)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FaxStatements)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GstExemptFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GstExemptNum)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.GstLevel)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HighInv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HighInvDays).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.HighestBalance).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.IbtCustomer)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InterfaceFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InvCommentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InvDiscCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceCount).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.LanguageCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LineDiscCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaintHistory)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaintLastPrcPaid)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MasterAccount)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MinimumOrderChgCod)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.MinimumOrderValue).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumOutstOrd).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.OutstOrdVal).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.PaymentStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaymentsAllowed)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PoNumberMandatory)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PriceCategoryTable)
                    .IsRequired()
                    .HasMaxLength(260)
                    .IsUnicode(false);

                entity.Property(e => e.PriceCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PrtMasterAdd)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.QueryAllowed)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.QuotesAllowed)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RelOrdOsValue).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.RouteCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RouteDistance).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.SalesAllowed)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SalesWarehouse)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Salesperson)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salesperson1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salesperson2)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salesperson3)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShipPostalCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToAddr1)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToAddr2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToAddr3)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToAddr3Loc)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToAddr4)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToAddr5)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToGpsLat).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.ShipToGpsLong).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.ShippingInstrs)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingInstrsCod)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingLocation)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SoDefaultDoc)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SoDefaultType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SoldPostalCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SoldToAddr1)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SoldToAddr2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SoldToAddr3)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SoldToAddr3Loc)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SoldToAddr4)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SoldToAddr5)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SoldToGpsLat).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.SoldToGpsLong).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.SpecialInstrs)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.State1)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StatementReqd)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StockInterchange)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StoreNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TaxExemptNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TaxStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneExtn)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telex)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TermsCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TpmCreditCheck)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TpmCustomerFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TpmPricingFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransactionNature).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.TransactionNatureC).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.UkCurrency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UkVatFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UnappPayAllowed)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserField1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserField2).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.WholeOrderShipFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.SalSalesperson)
                    .WithMany(p => p.ArCustomerSalSalesperson)
                    .HasForeignKey(d => new { d.Branch, d.Salesperson })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_ArCustomer_SalSalesperson");

                entity.HasOne(d => d.SalSalespersonNavigation)
                    .WithMany(p => p.ArCustomerSalSalespersonNavigation)
                    .HasForeignKey(d => new { d.Branch, d.Salesperson1 })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_ArCustomer_SalSalesperson_1");

                entity.HasOne(d => d.SalSalesperson1)
                    .WithMany(p => p.ArCustomerSalSalesperson1)
                    .HasForeignKey(d => new { d.Branch, d.Salesperson2 })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_ArCustomer_SalSalesperson_2");

                entity.HasOne(d => d.SalSalesperson2)
                    .WithMany(p => p.ArCustomerSalSalesperson2)
                    .HasForeignKey(d => new { d.Branch, d.Salesperson3 })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_ArCustomer_SalSalesperson_3");
            });

            modelBuilder.Entity<ArCustomer1>(entity =>
            {
                entity.HasKey(e => e.Customer)
                    .HasName("ArCustomer+Key");

                entity.ToTable("ArCustomer+");

                entity.Property(e => e.Customer)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AttentionTo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerLine3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerNameLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dlevel)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dunsnumber)
                    .HasColumnName("DUNSNumber")
                    .HasColumnType("decimal(12, 0)");

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.Insurable)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingAttTo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ToDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ArInvoice>(entity =>
            {
                entity.HasKey(e => new { e.Customer, e.Invoice, e.DocumentType })
                    .HasName("ArInvoiceKey");

                entity.HasIndex(e => new { e.Invoice, e.Customer, e.DocumentType })
                    .HasName("ArInvoiceIdxInv")
                    .IsUnique();

                entity.Property(e => e.Customer)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Invoice)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AccConvRate).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.AccMulDiv)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AccountCur)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Branch)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CollectionRunFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConvRate).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.CurrencyValue).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.CustomerPoNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DiscBal).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.FixExchangeRate)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InvoiceBal1).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.InvoiceBal2).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.InvoiceBal3).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceMonth).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.InvoicePdcFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InvoiceYear).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.LastDelNote)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MonthInvBalZero).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.MulDiv)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NextPaymEntry).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.NextRevalNo).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.OrigDiscValue).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.OrigInvRate).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.PaymentRunFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PodEntryDate).HasColumnType("datetime");

                entity.Property(e => e.PodReference)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PostCurrency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProofOfDelivery)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RetentionInv)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SalesOrder)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salesperson)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StoreNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TaxCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxPortion).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.TaxStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TermsCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TriangCurrency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TriangMulDiv)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TriangRate).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.YearInvBalZero).HasColumnType("decimal(4, 0)");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.ArInvoice)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_ArInvoice_ArCustomer");

                entity.HasOne(d => d.SalesOrderNavigation)
                    .WithMany(p => p.ArInvoice)
                    .HasForeignKey(d => d.SalesOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_ArInvoice_SorMaster");

                entity.HasOne(d => d.SalSalesperson)
                    .WithMany(p => p.ArInvoice)
                    .HasForeignKey(d => new { d.Branch, d.Salesperson })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_ArInvoice_SalSalesperson");
            });

            modelBuilder.Entity<ArMasterSub>(entity =>
            {
                entity.HasKey(e => new { e.Customer, e.CustomerSub })
                    .HasName("ArMasterSubKey");

                entity.Property(e => e.Customer)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerSub)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.ArMasterSub)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_ArMasterSub_ArCustomer");
            });

            modelBuilder.Entity<ArMultAddress>(entity =>
            {
                entity.HasKey(e => new { e.Customer, e.AddrCode })
                    .HasName("ArMultAddressKey");

                entity.Property(e => e.Customer)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AddrCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountyZip)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DeliveryTerms)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GeographicArea)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RouteCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RouteDistance).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.ShipPostalCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToAddr1)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToAddr2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToAddr3)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToAddr3Loc)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToAddr4)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToAddr5)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToGpsLat).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.ShipToGpsLong).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.ShipToName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingLocation)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxRegnNum)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.ArMultAddress)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_ArMultAddress_ArCustomer");
            });

            modelBuilder.Entity<ArMultAddress1>(entity =>
            {
                entity.HasKey(e => new { e.Customer, e.AddrCode })
                    .HasName("ArMultAddress+Key");

                entity.ToTable("ArMultAddress+");

                entity.Property(e => e.Customer)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AddrCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MultiPhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToName2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingAttentionT)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<SalSalesperson>(entity =>
            {
                entity.HasKey(e => new { e.Branch, e.Salesperson })
                    .HasName("SalSalespersonKey");

                entity.Property(e => e.Branch)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CommissionPct).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalesActual1).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.SalesActual10).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.SalesActual11).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.SalesActual12).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.SalesActual13).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.SalesActual2).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.SalesActual3).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.SalesActual4).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.SalesActual5).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.SalesActual6).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.SalesActual7).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.SalesActual8).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.SalesActual9).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.SalesBudget1).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.SalesBudget10).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.SalesBudget11).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.SalesBudget12).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.SalesBudget13).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.SalesBudget2).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.SalesBudget3).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.SalesBudget4).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.SalesBudget5).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.SalesBudget6).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.SalesBudget7).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.SalesBudget8).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.SalesBudget9).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.SalespersonColl)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<SorDetail>(entity =>
            {
                entity.HasKey(e => new { e.SalesOrder, e.SalesOrderLine })
                    .HasName("SorDetailKey");

                entity.HasIndex(e => new { e.MhierarchyJob, e.SalesOrder, e.SalesOrderLine })
                    .HasName("SorDetailIdxHier")
                    .IsUnique();

                entity.HasIndex(e => new { e.MstockCode, e.SalesOrder, e.SalesOrderLine })
                    .HasName("SorDetailIdxStk")
                    .IsUnique();

                entity.HasIndex(e => new { e.SalesOrder, e.SalesOrderInitLine, e.SalesOrderLine })
                    .HasName("SorDetailIdxInit")
                    .IsUnique();

                entity.HasIndex(e => new { e.SalesOrderDetStat, e.SalesOrder, e.SalesOrderLine })
                    .HasName("SorDetailIdxDetStat")
                    .IsUnique();

                entity.HasIndex(e => new { e.McreditOrderNo, e.McreditOrderLine, e.SalesOrder, e.SalesOrderLine })
                    .HasName("SorDetailIdxCredited")
                    .IsUnique();

                entity.Property(e => e.SalesOrder)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SalesOrderLine).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.CreditReason)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.FixedQtyPer).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.FixedQtyPerFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IncludeInMrp)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LibraryCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LineType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MabcApplied)
                    .IsRequired()
                    .HasColumnName("MAbcApplied")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MallocStatSched)
                    .IsRequired()
                    .HasColumnName("MAllocStatSched")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaltUomUnitQ)
                    .IsRequired()
                    .HasColumnName("MAltUomUnitQ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialAllocLine)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MbackOrderQty)
                    .HasColumnName("MBackOrderQty")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Mbin)
                    .IsRequired()
                    .HasColumnName("MBin")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MbomFlag)
                    .IsRequired()
                    .HasColumnName("MBomFlag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MbuyingGroup)
                    .IsRequired()
                    .HasColumnName("MBuyingGroup")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.McommissionCode)
                    .IsRequired()
                    .HasColumnName("MCommissionCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.McommitDate)
                    .HasColumnName("MCommitDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.McomponentSeq)
                    .IsRequired()
                    .HasColumnName("MComponentSeq")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Mcontract)
                    .IsRequired()
                    .HasColumnName("MContract")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MconvFactAlloc)
                    .HasColumnName("MConvFactAlloc")
                    .HasColumnType("decimal(12, 6)");

                entity.Property(e => e.MconvFactOrdUm)
                    .HasColumnName("MConvFactOrdUm")
                    .HasColumnType("decimal(12, 6)");

                entity.Property(e => e.MconvFactUnitQ)
                    .HasColumnName("MConvFactUnitQ")
                    .HasColumnType("decimal(6, 0)");

                entity.Property(e => e.McreditOrderLine)
                    .HasColumnName("MCreditOrderLine")
                    .HasColumnType("decimal(4, 0)");

                entity.Property(e => e.McreditOrderNo)
                    .IsRequired()
                    .HasColumnName("MCreditOrderNo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.McusRetailPrice)
                    .HasColumnName("MCusRetailPrice")
                    .HasColumnType("decimal(15, 5)");

                entity.Property(e => e.McusSupStkCode)
                    .IsRequired()
                    .HasColumnName("MCusSupStkCode")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.McustRequestDat)
                    .HasColumnName("MCustRequestDat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mdecimals)
                    .HasColumnName("MDecimals")
                    .HasColumnType("decimal(1, 0)");

                entity.Property(e => e.MdecimalsUnitQ)
                    .HasColumnName("MDecimalsUnitQ")
                    .HasColumnType("decimal(1, 0)");

                entity.Property(e => e.MdelNotePrinted)
                    .IsRequired()
                    .HasColumnName("MDelNotePrinted")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MdiscChanged)
                    .IsRequired()
                    .HasColumnName("MDiscChanged")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MdiscPct1)
                    .HasColumnName("MDiscPct1")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.MdiscPct2)
                    .HasColumnName("MDiscPct2")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.MdiscPct3)
                    .HasColumnName("MDiscPct3")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.MdiscValFlag)
                    .IsRequired()
                    .HasColumnName("MDiscValFlag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MdiscValue)
                    .HasColumnName("MDiscValue")
                    .HasColumnType("decimal(14, 2)");

                entity.Property(e => e.MeccFlag)
                    .IsRequired()
                    .HasColumnName("MEccFlag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MfstTaxCode)
                    .IsRequired()
                    .HasColumnName("MFstTaxCode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MhierarchyJob)
                    .IsRequired()
                    .HasColumnName("MHierarchyJob")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MinvoicePrinted)
                    .IsRequired()
                    .HasColumnName("MInvoicePrinted")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MlastDelNote)
                    .IsRequired()
                    .HasColumnName("MLastDelNote")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MleadTime)
                    .HasColumnName("MLeadTime")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.MlineReceiptDat)
                    .HasColumnName("MLineReceiptDat")
                    .HasColumnType("datetime");

                entity.Property(e => e.MlineShipDate)
                    .HasColumnName("MLineShipDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MmovementReqd)
                    .IsRequired()
                    .HasColumnName("MMovementReqd")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MmpsFlag)
                    .IsRequired()
                    .HasColumnName("MMpsFlag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MmpsGrossReqd)
                    .IsRequired()
                    .HasColumnName("MMpsGrossReqd")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MmulDivPrcFct)
                    .IsRequired()
                    .HasColumnName("MMulDivPrcFct")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MmulDivQtyFct)
                    .IsRequired()
                    .HasColumnName("MMulDivQtyFct")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MoptionalFlag)
                    .IsRequired()
                    .HasColumnName("MOptionalFlag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MordAckPrinted)
                    .IsRequired()
                    .HasColumnName("MOrdAckPrinted")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MorderQty)
                    .HasColumnName("MOrderQty")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.MorderUom)
                    .IsRequired()
                    .HasColumnName("MOrderUom")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MparentKitType)
                    .IsRequired()
                    .HasColumnName("MParentKitType")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MpickingSlip)
                    .IsRequired()
                    .HasColumnName("MPickingSlip")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Mprice)
                    .HasColumnName("MPrice")
                    .HasColumnType("decimal(15, 5)");

                entity.Property(e => e.MpriceCode)
                    .IsRequired()
                    .HasColumnName("MPriceCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MpriceUom)
                    .IsRequired()
                    .HasColumnName("MPriceUom")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MprintComponent)
                    .IsRequired()
                    .HasColumnName("MPrintComponent")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MproductClass)
                    .IsRequired()
                    .HasColumnName("MProductClass")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MqtyChangesFlag)
                    .IsRequired()
                    .HasColumnName("MQtyChangesFlag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MqtyDispatched)
                    .HasColumnName("MQtyDispatched")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.MqtyPer)
                    .HasColumnName("MQtyPer")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Mrelease)
                    .IsRequired()
                    .HasColumnName("MRelease")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MreviewFlag)
                    .IsRequired()
                    .HasColumnName("MReviewFlag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MreviewStatus)
                    .IsRequired()
                    .HasColumnName("MReviewStatus")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MscrapPercentage)
                    .HasColumnName("MScrapPercentage")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.MserialMethod)
                    .IsRequired()
                    .HasColumnName("MSerialMethod")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MshipQty)
                    .HasColumnName("MShipQty")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.MstockCode)
                    .IsRequired()
                    .HasColumnName("MStockCode")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MstockDes)
                    .IsRequired()
                    .HasColumnName("MStockDes")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MstockQtyToShp)
                    .HasColumnName("MStockQtyToShp")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.MstockUnitMass)
                    .HasColumnName("MStockUnitMass")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.MstockUnitVol)
                    .HasColumnName("MStockUnitVol")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.MstockingUom)
                    .IsRequired()
                    .HasColumnName("MStockingUom")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MsupplementaryUn)
                    .IsRequired()
                    .HasColumnName("MSupplementaryUn")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MtariffCode)
                    .IsRequired()
                    .HasColumnName("MTariffCode")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MtaxCode)
                    .IsRequired()
                    .HasColumnName("MTaxCode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MtraceableType)
                    .IsRequired()
                    .HasColumnName("MTraceableType")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MtrfCostMult)
                    .HasColumnName("MTrfCostMult")
                    .HasColumnType("decimal(9, 6)");

                entity.Property(e => e.MultiShipCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MunitCost)
                    .HasColumnName("MUnitCost")
                    .HasColumnType("decimal(15, 5)");

                entity.Property(e => e.MunitQuantity)
                    .IsRequired()
                    .HasColumnName("MUnitQuantity")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MuserDef)
                    .IsRequired()
                    .HasColumnName("MUserDef")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Mversion)
                    .IsRequired()
                    .HasColumnName("MVersion")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Mwarehouse)
                    .IsRequired()
                    .HasColumnName("MWarehouse")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MzeroQtyCrNote)
                    .IsRequired()
                    .HasColumnName("MZeroQtyCrNote")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NchargeCode)
                    .IsRequired()
                    .HasColumnName("NChargeCode")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Ncomment)
                    .IsRequired()
                    .HasColumnName("NComment")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NcommentFromLin)
                    .HasColumnName("NCommentFromLin")
                    .HasColumnType("decimal(4, 0)");

                entity.Property(e => e.NcommentTextTyp)
                    .IsRequired()
                    .HasColumnName("NCommentTextTyp")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NcommentType)
                    .IsRequired()
                    .HasColumnName("NCommentType")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NdepRetFlagProj)
                    .IsRequired()
                    .HasColumnName("NDepRetFlagProj")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NmscChargeCost)
                    .HasColumnName("NMscChargeCost")
                    .HasColumnType("decimal(14, 2)");

                entity.Property(e => e.NmscChargeQty)
                    .HasColumnName("NMscChargeQty")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.NmscChargeValue)
                    .HasColumnName("NMscChargeValue")
                    .HasColumnType("decimal(14, 2)");

                entity.Property(e => e.NmscFstCode)
                    .IsRequired()
                    .HasColumnName("NMscFstCode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NmscInvCharge)
                    .IsRequired()
                    .HasColumnName("NMscInvCharge")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NmscProductCls)
                    .IsRequired()
                    .HasColumnName("NMscProductCls")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NmscTaxCode)
                    .IsRequired()
                    .HasColumnName("NMscTaxCode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NprtOnAck)
                    .IsRequired()
                    .HasColumnName("NPrtOnAck")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NprtOnDel)
                    .IsRequired()
                    .HasColumnName("NPrtOnDel")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NprtOnInv)
                    .IsRequired()
                    .HasColumnName("NPrtOnInv")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NretentionJob)
                    .IsRequired()
                    .HasColumnName("NRetentionJob")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NsrvApplyFactor)
                    .IsRequired()
                    .HasColumnName("NSrvApplyFactor")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NsrvChargeType)
                    .IsRequired()
                    .HasColumnName("NSrvChargeType")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NsrvDecRndFlag)
                    .IsRequired()
                    .HasColumnName("NSrvDecRndFlag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NsrvDecimalRnd)
                    .HasColumnName("NSrvDecimalRnd")
                    .HasColumnType("decimal(1, 0)");

                entity.Property(e => e.NsrvIncTotal)
                    .IsRequired()
                    .HasColumnName("NSrvIncTotal")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NsrvMaxValue)
                    .HasColumnName("NSrvMaxValue")
                    .HasColumnType("decimal(14, 2)");

                entity.Property(e => e.NsrvMinQuantity)
                    .HasColumnName("NSrvMinQuantity")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.NsrvMinValue)
                    .HasColumnName("NSrvMinValue")
                    .HasColumnType("decimal(14, 2)");

                entity.Property(e => e.NsrvMulDiv)
                    .IsRequired()
                    .HasColumnName("NSrvMulDiv")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NsrvParentLine)
                    .HasColumnName("NSrvParentLine")
                    .HasColumnType("decimal(4, 0)");

                entity.Property(e => e.NsrvQtyFactor)
                    .HasColumnName("NSrvQtyFactor")
                    .HasColumnType("decimal(12, 6)");

                entity.Property(e => e.NsrvSummary)
                    .IsRequired()
                    .HasColumnName("NSrvSummary")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NsrvUnitCost)
                    .HasColumnName("NSrvUnitCost")
                    .HasColumnType("decimal(15, 5)");

                entity.Property(e => e.NsrvUnitPrice)
                    .HasColumnName("NSrvUnitPrice")
                    .HasColumnType("decimal(15, 5)");

                entity.Property(e => e.NtaxAmountFlag)
                    .IsRequired()
                    .HasColumnName("NTaxAmountFlag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OrigShipDateAps).HasColumnType("datetime");

                entity.Property(e => e.PreactorPriority).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PromotionCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.QtyReserved).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.QtyReservedShip).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.SalesOrderDetStat)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SalesOrderInitLine).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.SalesOrderResStat)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ScrapQuantity).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TpmSequence).HasColumnType("decimal(6, 0)");

                entity.Property(e => e.TpmUsageFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.User1)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.SalesOrderNavigation)
                    .WithMany(p => p.SorDetail)
                    .HasForeignKey(d => d.SalesOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_SorDetail_SorMaster");
            });

            modelBuilder.Entity<SorMaster>(entity =>
            {
                entity.HasKey(e => e.SalesOrder)
                    .HasName("SorMasterKey");

                entity.HasIndex(e => new { e.ActiveFlag, e.SalesOrder })
                    .HasName("SorMasterIdxActive")
                    .IsUnique();

                entity.HasIndex(e => new { e.CancelledFlag, e.AlternateKey, e.SalesOrder })
                    .HasName("SorMasterIdxAlt")
                    .IsUnique();

                entity.HasIndex(e => new { e.CancelledFlag, e.Customer, e.SalesOrder })
                    .HasName("SorMasterIdxCus")
                    .IsUnique();

                entity.HasIndex(e => new { e.CancelledFlag, e.CustomerPoNumber, e.SalesOrder })
                    .HasName("SorMasterIdxCspo")
                    .IsUnique();

                entity.HasIndex(e => new { e.CancelledFlag, e.DetailStatus, e.SalesOrder })
                    .HasName("SorMasterIdxDetStat")
                    .IsUnique();

                entity.HasIndex(e => new { e.CancelledFlag, e.InterWhSale, e.SalesOrder })
                    .HasName("SorMasterIdxWhSale")
                    .IsUnique();

                entity.Property(e => e.SalesOrder)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ActiveFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AltShipAddrFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AlternateKey)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Branch)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CancelledFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CaptureHh).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.CaptureMm).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.CashCredit)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CommissionSales1).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.CommissionSales2).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.CommissionSales3).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.CommissionSales4).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.CompanyTaxNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ConsolidatedOrder)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CounterSalesFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountyZip)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreditAuthority)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreditedInvDate).HasColumnType("datetime");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Customer)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPoNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DateLastDocPrt).HasColumnType("datetime");

                entity.Property(e => e.DateLastInvPrt).HasColumnType("datetime");

                entity.Property(e => e.DeliveryNote)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryTerms)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DepositFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DetCustMvmtReqd)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DetailStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiscPct1).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.DiscPct2).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.DiscPct3).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.DispatchesMade)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DocumentFormat)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DocumentType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EdiSource)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EntInvoice)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EntInvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.EntrySystemDate).HasColumnType("datetime");

                entity.Property(e => e.ExchangeRate).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.ExtendedTaxCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FaxInvInBatch)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FixExchangeRate)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GstDeduction)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GstExemptFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GstExemptNum)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.GstExemptOride)
                    .IsRequired()
                    .HasColumnName("GstExemptORide")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GtrReference)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HierarchyFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IbtFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IncludeInMrp)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InterWhSale)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InvTermsOverride)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InvoiceCount).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.Job)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.JobsExistFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LanguageCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastDelNote).HasColumnType("datetime");

                entity.Property(e => e.LastInvoice)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastOperator)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LineComp)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LiveDispExist)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MulDiv)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MultiShipCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NextDetailLine).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.NonMerchFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumDispatches).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.Operator)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OrdAcknwPrinted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OrderStatusFail)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OrderType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProcessFlag).HasColumnType("decimal(1, 0)");

                entity.Property(e => e.Quote)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.QuoteVersion).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.ReqShipDate).HasColumnType("datetime");

                entity.Property(e => e.SalesOrderSource)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SalesOrderSrcDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salesperson)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salesperson2)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salesperson3)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salesperson4)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ScheduledOrdFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SerialisedFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShipAddress1)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipAddress2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipAddress3)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipAddress3Loc)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipAddress4)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipAddress5)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShipPostalCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToGpsLat).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.ShipToGpsLong).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.ShippingInstrs)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingInstrsCod)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingLocation)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SourceWarehouse)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialInstrs)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StandardComment)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TargetWarehouse)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TaxExemptFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxExemptNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TaxExemptOverride)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TimeDelPrtedHh).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.TimeDelPrtedMm).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.TimeInvPrtedHh).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.TimeInvPrtedMm).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TimeTakenToAdd).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.TimeTakenToChg).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.TpmEvaluatedFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TpmPickupFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransactionNature).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.TransportMode).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.User1)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Warehouse)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WebCreated)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.SorMaster)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_SorMaster_ArCustomer");

                entity.HasOne(d => d.JobNavigation)
                    .WithMany(p => p.SorMaster)
                    .HasForeignKey(d => d.Job)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_SorMaster_WipMaster");

                entity.HasOne(d => d.SalSalesperson)
                    .WithMany(p => p.SorMaster)
                    .HasForeignKey(d => new { d.Branch, d.Salesperson })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_SorMaster_SalSalesperson");
            });

            modelBuilder.Entity<WipMaster>(entity =>
            {
                entity.HasKey(e => e.Job)
                    .HasName("WipMasterKey");

                entity.HasIndex(e => new { e.Complete, e.Job })
                    .HasName("WipMasterIdxActive")
                    .IsUnique();

                entity.HasIndex(e => new { e.Customer, e.Job })
                    .HasName("WipMasterIdxCus")
                    .IsUnique();

                entity.HasIndex(e => new { e.JobClassification, e.Job })
                    .HasName("WipMasterIdxName")
                    .IsUnique();

                entity.HasIndex(e => new { e.StockCode, e.Job })
                    .HasName("WipMasterIdxStk")
                    .IsUnique();

                entity.HasIndex(e => new { e.CapexCode, e.CapexLine, e.Job })
                    .HasName("WipMasterIdxCapex")
                    .IsUnique();

                entity.HasIndex(e => new { e.SalesOrder, e.SalesOrderLine, e.Job })
                    .HasName("WipMasterIdxSord")
                    .IsUnique();

                entity.Property(e => e.Job)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ActCompleteDate).HasColumnType("datetime");

                entity.Property(e => e.AddLabPct).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.AddMatPct).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.AllocationLine)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CapexCode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CapexLine).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CoProductCostMet)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoProductCostVal)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoProductType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Complete)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConfirmedFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConvFactUom).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.ConvMulDiv)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Customer)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateCalcMethod)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DateJobLstUpd).HasColumnType("datetime");

                entity.Property(e => e.Decimals).HasColumnType("decimal(1, 0)");

                entity.Property(e => e.EstSourceNum)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EstTrailLoad)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExpLabCurrent).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.ExpLabour).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.ExpMatCurrent).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.ExpMaterial).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.GrossFlg)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GrossQty).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.GrossQtyEnt).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.HierarchyFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HierarchyJob)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HighestOpPosted).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.HoldFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HrsBookToDate1).HasColumnType("decimal(14, 6)");

                entity.Property(e => e.HrsBookToDate2).HasColumnType("decimal(14, 6)");

                entity.Property(e => e.HrsBookToDate3).HasColumnType("decimal(14, 6)");

                entity.Property(e => e.JobClassification)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JobCreatedStruc)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.JobDeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.JobDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobStartDate).HasColumnType("datetime");

                entity.Property(e => e.JobTenderDate).HasColumnType("datetime");

                entity.Property(e => e.JobType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LabCostToDate1).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.LabCostToDate2).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.LabCostToDate3).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.LabValueIssues1).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.LabValueIssues2).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.LabValueIssues3).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.LabourBilled).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.LibraryCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LstOrderCreated)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MasterJob)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MatCostToDate1).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.MatCostToDate2).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.MatCostToDate3).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.MatValueIssues1).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.MatValueIssues2).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.MatValueIssues3).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.MaterialBilled).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.MrpFromJob)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MrpToJob)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NarrationNum).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.NextDetailLine).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.NextLineHier).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.NextOpForAll).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.NotionalPart)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NxtLinePartBook).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.OrdEntSource)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OrigDueDate).HasColumnType("datetime");

                entity.Property(e => e.PctCompleteFlag).HasColumnType("decimal(1, 0)");

                entity.Property(e => e.Priority).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ProfitPct).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PrtFactDoc1)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PrtFactDoc2)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PrtFactDoc3)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PrtFactDoc4)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PurgeJob)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.QtyManufactured).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.QtyManufacturedEnt).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.QtyToMake).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.QtyToMakeEnt).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Release)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReqPlnFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReservedLotSerFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Route)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SalesOrder)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SalesOrderLine).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.SchEndDate).HasColumnType("datetime");

                entity.Property(e => e.SchEndTime).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.SchStartDate).HasColumnType("datetime");

                entity.Property(e => e.SchStartTime).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.ScheduleFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SellingPrice).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.SeqCheckReq)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StockCode)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StockDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeJobLstUpd).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TotQtyScrappedEnt).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TotalQtyScrapped).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TraceableType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UomFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Warehouse)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WipCtlGlCode)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.WipMaster)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_WipMaster_ArCustomer");

                entity.HasOne(d => d.SalesOrderNavigation)
                    .WithMany(p => p.WipMaster)
                    .HasForeignKey(d => d.SalesOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_WipMaster_SorMaster");

                entity.HasOne(d => d.SalesOrder1)
                    .WithMany(p => p.WipMaster)
                    .HasForeignKey(d => new { d.SalesOrder, d.SalesOrderLine })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Syspro_FK_WipMaster_SorDetail");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
