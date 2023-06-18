// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Tasks.EF
{
    public class DaTasksDbContext
        : DaTasksDbContext<string, DaTask>
    {
        public DaTasksDbContext() : base()
        { }

        public DaTasksDbContext(DbContextOptions<DaTasksDbContext> options)
            : base(options)
        { }

        public DaTasksDbContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class DaTasksDbContext<TKey, TTask> : DbContext
        where TKey : IEquatable<TKey>
        where TTask : DaTask<TKey>
    {
        private const string SCHEMA_NAME = "Da.Tasks";

        public DaTasksDbContext() : base()
        { }

        public DaTasksDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaTasksDbContext(DbContextOptions<DaTasksDbContext<TKey, TTask>> options)
            : base(options)
        { }

        public DaTasksDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaTasksDbContext<TKey, TTask>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaTasksDbContext<TKey, TTask>>(), connectionString).Options;
        }

        public virtual DbSet<TTask> Tasks { get; set; }

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

            modelBuilder.Entity<TTask>(entity =>
            {
                entity.ToTable("Tasks", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Category)
                    .HasMaxLength(256);

                entity.Property(e => e.ApiUrl)
                    .HasMaxLength(500);

                entity.Property(e => e.PageUrl)
                    .HasMaxLength(500);

                entity.Property(e => e.StatusReason)
                    .HasMaxLength(500);

                entity.Property(e => e.ObjectIdentifier).HasMaxLength(450);
                entity.Property(e => e.AssignedTo).HasMaxLength(450);
                entity.Property(e => e.OwnerUserId).HasMaxLength(450).IsRequired();
                entity.Property(e => e.TenantId).HasMaxLength(450);

                entity.Property(e => e.CreatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450).IsRequired();
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });
        }
    }
}
