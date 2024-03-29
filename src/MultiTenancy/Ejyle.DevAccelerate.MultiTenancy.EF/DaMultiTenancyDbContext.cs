// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright � Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.MultiTenancy.Tenants;
using Ejyle.DevAccelerate.MultiTenancy.Addresses;
using Ejyle.DevAccelerate.MultiTenancy.Organizations;
using Ejyle.DevAccelerate.MultiTenancy.ApiManagement;
using System.Xml;

namespace Ejyle.DevAccelerate.MultiTenancy.EF
{
    public class DaMultiTenancyDbContext : DaMultiTenancyDbContext<string, DaTenant, DaTenantUser, DaTenantAttribute, DaMTPTenant, DaTenantDomain, DaApiKey, DaOrganization, DaOrganizationAttribute, DaOrganizationGroup, DaAddressProfile, DaUserAddress>
    {
        public DaMultiTenancyDbContext()
            : base()
        { }

        public DaMultiTenancyDbContext(DbContextOptions<DaMultiTenancyDbContext> options)
           : base(options)
        { }

        public DaMultiTenancyDbContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class DaMultiTenancyDbContext<TKey, TTenant, TTenantUser, TTenantAttribute, TMTPTenant, TTenantDomain, TApiKey, TOrganization, TOrganizationAttribute, TOrganizationGroup, TAddressProfile, TUserAddress> : DbContext
        where TKey : IEquatable<TKey>
        where TTenant : DaTenant<TKey, TTenantUser, TTenantAttribute, TMTPTenant, TTenantDomain>
        where TTenantAttribute : DaTenantAttribute<TKey, TTenant>
        where TTenantUser : DaTenantUser<TKey, TTenant>
        where TMTPTenant : DaMTPTenant<TKey, TTenant>
        where TTenantDomain : DaTenantDomain<TKey, TTenant>
        where TApiKey : DaApiKey<TKey>
        where TOrganization : DaOrganization<TKey, TOrganization, TOrganizationAttribute, TOrganizationGroup>
        where TOrganizationGroup : DaOrganizationGroup<TKey, TOrganizationGroup, TOrganization>
        where TOrganizationAttribute : DaOrganizationAttribute<TKey, TOrganization>
        where TAddressProfile : DaAddressProfile<TKey, TUserAddress>
        where TUserAddress : DaUserAddress<TKey, TAddressProfile>
    {
        private const string SCHEMA_NAME = "Da.MultiTenancy";

        public DaMultiTenancyDbContext()
            : base()
        { }

        public DaMultiTenancyDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaMultiTenancyDbContext(DbContextOptions<DaMultiTenancyDbContext<TKey, TTenant, TTenantUser, TTenantAttribute, TMTPTenant, TTenantDomain, TApiKey, TOrganization, TOrganizationAttribute, TOrganizationGroup, TAddressProfile, TUserAddress>> options)
            : base(options)
        { }

        public DaMultiTenancyDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaMultiTenancyDbContext<TKey, TTenant, TTenantUser, TTenantAttribute, TMTPTenant, TTenantDomain, TApiKey, TOrganization, TOrganizationAttribute, TOrganizationGroup, TAddressProfile, TUserAddress>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaMultiTenancyDbContext<TKey, TTenant, TTenantUser, TTenantAttribute, TMTPTenant, TTenantDomain, TApiKey, TOrganization, TOrganizationAttribute, TOrganizationGroup, TAddressProfile, TUserAddress>>(), connectionString).Options;
        }

        public virtual DbSet<TTenant> Tenants { get; set; }
        public virtual DbSet<TTenantUser> TenantUsers { get; set; }
        public virtual DbSet<TTenantAttribute> TenantAttributes { get; set; }
        public virtual DbSet<TMTPTenant> MTPTenants { get; set; }
        public virtual DbSet<TOrganization> Organizations { get; set; }
        public virtual DbSet<TOrganizationAttribute> OrganizationAttributes { get; set; }
        public virtual DbSet<TOrganizationGroup> OrganizationGroups { get; set; }
        public virtual DbSet<TAddressProfile> AddressProfiles { get; set; }
        public virtual DbSet<TUserAddress> UserAddresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Ejyle.DevAccelerate;Trusted_Connection = True;MultipleActiveResultSets=True";

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TTenantAttribute>(entity =>
            {
                entity.ToTable("TenantAttributes", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.TenantId);
            });

            modelBuilder.Entity<TTenantUser>(entity =>
            {
                entity.ToTable("TenantUsers", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.TenantId).IsRequired();
                entity.Property(e => e.UserId).HasMaxLength(450).IsRequired();

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.TenantUsers)
                    .HasForeignKey(d => d.TenantId);
            });

            modelBuilder.Entity<TMTPTenant>(entity =>
            {
                entity.ToTable("MTPTenants", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.MTPManagedTenantId).IsRequired();
                entity.Property(e => e.MTPTenantId).IsRequired();

                entity.Property(e => e.MTPNumber)
                    .IsRequired() 
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn();

                entity.HasIndex(e => e.MTPNumber).IsUnique();

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");

                entity.HasOne(d => d.MTPManagedTenant)
                    .WithMany(p => p.MTPManagedTenants)
                    .HasForeignKey(d => d.MTPManagedTenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MTPTenants_MTPManagedTenants");

                entity.HasOne(d => d.MTPTenant)
                    .WithMany(p => p.MTPTenants)
                    .HasForeignKey(d => d.MTPTenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MTPTenants_MTPTenants");
            });

            modelBuilder.Entity<TTenant>(entity =>
            {
                entity.ToTable("Tenants", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.BillingEmail)
                    .HasMaxLength(256);

                entity.Property(e => e.FriendlyName)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.Country).HasMaxLength(450);
                entity.Property(e => e.Currency).HasMaxLength(450);
                entity.Property(e => e.SystemLanguage).HasMaxLength(450);
                entity.Property(e => e.TimeZone).HasMaxLength(450);

                entity.Property(e => e.OwnerUserId).HasMaxLength(450).IsRequired();

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TTenantDomain>(entity =>
            {
                entity.ToTable("Domains", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.VerificationValue)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.Property(e => e.VerificationFileName)
                    .HasMaxLength(256);

                entity.HasIndex(e => e.Domain)
                    .IsUnique();

                entity.Property(e => e.VerificationCodeCreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.VerificationCodeExpiryDateUtc).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Tenant)
                     .WithMany(p => p.Domains)
                     .HasForeignKey(d => d.TenantId);
            });

            modelBuilder.Entity<TAddressProfile>(entity =>
            {
                entity.ToTable("AddressProfiles", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Country).HasMaxLength(450);
                entity.Property(e => e.OwnerUserId).HasMaxLength(450).IsRequired();

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TApiKey>(entity =>
            {
                entity.ToTable("ApiKeys", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Salt).HasMaxLength(128).IsRequired();
                entity.Property(e => e.SecretKey).HasMaxLength(1000).IsRequired();
                entity.Property(e => e.ApiKey).HasMaxLength(128).IsRequired();

                entity.HasIndex(e => e.ApiKey).IsUnique();

                entity.Property(e => e.TenantId).IsRequired();

                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TOrganizationAttribute>(entity =>
            {
                entity.ToTable("OrganizationAttributes", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.OrganizationId).IsRequired();

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.OrganizationId);
            });

            modelBuilder.Entity<TOrganization>(entity =>
            {
                entity.ToTable("Organizations", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.OrganizationName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentId);

                entity.Property(d => d.TenantId).IsRequired();
                entity.Property(e => e.OwnerUserId).HasMaxLength(450).IsRequired();

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TOrganizationGroup>(entity =>
            {
                entity.ToTable("OrganizationGroups", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentId);

                entity.HasOne(d => d.Organization)
                     .WithMany(p => p.Groups)
                     .HasForeignKey(d => d.OrganizationId);

                entity.Property(e => e.OwnerUserId).HasMaxLength(450).IsRequired();

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TUserAddress>(entity =>
            {
                entity.ToTable("UserAddresses", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.AddressProfile)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.AddressProfileId);

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });
        }
    }
}
