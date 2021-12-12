// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;
using Ejyle.DevAccelerate.Identity.UserActivities;
using Ejyle.DevAccelerate.Identity.UserSessions;
using Ejyle.DevAccelerate.Identity.UserSettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Identity.EF
{
    public class DaAspNetIdentityDbContext
    : DaAspNetIdentityDbContext<int, int?, DaUser, DaRole, DaUserSession, DaUserActivityCategory, DaUserActivity, DaUserSetting>
    {
        public DaAspNetIdentityDbContext(DbContextOptions<DaAspNetIdentityDbContext> options)
            : base(options)
        { }

        public DaAspNetIdentityDbContext()
            : base()
        { }
    }

    public class DaAspNetIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserSession, TUserActivityCategory, TUserActivity, TUserSetting>
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

        public DaAspNetIdentityDbContext(DbContextOptions<DaAspNetIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserSession, TUserActivityCategory, TUserActivity, TUserSetting>> options)
            : base(options)
        { }

        public DaAspNetIdentityDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaAspNetIdentityDbContext()
            : base()
        { }

        public virtual DbSet<TUserSession> UserSessions { get; set; }
        public virtual DbSet<TUserActivityCategory> UserActivityCategories { get; set; }
        public virtual DbSet<TUserActivity> UserActivities { get; set; }
        public virtual DbSet<TUserSetting> UserSettings { get; set; }

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

            modelBuilder.Entity<TUserSession>().ToTable("UserSessions", SCHEMA_NAME);
            modelBuilder.Entity<TUserActivityCategory>().ToTable("UserActivityCategories", SCHEMA_NAME);
            modelBuilder.Entity<TUserActivity>().ToTable("UserActivities", SCHEMA_NAME);
            modelBuilder.Entity<TUserSetting>().ToTable("UserSettings", SCHEMA_NAME);

            modelBuilder.Entity<TUserActivity>()
                .HasOne(p => p.UserActivityCategory)
                .WithMany(b => b.UserActivities)
                .HasForeignKey(p => p.UserActivityCategoryId)
                .HasPrincipalKey(b => b.Id);
        }
    }
}
