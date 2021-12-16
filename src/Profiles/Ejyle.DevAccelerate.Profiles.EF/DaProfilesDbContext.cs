// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Profiles.Addresses;
using Ejyle.DevAccelerate.Profiles.Organizations;
using Ejyle.DevAccelerate.Profiles.UserProfiles;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Profiles.EF
{
    public class DaProfilesDbContext : DaProfilesDbContext<int,int?, DaUserProfile, DaUserProfileAttribute, DaOrganizationProfile, DaOrganizationProfileAttribute, DaAddressProfile, DaUserAddress>
    {
        public DaProfilesDbContext()
            : base()
        { }

        public DaProfilesDbContext(DbContextOptions<DaProfilesDbContext> options)
            : base(options)
        { }
    }

    public class DaProfilesDbContext<TKey, TNullableKey, TUserProfile, TUserProfileAttribute, TOrganizationProfile, TOrganizationProfileAttribute, TAddressProfile, TUserAddress> : DbContext
        where TKey : IEquatable<TKey>
        where TUserProfile : DaUserProfile<TKey, TUserProfileAttribute>
        where TUserProfileAttribute : DaUserProfileAttribute<TKey, TUserProfile>
        where TOrganizationProfile : DaOrganizationProfile<TKey, TNullableKey, TOrganizationProfileAttribute>
        where TOrganizationProfileAttribute : DaOrganizationProfileAttribute<TKey, TNullableKey, TOrganizationProfile>
        where TAddressProfile : DaAddressProfile<TKey, TNullableKey, TUserAddress>
        where TUserAddress : DaUserAddress<TKey, TNullableKey, TAddressProfile>
    {
        private const string SCHEMA_NAME = "Profiles";

        public DaProfilesDbContext()
            : base()
        { }

        public DaProfilesDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaProfilesDbContext(DbContextOptions<DaProfilesDbContext<TKey, TNullableKey, TUserProfile, TUserProfileAttribute, TOrganizationProfile, TOrganizationProfileAttribute, TAddressProfile, TUserAddress>> options)
            : base(options)
        { }

        public virtual DbSet<TUserProfile> UserProfiles { get; set; }
        public virtual DbSet<TUserProfileAttribute> UserProfileAttributes { get; set; }
        public virtual DbSet<TOrganizationProfile> OrganizationProfiles { get; set; }
        public virtual DbSet<TOrganizationProfileAttribute> OrganizationProfileAttributes { get; set; }
        public virtual DbSet<TAddressProfile> AddressProfiles { get; set; }
        public virtual DbSet<TUserAddress> UserAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TAddressProfile>(entity =>
            {
                entity.ToTable("AddressProfiles", SCHEMA_NAME);
            });

            modelBuilder.Entity<TOrganizationProfileAttribute>(entity =>
            {
                entity.ToTable("OrganizationProfileAttributes", SCHEMA_NAME);

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.OrganizationProfile)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.OrganizationProfileId);
            });

            modelBuilder.Entity<TOrganizationProfile>(entity =>
            {
                entity.ToTable("OrganizationProfiles", SCHEMA_NAME);

                entity.Property(e => e.OrganizationName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TUserAddress>(entity =>
            {
                entity.ToTable("UserAddresses", SCHEMA_NAME);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.AddressProfile)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.AddressProfileId);
            });

            modelBuilder.Entity<TUserProfileAttribute>(entity =>
            {
                entity.ToTable("UserProfileAttributes", SCHEMA_NAME);

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.UserProfile)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.UserProfileId);
            });

            modelBuilder.Entity<TUserProfile>(entity =>
            {
                entity.ToTable("UserProfiles", SCHEMA_NAME);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.JobTitle).HasMaxLength(256);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.MiddleName).HasMaxLength(100);

                entity.Property(e => e.OrganizationName).HasMaxLength(256);

                entity.Property(e => e.Salutation).HasMaxLength(50);
            });
        }
    }
}
