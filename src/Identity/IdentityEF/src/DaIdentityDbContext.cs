// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Identity.EF.UserActivities;
using Ejyle.DevAccelerate.Identity.EF.UserSessions;
using Ejyle.DevAccelerate.Identity.UserActivities;
using Ejyle.DevAccelerate.Identity.UserSessions;
using Ejyle.DevAccelerate.Identity.UserSettings;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ejyle.DevAccelerate.Identity.EF
{
    /// <summary>
    /// Represents the identity database context for the underlying data store.
    /// </summary>
    public class DaIdentityDbContext : DaIdentityDbContext<DaUser, DaRole, DaUserLogin, DaUserRole, DaUserClaim, DaUserSession, DaUserActivityCategory, DaUserActivity, DaUserSetting>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaIdentityDbContext"/> class.
        /// </summary>
        public DaIdentityDbContext()
            : base()
        { }

        /// <summary>
        /// Creates an instance of the <see cref="DaIdentityDbContext"/> class.
        /// </summary>
        public DaIdentityDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public static DaIdentityDbContext Create()
        {
            return new DaIdentityDbContext();
        }
    }

    public class DaIdentityDbContext<TUser, TRole, TUserLogin, TUserRole, TUserClaim, TUserSession, TUserActivityCategory, TUserActivity, TUserSetting>
        : DaIdentityDbContext<int, int?, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TUserSession, TUserActivityCategory, TUserActivity, TUserSetting>
        where TUser : DaUser<int, int?, TUserLogin, TUserRole, TUserClaim>
        where TRole : DaRole<int, TUserRole>
        where TUserLogin : DaUserLogin<int>
        where TUserRole : DaUserRole<int>
        where TUserClaim : DaUserClaim<int>
        where TUserSession : DaUserSession<int>
        where TUserActivityCategory : DaUserActivityCategory<int, int?, TUserActivity>
        where TUserActivity : DaUserActivity<int, int?, TUserActivityCategory>
        where TUserSetting : DaUserSetting<int>
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaIdentityDbContext"/> class.
        /// </summary>
        public DaIdentityDbContext()
            : base()
        { }

        /// <summary>
        /// Creates an instance of the <see cref="DaIdentityDbContext"/> class.
        /// </summary>
        public DaIdentityDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }
    }

    public class DaIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TUserSession, TUserActivityCategory, TUserActivity, TUserSetting>
        : IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>
        where TKey : IEquatable<TKey>
        where TUser : DaUser<TKey, TNullableKey, TUserLogin, TUserRole, TUserClaim>
        where TRole : DaRole<TKey, TUserRole>
        where TUserLogin : DaUserLogin<TKey>
        where TUserRole : DaUserRole<TKey>
        where TUserClaim : DaUserClaim<TKey>
        where TUserSession : DaUserSession<TKey>
        where TUserActivityCategory : DaUserActivityCategory<TKey, TNullableKey, TUserActivity>
        where TUserActivity : DaUserActivity<TKey, TNullableKey, TUserActivityCategory>
        where TUserSetting : DaUserSetting<TKey>
    {
        private const string SCHEMA_NAME = "Identity";

        /// <summary>
        /// 
        /// </summary>
        public DaIdentityDbContext()
            : base(DaDbConnectionHelper.GetConnectionString())
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public DaIdentityDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TUserSession> UserSessions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TUserActivityCategory> UserActivityCategories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TUserActivity> UserActivities { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TUserSetting> UserSettings { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TUser>().ToTable("Users", SCHEMA_NAME);
            modelBuilder.Entity<TRole>().ToTable("Roles", SCHEMA_NAME);
            modelBuilder.Entity<TUserClaim>().ToTable("UserClaims", SCHEMA_NAME);
            modelBuilder.Entity<TUserLogin>().ToTable("UserLogins", SCHEMA_NAME);
            modelBuilder.Entity<TUserRole>().ToTable("UserRoles", SCHEMA_NAME);

            modelBuilder.Entity<TUserSession>().ToTable("UserSessions", SCHEMA_NAME);
            modelBuilder.Entity<TUserActivityCategory>().ToTable("UserActivityCategories", SCHEMA_NAME);
            modelBuilder.Entity<TUserActivity>().ToTable("UserActivities", SCHEMA_NAME);
            modelBuilder.Entity<TUserSetting>().ToTable("UserSettings", SCHEMA_NAME);

            modelBuilder.Entity<TUserActivityCategory>()
                .HasMany(e => e.UserActivities)
                .WithRequired(e => e.UserActivityCategory)
                .HasForeignKey(e => e.UserActivityCategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
