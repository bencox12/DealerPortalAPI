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

        public virtual DbSet<ShipDetails> ShipDetails { get; set; }
        public virtual DbSet<ShipMaster> ShipMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
