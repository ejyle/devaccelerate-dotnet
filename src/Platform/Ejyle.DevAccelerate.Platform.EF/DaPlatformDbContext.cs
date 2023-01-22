// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Platform.Apps;
using Ejyle.DevAccelerate.Platform.Features;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Platform.EF
{
    public class DaPlatformDbContext : DaPlatformDbContext<string, DaApp, DaAppAttribute, DaFeature, DaAppFeature, DaFeatureAction>
    {
        public DaPlatformDbContext()
            : base()
        { }

        public DaPlatformDbContext(DbContextOptions<DaPlatformDbContext> options)
           : base(options)
        { }

        public DaPlatformDbContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class DaPlatformDbContext<TKey, TApp, TAppAttribute, TFeature, TAppFeature, TFeatureAction> : DbContext
        where TKey : IEquatable<TKey>
        where TApp : DaApp<TKey, TAppAttribute, TFeature, TAppFeature>
        where TAppAttribute : DaAppAttribute<TKey, TApp>
        where TAppFeature : DaAppFeature<TKey, TApp, TFeature>
        where TFeatureAction : DaFeatureAction<TKey, TFeature>
        where TFeature : DaFeature<TKey, TApp, TAppFeature, TFeatureAction>
    {
        private const string SCHEMA_NAME = "Da.Platform";

        public DaPlatformDbContext()
            : base()
        { }

        public DaPlatformDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaPlatformDbContext(DbContextOptions<DaPlatformDbContext<TKey, TApp, TAppAttribute, TFeature, TAppFeature, TFeatureAction>> options)
            : base(options)
        { }

        public DaPlatformDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaPlatformDbContext<TKey, TApp, TAppAttribute, TFeature, TAppFeature, TFeatureAction>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaPlatformDbContext<TKey, TApp, TAppAttribute, TFeature, TAppFeature, TFeatureAction>>(), connectionString).Options;
        }

        public virtual DbSet<TAppFeature> AppFeatures { get; set; }
        public virtual DbSet<TApp> Apps { get; set; }
        public virtual DbSet<TAppAttribute> AppAttributes { get; set; }
        public virtual DbSet<TFeatureAction> FeatureActions { get; set; }
        public virtual DbSet<TFeature> Features { get; set; }

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

            modelBuilder.Entity<TAppAttribute>(entity =>
            {
                entity.ToTable("AppAttributes", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.App)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.AppId);
            });

            modelBuilder.Entity<TAppFeature>(entity =>
            {
                entity.ToTable("AppFeatures", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.App)
                    .WithMany(p => p.AppFeatures)
                    .HasForeignKey(d => d.AppId);

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.AppFeatures)
                    .HasForeignKey(d => d.FeatureId);
            });

            modelBuilder.Entity<TApp>(entity =>
            {
                entity.ToTable("Apps", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasIndex(e => e.Key)
                    .IsUnique();
            });

            modelBuilder.Entity<TFeatureAction>(entity =>
            {
                entity.ToTable("FeatureActions", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.FeatureActions)
                    .HasForeignKey(d => d.FeatureId);
            });

            modelBuilder.Entity<TFeature>(entity =>
            {
                entity.ToTable("Features", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.App)
                    .WithMany(p => p.Features)
                    .HasForeignKey(d => d.AppId);
            });
        }
    }
}
