// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Ejyle.DevAccelerate.Comments;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Files;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Comments.EF
{
    public class DaFilesDbContext
        : DaFilesDbContext<string, DaFileStorage, DaFileStorageLocation, DaFileStorageAttribute, DaFileCollection, DaFile>
    {
        public DaFilesDbContext() : base()
        { }

        public DaFilesDbContext(DbContextOptions<DaFilesDbContext> options)
            : base(options)
        { }

        public DaFilesDbContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class DaFilesDbContext<TKey, TFileStorage, TFileStorageLocation, TFileStorageAttribute, TFileCollection, TFile> : DbContext
        where TKey : IEquatable<TKey>
        where TFileStorage : DaFileStorage<TKey, TFileStorageLocation, TFileStorageAttribute>
        where TFileStorageLocation : DaFileStorageLocation<TKey, TFileStorage>
        where TFileStorageAttribute : DaFileStorageAttribute<TKey, TFileStorage>
        where TFile : DaFile<TKey, TFileCollection>
        where TFileCollection : DaFileCollection<TKey, TFileCollection, TFile>
    {
        private const string SCHEMA_NAME = "Da.Files";

        public DaFilesDbContext() : base()
        { }

        public DaFilesDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaFilesDbContext(DbContextOptions<DaFilesDbContext<TKey, TFileStorage, TFileStorageLocation, TFileStorageAttribute, TFileCollection, TFile>> options)
            : base(options)
        { }

        public DaFilesDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaFilesDbContext<TKey, TFileStorage, TFileStorageLocation, TFileStorageAttribute, TFileCollection, TFile>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaFilesDbContext<TKey, TFileStorage, TFileStorageLocation, TFileStorageAttribute, TFileCollection, TFile>>(), connectionString).Options;
        }

        public virtual DbSet<TFileStorage> FileStorages { get; set; }
        public virtual DbSet<TFileStorageLocation> FileStorageLocations { get; set; }
        public virtual DbSet<TFileStorageAttribute> FileStorageAttributes { get; set; }
        public virtual DbSet<TFile> Files { get; set; }
        public virtual DbSet<TFileCollection> FileCollections { get; set; }

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

            modelBuilder.Entity<TFile>(entity =>
            {
                entity.ToTable("Files", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasIndex(e => e.GuidFileName)
                    .IsUnique();

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.GuidFileName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.MimeType)
                    .HasMaxLength(256);

                entity.Property(e => e.Extension)
                    .HasMaxLength(50);

                entity.HasOne(d => d.FileCollection)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.FileCollectionId);

                entity.Property(e => e.TenantId)
                    .HasMaxLength(450);

                entity.Property(e => e.OwnerUserId)
                    .HasMaxLength(450)
                    .IsRequired();

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TFileCollection>(entity =>
            {
                entity.ToTable("FileCollections", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentId);

                entity.Property(e => e.TenantId)
                    .HasMaxLength(450);

                entity.Property(e => e.OwnerUserId)
                    .HasMaxLength(450)
                    .IsRequired();

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TFileStorage>(entity =>
            {
                entity.ToTable("FileStorages", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Root)
                    .IsRequired();

                entity.Property(e => e.Platform)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TFileStorageLocation>(entity =>
            {
                entity.ToTable("FileStorageLocations", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.FileStorage)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.FileStorageId);
            });

            modelBuilder.Entity<TFileStorageAttribute>(entity =>
            {
                entity.ToTable("FileStorageAttributes", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.FileStorage)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.FileStorageId);
            });
        }
    }
}
