// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core.Objects;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Social.EF
{
    public class DaSocialDbContext : DaSocialDbContext<string, DaPost, DaPostRole, DaPostOrganizationGroup, DaPostMention, DaPostTag>
    {
        public DaSocialDbContext()
            : base()
        { }

        public DaSocialDbContext(DbContextOptions<DaSocialDbContext> options)
           : base(options)
        { }

        public DaSocialDbContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class DaSocialDbContext<TKey, TPost, TPostRole, TPostOrganizationGroup, TPostMention, TPostTag> : DbContext
        where TKey : IEquatable<TKey>
        where TPost : DaPost<TKey, TPostRole, TPostOrganizationGroup, TPostMention, TPostTag>
        where TPostRole : DaPostRole<TKey, TPost>
        where TPostOrganizationGroup : DaPostOrganizationGroup<TKey, TPost>
        where TPostMention : DaPostMention<TKey, TPost>
        where TPostTag : DaPostTag<TKey, TPost>
    {
        private const string SCHEMA_NAME = "Da.Social";

        public DaSocialDbContext()
            : base()
        { }

        public DaSocialDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaSocialDbContext(DbContextOptions<DaSocialDbContext<TKey, TPost, TPostRole, TPostOrganizationGroup, TPostMention, TPostTag>> options)
            : base(options)
        { }

        public DaSocialDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaSocialDbContext<TKey, TPost, TPostRole, TPostOrganizationGroup, TPostMention, TPostTag>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaSocialDbContext<TKey, TPost, TPostRole, TPostOrganizationGroup, TPostMention, TPostTag>>(), connectionString).Options;
        }

        public virtual DbSet<TPost> Posts { get; set; }
        public virtual DbSet<TPostOrganizationGroup> OrganizationGroups { get; set; }
        public virtual DbSet<TPostRole> Roles { get; set; }
        public virtual DbSet<TPostMention> PostMentions { get; set; }
        public virtual DbSet<TPostTag> PostTags { get; set; }

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

                entity.Property(e => e.CreatedBy).IsRequired();
                entity.Property(e => e.CreatedDateUtc).IsRequired();
                entity.Property(e => e.LastUpdatedBy).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).IsRequired();
            });

            modelBuilder.Entity<TPostRole>(entity =>
            {
                entity.ToTable("PostRoles", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<TPostOrganizationGroup>(entity =>
            {
                entity.ToTable("PostOrganizationGroups", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.OrganizationGroupId).HasMaxLength(450);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.OrganizationGroups)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<TPostMention>(entity =>
            {
                entity.ToTable("PostMentions", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Mention).HasMaxLength(450);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Mentions)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<TPostTag>(entity =>
            {
                entity.ToTable("PostTags", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Tag).HasMaxLength(450);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.PostId);
            });
        }
    }
}
