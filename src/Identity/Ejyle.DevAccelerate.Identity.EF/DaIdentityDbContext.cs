// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Identity.UserActivities;
using Ejyle.DevAccelerate.Identity.UserSessions;
using Ejyle.DevAccelerate.Identity.UserSettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Identity.EF
{
    public class DaIdentityDbContext
    : DaIdentityDbContext<int, int?, DaUser, DaRole, DaUserSession, DaUserActivityCategory, DaUserActivity, DaUserSetting>
    {
        public DaIdentityDbContext(DbContextOptions<DaIdentityDbContext> options)
            : base(options)
        { }

        public DaIdentityDbContext()
            : base()
        { }

        public DaIdentityDbContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class DaIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserSession, TUserActivityCategory, TUserActivity, TUserSetting>
        : IdentityDbContext<TUser, TRole, TKey>
        where TKey : IEquatable<TKey>
        where TUser: IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TUserSession : DaUserSession<TKey>
        where TUserActivityCategory : DaUserActivityCategory<TKey, TNullableKey, TUserActivity>
        where TUserActivity : DaUserActivity<TKey, TNullableKey, TUserActivityCategory>
        where TUserSetting : DaUserSetting<TKey>
    {
        private const string SCHEMA_NAME = "Identity";

        public DaIdentityDbContext(DbContextOptions<DaIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserSession, TUserActivityCategory, TUserActivity, TUserSetting>> options)
            : base(options)
        { }

        public DaIdentityDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaIdentityDbContext()
            : base()
        { }

        public DaIdentityDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserSession, TUserActivityCategory, TUserActivity, TUserSetting>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserSession, TUserActivityCategory, TUserActivity, TUserSetting>>(), connectionString).Options;
        }

        public virtual DbSet<TUserSession> UserSessions { get; set; }
        public virtual DbSet<TUserActivityCategory> UserActivityCategories { get; set; }
        public virtual DbSet<TUserActivity> UserActivities { get; set; }
        public virtual DbSet<TUserSetting> UserSettings { get; set; }

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

            modelBuilder.Entity<TUser>().ToTable("Users", SCHEMA_NAME);
            modelBuilder.Entity<TRole>().ToTable("Roles", SCHEMA_NAME);
            modelBuilder.Entity<IdentityUserClaim<TKey>>().ToTable("UserClaims", SCHEMA_NAME);
            modelBuilder.Entity<IdentityUserLogin<TKey>>().ToTable("UserLogins", SCHEMA_NAME);
            modelBuilder.Entity<IdentityUserRole<TKey>>().ToTable("UserRoles", SCHEMA_NAME);
            modelBuilder.Entity<IdentityRoleClaim<TKey>>().ToTable("RoleClaims", SCHEMA_NAME);
            modelBuilder.Entity<IdentityUserToken<TKey>>().ToTable("UserTokens", SCHEMA_NAME);

            modelBuilder.Entity<TUserActivity>(entity =>
            {
                entity.ToTable("UserActivities", SCHEMA_NAME);

                entity.HasOne(d => d.UserActivityCategory)
                    .WithMany(p => p.UserActivities)
                    .HasForeignKey(d => d.UserActivityCategoryId);
            });

            modelBuilder.Entity<TUserActivityCategory>(entity =>
            {
                entity.ToTable("UserActivityCategories", SCHEMA_NAME);
            });

            modelBuilder.Entity<TUserSession>(entity =>
            {
                entity.ToTable("UserSessions", SCHEMA_NAME);

                entity.Property(e => e.DeviceAgent).HasMaxLength(500);

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.AccessToken).HasMaxLength(128);

                entity.Property(e => e.SystemSessionId).HasMaxLength(128);
            });

            modelBuilder.Entity<TUserSetting>(entity =>
            {
                entity.ToTable("UserSettings", SCHEMA_NAME);
            });
        }
    }
}
