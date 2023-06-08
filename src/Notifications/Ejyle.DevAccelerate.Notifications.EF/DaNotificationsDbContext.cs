// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Ejyle.DevAccelerate.Notifications;
using Ejyle.DevAccelerate.Core;
using Microsoft.EntityFrameworkCore;

namespace Ejyle.DevAccelerate.Notifications.EF
{
    public class DaNotificationsDbContext
        : DaNotificationsDbContext<string, DaNotificationTemplate, DaNotification, DaNotificationVariable, DaNotificationRecipient, DaNotificationRecipientVariable>
    {
        public DaNotificationsDbContext() : base()
        { }

        public DaNotificationsDbContext(DbContextOptions<DaNotificationsDbContext> options)
            : base(options)
        { }

        public DaNotificationsDbContext(string connectionString)
            : base(connectionString)
        { }
    }

    public class DaNotificationsDbContext<TKey, TNotificationTemplate, TNotification, TNotificationVariable, TNotificationRecipient, TNotificationRecipientVariable> : DbContext
        where TKey : IEquatable<TKey>
        where TNotificationTemplate : DaNotificationTemplate<TKey>
        where TNotification : DaNotification<TKey, TNotificationVariable, TNotificationRecipient>
        where TNotificationVariable : DaNotificationVariable<TKey, TNotification>
        where TNotificationRecipient : DaNotificationRecipient<TKey, TNotification, TNotificationRecipientVariable>
        where TNotificationRecipientVariable : DaNotificationRecipientVariable<TKey, TNotificationRecipient>
    {
        private const string SCHEMA_NAME = "Da.Notifications";

        public DaNotificationsDbContext() : base()
        { }

        public DaNotificationsDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaNotificationsDbContext(DbContextOptions<DaNotificationsDbContext<TKey, TNotificationTemplate, TNotification, TNotificationVariable, TNotificationRecipient, TNotificationRecipientVariable>> options)
            : base(options)
        { }

        public DaNotificationsDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaNotificationsDbContext<TKey, TNotificationTemplate, TNotification, TNotificationVariable, TNotificationRecipient, TNotificationRecipientVariable>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaNotificationsDbContext<TKey, TNotificationTemplate, TNotification, TNotificationVariable, TNotificationRecipient, TNotificationRecipientVariable>>(), connectionString).Options;
        }

        public virtual DbSet<TNotification> Notifications { get; set; }
        public virtual DbSet<TNotificationTemplate> NotificationTemplates { get; set; }
        public virtual DbSet<TNotificationVariable> NotificationVariables { get; set; }
        public virtual DbSet<TNotificationRecipient> NotificationRecipients { get; set; }
        public virtual DbSet<TNotificationRecipientVariable> NotificationRecipientVariables { get; set; }

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

            modelBuilder.Entity<TNotificationTemplate>(entity =>
            {
                entity.ToTable("NotificationTemplates", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.Property(e => e.Key)
                    .HasMaxLength(128)
                    .IsRequired();

                entity.Property(e => e.VariableDelimiter)
                    .HasMaxLength(5);

                entity.HasIndex(e => e.Key).IsUnique();

                entity.Property(e => e.Body)
                    .IsRequired();

                entity.Property(e => e.Format)
                    .HasMaxLength(256);

                entity.Property(e => e.Channel)
                    .HasMaxLength(256);

                entity.Property(e => e.Subject)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TNotification>(entity =>
            {
                entity.ToTable("Notifications", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Body)
                    .IsRequired();

                entity.Property(e => e.VariableDelimiter)
                    .HasMaxLength(5);

                entity.Property(e => e.Format)
                    .HasMaxLength(256);

                entity.Property(e => e.ObjectIdentifier)
                    .HasMaxLength(450);

                entity.Property(e => e.Subject)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TNotificationVariable>(entity =>
            {
                entity.ToTable("NotificationVariables", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.Variables)
                    .HasForeignKey(d => d.NotificationId);
            });

            modelBuilder.Entity<TNotificationRecipient>(entity =>
            {
                entity.ToTable("NotificationRecipients", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.RecipientName)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.Property(e => e.RecipientAddress)
                    .HasMaxLength(500)
                    .IsRequired();

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.Recipients)
                    .HasForeignKey(d => d.NotificationId);
            });

            modelBuilder.Entity<TNotificationRecipientVariable>(entity =>
            {
                entity.ToTable("NotificationRecipientVariables", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.HasOne(d => d.NotificationRecipient)
                    .WithMany(p => p.Variables)
                    .HasForeignKey(d => d.NotificationRecipientId);
            });
        }
    }
}
