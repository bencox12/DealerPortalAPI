using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DealerPortalAPI.Models
{
    public partial class docimagingContext : DbContext
    {
        public docimagingContext()
        {
        }

        public docimagingContext(DbContextOptions<docimagingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmailConfiguration> EmailConfiguration { get; set; }
        public virtual DbSet<EmailLog> EmailLog { get; set; }
        public virtual DbSet<EmailRoutes> EmailRoutes { get; set; }
        public virtual DbSet<PdfInfo> PdfInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailConfiguration>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BccEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CcEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailBody).IsUnicode(false);

                entity.Property(e => e.EmailSubject)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FromEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FromName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeyType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmailLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateSent).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.Property(e => e.SentBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmailRoutes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Customer)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PdfInfo>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.KeyName });

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.KeyName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateEmailed).HasColumnType("datetime");

                entity.Property(e => e.DateStamp).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
