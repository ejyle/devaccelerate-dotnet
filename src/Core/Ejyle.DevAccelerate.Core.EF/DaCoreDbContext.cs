// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core.Objects;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Core.EF
{
    public class DaCoreDbContext : DaCoreDbContext<string, DaObjectType, DaObjectInstance, DaObjectHistoryItem, DaObjectDependency>
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

    public class DaCoreDbContext<TKey, TObjectType, TObjectInstance, TObjectHistoryItem, TObjectDependency> : DbContext
        where TKey : IEquatable<TKey>
        where TObjectType : DaObjectType<TKey, TObjectInstance>
        where TObjectInstance : DaObjectInstance<TKey, TObjectType, TObjectHistoryItem, TObjectDependency>
        where TObjectHistoryItem : DaObjectHistoryItem<TKey, TObjectInstance>
        where TObjectDependency : DaObjectDependency<TKey, TObjectInstance>
    {
        private const string SCHEMA_NAME = "Da.Core";

        public DaCoreDbContext()
            : base()
        { }

        public DaCoreDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaCoreDbContext(DbContextOptions<DaCoreDbContext<TKey, TObjectType, TObjectInstance, TObjectHistoryItem, TObjectDependency>> options)
            : base(options)
        { }

        public DaCoreDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaCoreDbContext<TKey, TObjectType, TObjectInstance, TObjectHistoryItem, TObjectDependency>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaCoreDbContext<TKey, TObjectType, TObjectInstance, TObjectHistoryItem, TObjectDependency>>(), connectionString).Options;
        }

        public virtual DbSet<TObjectType> ObjectTypes { get; set; }
        public virtual DbSet<TObjectInstance> ObjectInstances { get; set; }
        public virtual DbSet<TObjectHistoryItem> ObjectHistoryItems { get; set; }
        public virtual DbSet<TObjectDependency> ObjectDependencies { get; set; }

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

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TObjectHistoryItem>(entity =>
            {
                entity.ToTable("ObjectHistoryItems", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.ObjectInstance)
                    .WithMany(p => p.ObjectHistoryItems)
                    .HasForeignKey(d => d.ObjectInstanceId);

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TObjectDependency>(entity =>
            {
                entity.ToTable("ObjectDependencies", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.ObjectInstance)
                    .WithMany(p => p.ObjectDependencies)
                    .HasForeignKey(d => d.ObjectInstanceId);

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });
        }
    }
}
