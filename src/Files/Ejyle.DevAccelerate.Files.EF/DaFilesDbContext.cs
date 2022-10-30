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
        : DaFilesDbContext<int, int?, DaFileCollection, DaFile>
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

    public class DaFilesDbContext<TKey, TNullableKey, TFileCollection, TFile> : DbContext
        where TKey : IEquatable<TKey>
        where TFile : DaFile<TKey, TNullableKey, TFileCollection>
        where TFileCollection : DaFileCollection<TKey, TNullableKey, TFileCollection, TFile>
    {
        private const string SCHEMA_NAME = "Files";

        public DaFilesDbContext() : base()
        { }

        public DaFilesDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaFilesDbContext(DbContextOptions<DaFilesDbContext<TKey, TNullableKey, TFileCollection, TFile>> options)
            : base(options)
        { }

        public DaFilesDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaFilesDbContext<TKey, TNullableKey, TFileCollection, TFile>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaFilesDbContext<TKey, TNullableKey, TFileCollection, TFile>>(), connectionString).Options;
        }

        public virtual DbSet<TFile> Files { get; set; }
        public virtual DbSet<TFileCollection> FileCollections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TFile>(entity =>
            {
                entity.ToTable("Files", SCHEMA_NAME);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.MimeType)
                    .HasMaxLength(256);

                entity.Property(e => e.Extension)
                    .HasMaxLength(50);

                entity.HasOne(d => d.FileCollection)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.FileCollectionId);
            });

            modelBuilder.Entity<TFileCollection>(entity =>
            {
                entity.ToTable("FileCollections", SCHEMA_NAME);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentId);
            });
        }
    }
}
