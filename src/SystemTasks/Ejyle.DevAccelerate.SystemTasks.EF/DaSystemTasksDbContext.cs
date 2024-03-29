﻿// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Ejyle.DevAccelerate.SystemTasks.EF
{
    public class DaSystemTasksDbContext
        : DaSystemTasksDbContext<long, DaSystemTaskDefinition, DaSystemTaskDefinitionAttribute>
    {
        public DaSystemTasksDbContext() : base()
        { }

        public DaSystemTasksDbContext(DbContextOptions<DaSystemTasksDbContext> options)
            : base(options)
        { }

        public DaSystemTasksDbContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class DaSystemTasksDbContext<TKey, TSystemTaskDefinition, TSystemTaskDefinitionAttribute> : DbContext
        where TKey : IEquatable<TKey>
        where TSystemTaskDefinition : DaSystemTaskDefinition<TKey, TSystemTaskDefinitionAttribute>
        where TSystemTaskDefinitionAttribute : DaSystemTaskAttribute<TKey, TSystemTaskDefinition>
    {
        private const string SCHEMA_NAME = "Da.SystemTasks";

        public DaSystemTasksDbContext() : base()
        { }

        public DaSystemTasksDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaSystemTasksDbContext(DbContextOptions<DaSystemTasksDbContext<TKey, TSystemTaskDefinition, TSystemTaskDefinitionAttribute>> options)
            : base(options)
        { }

        public DaSystemTasksDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaSystemTasksDbContext<TKey, TSystemTaskDefinition, TSystemTaskDefinitionAttribute>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaSystemTasksDbContext<TKey, TSystemTaskDefinition, TSystemTaskDefinitionAttribute>>(), connectionString).Options;
        }

        public virtual DbSet<TSystemTaskDefinition> SystemTaskDefinitions { get; set; }
        public virtual DbSet<TSystemTaskDefinitionAttribute> SystemTaskDefinitionAttributes { get; set; }

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

            modelBuilder.Entity<TSystemTaskDefinition>(entity =>
            {
                entity.ToTable("SystemTaskDefinitions", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.SystemTaskType)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SystemTaskDataType)
                    .HasMaxLength(500);

                entity.Property(e => e.ErrorDataType)
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<TSystemTaskDefinitionAttribute>(entity =>
            {
                entity.ToTable("SystemTaskDefinitionAttributes", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.SystemTask)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.SystemTaskId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
