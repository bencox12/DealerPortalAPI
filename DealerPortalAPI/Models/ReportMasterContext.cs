using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DealerPortalAPI.Models
{
    public partial class ReportMasterContext : DbContext
    {
        public ReportMasterContext()
        {
        }

        public ReportMasterContext(DbContextOptions<ReportMasterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomBranchMaster> CustomBranchMaster { get; set; }
        public virtual DbSet<CustomInsideSalesRep> CustomInsideSalesRep { get; set; }
        public virtual DbSet<CustomRegionMaster> CustomRegionMaster { get; set; }
        public virtual DbSet<CustomRepMaster> CustomRepMaster { get; set; }
        public virtual DbSet<CustomRsdmaster> CustomRsdmaster { get; set; }
        public virtual DbSet<CustomTerritoryMaster> CustomTerritoryMaster { get; set; }
        public virtual DbSet<CustomTerritoryMgrMaster> CustomTerritoryMgrMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomBranchMaster>(entity =>
            {
                entity.HasKey(e => e.BranchId)
                    .HasName("PK__Custom_B__12CEB04135BCFE0A");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BranchNumber)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomInsideSalesRep>(entity =>
            {
                entity.HasKey(e => e.InsideSalesRepId)
                    .HasName("PK__CustomIn__5436FF1E75A278F5");

                entity.Property(e => e.InsideSalesRepId).HasColumnName("InsideSalesRepID");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InsideSalesRepBonusP).HasColumnType("decimal(18, 10)");

                entity.Property(e => e.InsideSalesRepEmailAddr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InsideSalesRepEmpId)
                    .HasColumnName("InsideSalesRepEmpID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InsideSalesRepName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CustomRegionMaster>(entity =>
            {
                entity.HasKey(e => e.RegionId)
                    .HasName("PK__Custom_R__A9EAD51F1BFD2C07");

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CustomRepMaster>(entity =>
            {
                entity.HasKey(e => e.SalesPersonId)
                    .HasName("PK__CustomRe__7A591C18603D47BB");

                entity.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.GovRsdId).HasColumnName("GovRsdID");

                entity.Property(e => e.Grpid)
                    .HasColumnName("GRPID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IncludeSales)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InsideSalesRepId).HasColumnName("InsideSalesRepID");

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");

                entity.Property(e => e.RepCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Rsdid).HasColumnName("RSDID");

                entity.Property(e => e.SalesPersonName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SalesPersonShortName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");

                entity.Property(e => e.TerritoryMgrId).HasColumnName("TerritoryMgrID");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.CustomRepMaster)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_Custom_Rep_Master_Custom_Branch_Master");

                entity.HasOne(d => d.InsideSalesRep)
                    .WithMany(p => p.CustomRepMaster)
                    .HasForeignKey(d => d.InsideSalesRepId)
                    .HasConstraintName("FK_CustomRepMaster_CustomInsideSalesRep1");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.CustomRepMaster)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_Custom_Rep_Master_Custom_Region_Master");

                entity.HasOne(d => d.Rsd)
                    .WithMany(p => p.CustomRepMaster)
                    .HasForeignKey(d => d.Rsdid)
                    .HasConstraintName("FK_Custom_Rep_Master_Custom_RSD_Master");

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.CustomRepMaster)
                    .HasForeignKey(d => d.TerritoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CustomRepMaster_CustomTerritoryMaster");

                entity.HasOne(d => d.TerritoryMgr)
                    .WithMany(p => p.CustomRepMaster)
                    .HasForeignKey(d => d.TerritoryMgrId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Custom_Rep_Master_Custom_TerritoryMgr_Master");
            });

            modelBuilder.Entity<CustomRsdmaster>(entity =>
            {
                entity.HasKey(e => e.Rsdid)
                    .HasName("PK__Custom_R__F098B32D412EB0B6");

                entity.ToTable("CustomRSDMaster");

                entity.Property(e => e.Rsdid).HasColumnName("RSDID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Rsdname)
                    .IsRequired()
                    .HasColumnName("RSDName")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<CustomTerritoryMaster>(entity =>
            {
                entity.HasKey(e => e.TerritoryId)
                    .HasName("PK__Custom_T__2FEE364E398D8EEE");

                entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.TerritoryName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CustomTerritoryMgrMaster>(entity =>
            {
                entity.HasKey(e => e.TerritoryMgrId)
                    .HasName("PK__Custom_T__E58F7C0B44FF419A");

                entity.Property(e => e.TerritoryMgrId).HasColumnName("TerritoryMgrID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TerritoryMgrName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
