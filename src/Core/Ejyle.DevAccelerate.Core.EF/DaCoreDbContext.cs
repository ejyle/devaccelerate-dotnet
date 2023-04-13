// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core.Objects;
using Ejyle.DevAccelerate.Core.Posts;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Core.EF
{
    public class DaCoreDbContext : DaCoreDbContext<string, DaObjectType, DaObjectInstance, DaObjectHistoryItem, DaObjectDependency, DaPost, DaPostRole, DaPostOrganizationGroup>
    {
        public DaCoreDbContext()
            : base()
        { }

        public DaCoreDbContext(DbContextOptions<DaCoreDbContext> options)
           : base(options)
        { }

        public DaCoreDbContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class DaCoreDbContext<TKey, TObjectType, TObjectInstance, TObjectHistoryItem, TObjectDependency, TPost, TPostRole, TPostOrganizationGroup> : DbContext
        where TKey : IEquatable<TKey>
        where TObjectType : DaObjectType<TKey, TObjectInstance>
        where TObjectInstance : DaObjectInstance<TKey, TObjectType, TObjectHistoryItem, TObjectDependency>
        where TObjectHistoryItem : DaObjectHistoryItem<TKey, TObjectInstance>
        where TObjectDependency : DaObjectDependency<TKey, TObjectInstance>
        where TPost : DaPost<TKey, TPostRole, TPostOrganizationGroup>
        where TPostRole : DaPostRole<TKey, TPost>
        where TPostOrganizationGroup : DaPostOrganizationGroup<TKey, TPost>
    {
        private const string SCHEMA_NAME = "Da.Core";

        public DaCoreDbContext()
            : base()
        { }

        public DaCoreDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaCoreDbContext(DbContextOptions<DaCoreDbContext<TKey, TObjectType, TObjectInstance, TObjectHistoryItem, TObjectDependency, TPost, TPostRole, TPostOrganizationGroup>> options)
            : base(options)
        { }

        public DaCoreDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaCoreDbContext<TKey, TObjectType, TObjectInstance, TObjectHistoryItem, TObjectDependency, TPost, TPostRole, TPostOrganizationGroup>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaCoreDbContext<TKey, TObjectType, TObjectInstance, TObjectHistoryItem, TObjectDependency, TPost, TPostRole, TPostOrganizationGroup>>(), connectionString).Options;
        }

        public virtual DbSet<TObjectType> ObjectTypes { get; set; }
        public virtual DbSet<TObjectInstance> ObjectInstances { get; set; }
        public virtual DbSet<TObjectHistoryItem> ObjectHistoryItems { get; set; }
        public virtual DbSet<TObjectDependency> ObjectDependencies { get; set; }
        public virtual DbSet<TPost> Posts { get; set; }
        public virtual DbSet<TPostOrganizationGroup> OrganizationGroups { get; set; }
        public virtual DbSet<TPostRole> Roles { get; set; }

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

            modelBuilder.Entity<TObjectType>(entity =>
            {
                entity.ToTable("ObjectTypes", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<TObjectInstance>(entity =>
            {
                entity.ToTable("ObjectInstances", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TenantId).HasMaxLength(450);
                entity.Property(e => e.OwnerUserId).HasMaxLength(450);
                entity.Property(e => e.Category).HasMaxLength(256);

                entity.HasOne(d => d.ObjectType)
                    .WithMany(p => p.ObjectInstances)
                    .HasForeignKey(d => d.ObjectTypeId);
            });

            modelBuilder.Entity<TObjectHistoryItem>(entity =>
            {
                entity.ToTable("ObjectHistoryItems", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.ObjectInstance)
                    .WithMany(p => p.ObjectHistoryItems)
                    .HasForeignKey(d => d.ObjectInstanceId);
            });

            modelBuilder.Entity<TObjectDependency>(entity =>
            {
                entity.ToTable("ObjectDependencies", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.ObjectInstance)
                    .WithMany(p => p.ObjectDependencies)
                    .HasForeignKey(d => d.ObjectInstanceId);
            });

            modelBuilder.Entity<TPost>(entity =>
            {
                entity.ToTable("Posts", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Link)
                    .HasMaxLength(500);

                entity.Property(e => e.ActualLink)
                    .HasMaxLength(500);

                entity.Property(e => e.Text)
                    .HasMaxLength(1000);

                entity.Property(e => e.MediaExtension)
                    .HasMaxLength(20);

                entity.Property(e => e.MediaUrl)
                    .HasMaxLength(500);

                entity.Property(e => e.MediaFileId)
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<TPostRole>(entity =>
            {
                entity.ToTable("PostRoles", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<TPostOrganizationGroup>(entity =>
            {
                entity.ToTable("OrganizationGroups", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.OrganizationGroups)
                    .HasForeignKey(d => d.PostId);
            });
        }
    }
}
