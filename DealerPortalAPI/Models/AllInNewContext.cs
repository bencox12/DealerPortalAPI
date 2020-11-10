using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DealerPortalAPI.Models
{
    public partial class AllInNewContext : DbContext
    {
        public AllInNewContext()
        {
        }

        public AllInNewContext(DbContextOptions<AllInNewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderMaster> OrderMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderMaster>(entity =>
            {
                entity.HasKey(e => e.Ponum);

                entity.HasIndex(e => new { e.CustomerPo, e.EntryDate, e.Status })
                    .HasName("NonClusteredIndex-20190531-134215");

                entity.Property(e => e.Ponum).HasColumnName("PONum");

                entity.Property(e => e.Aitags)
                    .HasColumnName("AITags")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ArTerms)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ArriveDate).HasColumnType("datetime");

                entity.Property(e => e.Assembled).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BillToAddressLine1)
                    .HasColumnName("BillTo_AddressLine1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BillToAddressLine2)
                    .HasColumnName("BillTo_AddressLine2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BillToCity)
                    .HasColumnName("BillTo_City")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BillToCountry)
                    .HasColumnName("BillTo_Country")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BillToPostalZip)
                    .HasColumnName("BillTo_Postal_ZIP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.BillToProvinceState)
                    .HasColumnName("BillTo_Province_State")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BillToTelephone)
                    .HasColumnName("BillTo_Telephone")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Branch)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CartonCharges).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CleanOrderDate).HasColumnType("datetime");

                entity.Property(e => e.CompletionDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerPo)
                    .HasColumnName("CustomerPO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DealerCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DealerEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Discount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.Fc)
                    .HasColumnName("FC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FreightCharges).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.FreightCharges1).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Gpo)
                    .HasColumnName("GPO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsideDelivery).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.InstallationIns).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.OrderSource)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.OrderType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Poamount)
                    .HasColumnName("POAmount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PoamountConfirmed).HasColumnName("POAmountConfirmed");

                entity.Property(e => e.Qs)
                    .HasColumnName("QS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveDate).HasColumnType("datetime");

                entity.Property(e => e.RepCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RepEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.SaleSupportEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SaleSupportId)
                    .HasColumnName("SaleSupportID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SalesOrder)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.ShipToAddressLine1)
                    .HasColumnName("ShipTo_AddressLine1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToAddressLine2)
                    .HasColumnName("ShipTo_AddressLine2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToCity)
                    .HasColumnName("ShipTo_City")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToCountry)
                    .HasColumnName("ShipTo_Country")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToName)
                    .HasColumnName("ShipTo_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToPostalZip)
                    .HasColumnName("ShipTo_Postal_ZIP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToProvinceState)
                    .HasColumnName("ShipTo_Province_State")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToTelephone)
                    .HasColumnName("ShipTo_Telephone")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Sitags)
                    .HasColumnName("SITags")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.SpiffPayee)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SpiffType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Spr)
                    .HasColumnName("SPR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sq)
                    .HasColumnName("SQ")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sr)
                    .HasColumnName("SR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StorageFees).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SubmitterEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Surcharge).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TagLines)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.TaxCharges).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TxmasAdmin).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TxmasRebate).HasColumnType("decimal(10, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
