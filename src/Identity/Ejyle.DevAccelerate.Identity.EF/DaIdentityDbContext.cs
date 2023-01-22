// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Identity.Groups;
using Ejyle.DevAccelerate.Identity.UserActivities;
using Ejyle.DevAccelerate.Identity.UserAgreements;
using Ejyle.DevAccelerate.Identity.UserProfiles;
using Ejyle.DevAccelerate.Identity.UserSessions;
using Ejyle.DevAccelerate.Identity.UserSettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Identity.EF
{
    public class DaIdentityDbContext
    : DaIdentityDbContext<string, DaUser, DaUserProfile, DaUserProfileAttribute, DaRole, DaGroup, DaGroupRole, DaGroupUser, DaUserSession, DaUserActivityCategory, DaUserActivity, DaUserSetting, DaUserAgreement, DaUserAgreementVersion, DaUserAgreementVersionAction>
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

    public class DaIdentityDbContext<TKey, TUser, TUserProfile, TUserProfileAttribute, TRole, TGroup, TGroupRole, TGroupUser, TUserSession, TUserActivityCategory, TUserActivity, TUserSetting, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction>
        : IdentityDbContext<TUser, TRole, TKey>
        where TKey : IEquatable<TKey>
        where TUser: IdentityUser<TKey>
        where TUserProfile : DaUserProfile<TKey, TUserProfileAttribute>
        where TUserProfileAttribute : DaUserProfileAttribute<TKey, TUserProfile>
        where TRole : IdentityRole<TKey>
        where TGroup : DaGroup<TKey, TGroupRole, TGroupUser>
        where TGroupRole : DaGroupRole<TKey, TGroup>
        where TGroupUser : DaGroupUser<TKey, TGroup>
        where TUserSession : DaUserSession<TKey>
        where TUserActivityCategory : DaUserActivityCategory<TKey, TUserActivity>
        where TUserActivity : DaUserActivity<TKey, TUserActivityCategory>
        where TUserSetting : DaUserSetting<TKey>
        where TUserAgreement : DaUserAgreement<TKey, TUserAgreementVersion>
        where TUserAgreementVersion : DaUserAgreementVersion<TKey, TUserAgreement, TUserAgreementVersionAction>
        where TUserAgreementVersionAction : DaUserAgreementVersionAction<TKey, TUserAgreementVersion>
    {
        private const string SCHEMA_NAME = "Da.Identity";

        public DaIdentityDbContext(DbContextOptions<DaIdentityDbContext<TKey, TUser, TUserProfile, TUserProfileAttribute, TRole, TGroup, TGroupRole, TGroupUser, TUserSession, TUserActivityCategory, TUserActivity, TUserSetting, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction>> options)
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

        private static DbContextOptions<DaIdentityDbContext<TKey, TUser, TUserProfile, TUserProfileAttribute, TRole, TGroup, TGroupRole, TGroupUser, TUserSession, TUserActivityCategory, TUserActivity, TUserSetting, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaIdentityDbContext<TKey, TUser, TUserProfile, TUserProfileAttribute, TRole, TGroup, TGroupRole, TGroupUser, TUserSession, TUserActivityCategory, TUserActivity, TUserSetting, TUserAgreement, TUserAgreementVersion, TUserAgreementVersionAction>>(), connectionString).Options;
        }

        public virtual DbSet<TUserProfile> UserProfiles { get; set; }
        public virtual DbSet<TUserProfileAttribute> UserProfileAttributes { get; set; }
        public virtual DbSet<DaGroup> Groups { get; set; }
        public virtual DbSet<DaGroupRole> GroupRoles { get; set; }
        public virtual DbSet<DaGroupUser> GroupUsers { get; set; }
        public virtual DbSet<TUserSession> UserSessions { get; set; }
        public virtual DbSet<TUserActivityCategory> UserActivityCategories { get; set; }
        public virtual DbSet<TUserActivity> UserActivities { get; set; }
        public virtual DbSet<TUserSetting> UserSettings { get; set; }
        public virtual DbSet<TUserAgreement> UserAgreements { get; set; }
        public virtual DbSet<TUserAgreementVersion> UserAgreementVersions { get; set; }
        public virtual DbSet<TUserAgreementVersionAction> UserAgreementVersionActions { get; set; }

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

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.ToTable("Users", SCHEMA_NAME);
                entity.Property("Id").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TRole>(entity =>
            {
                entity.ToTable("Roles", SCHEMA_NAME);
                entity.Property("Id").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<IdentityUserClaim<TKey>>().ToTable("UserClaims", SCHEMA_NAME);
            modelBuilder.Entity<IdentityUserLogin<TKey>>().ToTable("UserLogins", SCHEMA_NAME);
            modelBuilder.Entity<IdentityUserRole<TKey>>().ToTable("UserRoles", SCHEMA_NAME);
            modelBuilder.Entity<IdentityRoleClaim<TKey>>().ToTable("RoleClaims", SCHEMA_NAME);
            modelBuilder.Entity<IdentityUserToken<TKey>>().ToTable("UserTokens", SCHEMA_NAME);

            modelBuilder.Entity<TUserProfileAttribute>(entity =>
            {
                entity.ToTable("UserProfileAttributes", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

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

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.JobTitle).HasMaxLength(256);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.MiddleName).HasMaxLength(100);

                entity.Property(e => e.OrganizationName).HasMaxLength(256);

                entity.Property(e => e.Salutation).HasMaxLength(50);
            });

            modelBuilder.Entity<TGroup>(entity =>
            {
                entity.ToTable("Groups", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TGroupRole>(entity =>
            {
                entity.ToTable("GroupRoles", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupRoles)
                    .HasForeignKey(d => d.GroupId);
            });

            modelBuilder.Entity<TGroupUser>(entity =>
            {
                entity.ToTable("GroupUsers", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupUsers)
                    .HasForeignKey(d => d.GroupId);
            });

            modelBuilder.Entity<TUserActivity>(entity =>
            {
                entity.ToTable("UserActivities", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

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

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.DeviceAgent).HasMaxLength(500);

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.AccessToken).HasMaxLength(128);

                entity.Property(e => e.SystemSessionId).HasMaxLength(128);
            });

            modelBuilder.Entity<TUserSetting>(entity =>
            {
                entity.ToTable("UserSettings", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TUserAgreementVersionAction>(entity =>
            {
                entity.ToTable("UserAgreementVersionActions", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.UserAgreementVersion)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.UserAgreementVersionId);
            });

            modelBuilder.Entity<TUserAgreementVersion>(entity =>
            {
                entity.ToTable("UserAgreementVersions", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.UserAgreement)
                    .WithMany(p => p.UserAgreementVersions)
                    .HasForeignKey(d => d.UserAgreementId);
            });

            modelBuilder.Entity<TUserAgreement>(entity =>
            {
                entity.ToTable("UserAgreements", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });
        }
    }
}
