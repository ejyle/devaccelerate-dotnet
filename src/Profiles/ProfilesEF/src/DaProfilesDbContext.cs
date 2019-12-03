// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Profiles.Organizations;
using Ejyle.DevAccelerate.Profiles.UserProfiles;

namespace Ejyle.DevAccelerate.Profiles.EF
{
    public class DaProfilesDbContext : DaProfilesDbContext<int, DaUserProfile, DaOrganizationProfile>
    {
        public DaProfilesDbContext() : base()
        { }

        public static DaProfilesDbContext Create()
        {
            return new DaProfilesDbContext();
        }
    }

    public class DaProfilesDbContext<TKey, TUserProfile, TOrganizationProfile> : DbContext
        where TKey : IEquatable<TKey>
        where TUserProfile : DaUserProfile<TKey>
        where TOrganizationProfile : DaOrganizationProfile<TKey>
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
        public virtual DbSet<TOrganizationProfile> OrganizationProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region User Profiles

            var userProfiles = modelBuilder.Entity<TUserProfile>()
                .ToTable("UserProfiles", SCHEMA_NAME);

            userProfiles.Property(m => m.Dob)
                        .HasColumnType("date");

            #endregion User Profiles

            #region Organization Profiles

            var organizationProfiles = modelBuilder.Entity<TOrganizationProfile>()
                .ToTable("OrganizationProfiles", SCHEMA_NAME);

            #endregion Organization Profiles
        }
    }
}
