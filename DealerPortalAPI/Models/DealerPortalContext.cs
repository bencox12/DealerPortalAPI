using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DealerPortalAPI.Models
{
    public partial class DealerPortalContext : DbContext
    {
        public DealerPortalContext()
        {
        }

        public DealerPortalContext(DbContextOptions<DealerPortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DealerUser> DealerUser { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DealerUser>(entity =>
            {
                entity.Property(e => e.DealerUserId).HasColumnName("DealerUserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Permissions).HasMaxLength(50);

                entity.Property(e => e.SysproDealerId)
                    .IsRequired()
                    .HasColumnName("SysproDealerID")
                    .HasMaxLength(10);

                entity.Property(e => e.SysproRepCode).HasMaxLength(5);

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PermissionType)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

                entity.Property(e => e.Filename).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleType)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
