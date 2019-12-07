// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Profiles.Addresses;
using Ejyle.DevAccelerate.Profiles.Organizations;
using Ejyle.DevAccelerate.Profiles.UserProfiles;

namespace Ejyle.DevAccelerate.Profiles.EF
{
    public class DaProfilesDbContext : DaProfilesDbContext<int,int?, DaUserProfile, DaUserProfileAttribute, DaOrganizationProfile, DaOrganizationProfileAttribute, DaAddressProfile, DaUserAddress>
    {
        public DaProfilesDbContext() : base()
        { }

        public static DaProfilesDbContext Create()
        {
            return new DaProfilesDbContext();
        }
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
            : base(DaDbConnectionHelper.GetConnectionString())
        {
        }

        public DaProfilesDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public virtual DbSet<TUserProfile> UserProfiles { get; set; }
        public virtual DbSet<TUserProfileAttribute> UserProfileAttributes { get; set; }
        public virtual DbSet<TOrganizationProfile> OrganizationProfiles { get; set; }
        public virtual DbSet<TOrganizationProfileAttribute> OrganizationProfileAttributes { get; set; }
        public virtual DbSet<TAddressProfile> AddressProfiles { get; set; }
        public virtual DbSet<TUserAddress> UserAddresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region User Profiles

            var userProfiles = modelBuilder.Entity<TUserProfile>()
                .ToTable("UserProfiles", SCHEMA_NAME);

            userProfiles.Property(m => m.Dob)
                        .HasColumnType("date");

            userProfiles.HasMany(e => e.Attributes)
                .WithRequired(e => e.UserProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TUserProfileAttribute>()
                .ToTable("UserProfileAttributes", SCHEMA_NAME);

            #endregion User Profiles

            #region Organization Profiles

            var organizationProfiles = modelBuilder.Entity<TOrganizationProfile>()
                .ToTable("OrganizationProfiles", SCHEMA_NAME);

            organizationProfiles.HasMany(e => e.Attributes)
                .WithRequired(e => e.OrganizationProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TOrganizationProfileAttribute>()
                .ToTable("OrganizationProfileAttributes", SCHEMA_NAME);

            #endregion Organization Profiles

            #region Addresses

            var addressProfiles = modelBuilder.Entity<TAddressProfile>()
                .ToTable("AddressProfiles", SCHEMA_NAME);

            addressProfiles.HasMany(e => e.UserAddresses)
                .WithRequired(e => e.AddressProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TUserAddress>()
                .ToTable("UserAddresses", SCHEMA_NAME);

            #endregion Addresses
        }
    }
}
