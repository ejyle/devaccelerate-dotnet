// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Comments;
using Ejyle.DevAccelerate.Core;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Comments.EF
{
    public class DaCommentsDbContext
        : DaCommentsDbContext<string, DaCommentThread, DaComment, DaCommentFlag, DaCommentFile>
    {
        public DaCommentsDbContext() : base()
        { }

        public DaCommentsDbContext(DbContextOptions<DaCommentsDbContext> options)
            : base(options)
        { }

        public DaCommentsDbContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class DaCommentsDbContext<TKey, TCommentThread, TComment, TCommentFlag, TCommentFile> : DbContext
        where TKey : IEquatable<TKey>
        where TComment : DaComment<TKey, TComment, TCommentFlag, TCommentFile, TCommentThread>
        where TCommentFlag : DaCommentFlag<TKey, TComment>
        where TCommentFile : DaCommentFile<TKey, TComment>
        where TCommentThread : DaCommentThread<TKey, TComment>
    {
        private const string SCHEMA_NAME = "Da.Comments";

        public DaCommentsDbContext() : base()
        { }

        public DaCommentsDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaCommentsDbContext(DbContextOptions<DaCommentsDbContext<TKey, TCommentThread, TComment, TCommentFlag, TCommentFile>> options)
            : base(options)
        { }

        public DaCommentsDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaCommentsDbContext<TKey, TCommentThread, TComment, TCommentFlag, TCommentFile>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaCommentsDbContext<TKey, TCommentThread, TComment, TCommentFlag, TCommentFile>>(), connectionString).Options;
        }

        public virtual DbSet<TComment> Comments { get; set; }
        public virtual DbSet<TCommentFile> CommentFiles { get; set; }
        public virtual DbSet<TCommentFlag> CommentFlags { get; set; }
        public virtual DbSet<TCommentThread> CommentThreads { get; set; }

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

            modelBuilder.Entity<TComment>(entity =>
            {
                entity.ToTable("Comments", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Message)
                    .IsRequired();

                entity.HasOne(d => d.CommentThread)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CommentThreadId);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentId);

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TCommentFile>(entity =>
            {
                entity.ToTable("CommentFiles", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.CommentId);

                entity.Property(e => e.FileId).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CommentId).IsRequired();

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TCommentFlag>(entity =>
            {
                entity.ToTable("CommentFlags", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Flags)
                    .HasForeignKey(d => d.CommentId);

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TCommentThread>(entity =>
            {
                entity.ToTable("CommentThreads", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Format)
                    .HasMaxLength(256);

                entity.Property(e => e.ObjectIdentifier).HasMaxLength(450);

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });
        }
    }
}
