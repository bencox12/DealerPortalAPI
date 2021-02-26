using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DealerPortalAPI.Models
{
    public partial class LabelsContext : DbContext
    {
        public LabelsContext()
        {
        }

        public LabelsContext(DbContextOptions<LabelsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LabPackDetailA> LabPackDetailA { get; set; }
        public virtual DbSet<OperPacking> OperPacking { get; set; }
        public virtual DbSet<ShipDetails> ShipDetails { get; set; }
        public virtual DbSet<ShipMaster> ShipMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LabPackDetailA>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FinishTime).HasColumnType("smalldatetime");

                entity.Property(e => e.JobNumber).HasMaxLength(50);

                entity.Property(e => e.LabPrintFlag)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LablPrintDate).HasColumnType("datetime");

                entity.Property(e => e.PrintedBy).HasColumnType("ntext");

                entity.Property(e => e.ProdModel).HasMaxLength(50);

                entity.Property(e => e.SalesOrder).HasMaxLength(50);

                entity.Property(e => e.StartTime).HasColumnType("smalldatetime");

                entity.Property(e => e.StockCode).HasMaxLength(50);

                entity.Property(e => e.TrailerNo).HasColumnType("ntext");
            });

            modelBuilder.Entity<OperPacking>(entity =>
            {
                entity.HasKey(e => e.LablSerNo);

                entity.Property(e => e.LablSerNo).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Delete).HasColumnName("DELETE");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FinishTime).HasColumnType("smalldatetime");

                entity.Property(e => e.LablStatus)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LineNum).HasMaxLength(10);

                entity.Property(e => e.ModelNo)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Option1).HasColumnName("OPTION1");

                entity.Property(e => e.Option2).HasColumnName("OPTION2");

                entity.Property(e => e.Option3).HasColumnName("OPTION3");

                entity.Property(e => e.SalesOrder).HasMaxLength(50);

                entity.Property(e => e.StartTime).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<ShipDetails>(entity =>
            {
                entity.HasKey(e => new { e.DocumentId, e.SalesOrder, e.SalesOrderLine });

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.SalesOrder).HasMaxLength(50);

                entity.Property(e => e.ComputerId)
                    .HasColumnName("ComputerID")
                    .HasMaxLength(50);

                entity.Property(e => e.Customer).HasMaxLength(50);

                entity.Property(e => e.JobNumber).HasMaxLength(50);

                entity.Property(e => e.StkDescription).HasMaxLength(255);

                entity.Property(e => e.StockCode).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ShipMaster>(entity =>
            {
                entity.HasKey(e => e.DocumentId);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.Carrier).HasMaxLength(50);

                entity.Property(e => e.ComputerId)
                    .HasColumnName("ComputerID")
                    .HasMaxLength(50);

                entity.Property(e => e.DateStamp).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
