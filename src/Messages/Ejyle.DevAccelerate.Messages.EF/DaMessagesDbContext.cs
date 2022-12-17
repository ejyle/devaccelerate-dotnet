// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Ejyle.DevAccelerate.Messages;
using Ejyle.DevAccelerate.Core;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Messages.EF
{
    public class DaMessagesDbContext
        : DaMessagesDbContext<string, DaMessageTemplate, DaMessage, DaMessageVariable, DaMessageRecipient, DaMessageRecipientVariable>
    {
        public DaMessagesDbContext() : base()
        { }

        public DaMessagesDbContext(DbContextOptions<DaMessagesDbContext> options)
            : base(options)
        { }

        public DaMessagesDbContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class DaMessagesDbContext<TKey, TMessageTemplate, TMessage, TMessageVariable, TMessageRecipient, TMessageRecipientVariable> : DbContext
        where TKey : IEquatable<TKey>
        where TMessageTemplate : DaMessageTemplate<TKey>
        where TMessage : DaMessage<TKey, TMessageVariable, TMessageRecipient>
        where TMessageVariable : DaMessageVariable<TKey, TMessage>
        where TMessageRecipient : DaMessageRecipient<TKey, TMessage, TMessageRecipientVariable>
        where TMessageRecipientVariable : DaMessageRecipientVariable<TKey, TMessageRecipient>
    {
        private const string SCHEMA_NAME = "Messages";

        public DaMessagesDbContext() : base()
        { }

        public DaMessagesDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaMessagesDbContext(DbContextOptions<DaMessagesDbContext<TKey, TMessageTemplate, TMessage, TMessageVariable, TMessageRecipient, TMessageRecipientVariable>> options)
            : base(options)
        { }

        public DaMessagesDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaMessagesDbContext<TKey, TMessageTemplate, TMessage, TMessageVariable, TMessageRecipient, TMessageRecipientVariable>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaMessagesDbContext<TKey, TMessageTemplate, TMessage, TMessageVariable, TMessageRecipient, TMessageRecipientVariable>>(), connectionString).Options;
        }

        public virtual DbSet<TMessage> Messages { get; set; }
        public virtual DbSet<TMessageTemplate> MessageTemplates { get; set; }
        public virtual DbSet<TMessageVariable> MessageVariables { get; set; }
        public virtual DbSet<TMessageRecipient> MessageRecipients { get; set; }
        public virtual DbSet<TMessageRecipientVariable> MessageRecipientVariables { get; set; }

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

            modelBuilder.Entity<TMessageTemplate>(entity =>
            {
                entity.ToTable("MessageTemplates", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.Property(e => e.Message)
                    .IsRequired();

                entity.Property(e => e.Format)
                    .HasMaxLength(256);

                entity.Property(e => e.Category)
                    .HasMaxLength(256);

                entity.Property(e => e.Subject)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TMessage>(entity =>
            {
                entity.ToTable("Messages", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Message)
                    .IsRequired();

                entity.Property(e => e.Format)
                    .HasMaxLength(256);

                entity.Property(e => e.Category)
                    .HasMaxLength(256);

                entity.Property(e => e.Subject)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TMessageVariable>(entity =>
            {
                entity.ToTable("MessageVariables", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Variables)
                    .HasForeignKey(d => d.MessageId);
            });

            modelBuilder.Entity<TMessageRecipient>(entity =>
            {
                entity.ToTable("MessageRecipients", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.RecipientName)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.Property(e => e.RecipientAddress)
                    .HasMaxLength(500)
                    .IsRequired();

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Recipients)
                    .HasForeignKey(d => d.MessageId);
            });

            modelBuilder.Entity<TMessageRecipientVariable>(entity =>
            {
                entity.ToTable("MessageRecipientVariables", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.HasOne(d => d.MessageRecipient)
                    .WithMany(p => p.Variables)
                    .HasForeignKey(d => d.MessageRecipientId);
            });
        }
    }
}
