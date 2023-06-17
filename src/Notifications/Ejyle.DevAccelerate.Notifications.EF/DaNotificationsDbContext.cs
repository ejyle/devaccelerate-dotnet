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
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.Notifications.Requests;
using Ejyle.DevAccelerate.Notifications.Templates;
using Ejyle.DevAccelerate.Notifications.Delivery;

namespace Ejyle.DevAccelerate.Notifications.EF
{
    public class DaNotificationsDbContext
        : DaNotificationsDbContext<string, DaNotificationTemplate, DaNotificationChannelTemplate, DaNotificationRequest, DaNotificationRequestChannel, DaNotificationRequestVariable, DaNotificationRequestRecipient, DaNotificationRequestRecipientVariable, DaNotification>
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

    public class DaNotificationsDbContext<TKey, TNotificationTemplate, TNotificationChannelTemplate, TNotificationRequest, TNotificationRequestChannel, TNotificationRequestVariable, TNotificationRequestRecipient, TNotificationRequestRecipientVariable, TNotification> : DbContext
        where TKey : IEquatable<TKey>
        where TNotificationTemplate : DaNotificationTemplate<TKey, TNotificationChannelTemplate>
        where TNotificationChannelTemplate : DaNotificationChannelTemplate<TKey, TNotificationTemplate>
        where TNotificationRequest : DaNotificationRequest<TKey, TNotificationRequestChannel, TNotificationRequestVariable, TNotificationRequestRecipient>
        where TNotificationRequestChannel : DaNotificationRequestChannel<TKey, TNotificationRequest>
        where TNotificationRequestVariable : DaNotificationRequestVariable<TKey, TNotificationRequest>
        where TNotificationRequestRecipient : DaNotificationRequestRecipient<TKey, TNotificationRequest, TNotificationRequestRecipientVariable>
        where TNotificationRequestRecipientVariable : DaNotificationRequestRecipientVariable<TKey, TNotificationRequestRecipient>
        where TNotification : DaNotification<TKey>
    {
        private const string SCHEMA_NAME = "Da.Notifications";

        public DaNotificationsDbContext() : base()
        { }

        public DaNotificationsDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaNotificationsDbContext(DbContextOptions<DaNotificationsDbContext<TKey, TNotificationTemplate, TNotificationChannelTemplate, TNotificationRequest, TNotificationRequestChannel, TNotificationRequestVariable, TNotificationRequestRecipient, TNotificationRequestRecipientVariable, TNotification>> options)
            : base(options)
        { }

        public DaNotificationsDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaNotificationsDbContext<TKey, TNotificationTemplate, TNotificationChannelTemplate, TNotificationRequest, TNotificationRequestChannel, TNotificationRequestVariable, TNotificationRequestRecipient, TNotificationRequestRecipientVariable, TNotification>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaNotificationsDbContext<TKey, TNotificationTemplate, TNotificationChannelTemplate, TNotificationRequest, TNotificationRequestChannel, TNotificationRequestVariable, TNotificationRequestRecipient, TNotificationRequestRecipientVariable, TNotification>>(), connectionString).Options;
        }

        public virtual DbSet<TNotification> Notifications { get; set; }
        public virtual DbSet<TNotificationRequest> NotificationRequests { get; set; }
        public virtual DbSet<TNotificationTemplate> NotificationTemplates { get; set; }

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
            });


            modelBuilder.Entity<TNotificationChannelTemplate>(entity =>
            {
                entity.ToTable("NotificationChannelTemplates", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Body)
                    .IsRequired();

                entity.Property(e => e.Format)
                    .HasMaxLength(256);

                entity.Property(e => e.Subject)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TNotificationRequest>(entity =>
            {
                entity.ToTable("NotificationRequests", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.VariableDelimiter)
                    .HasMaxLength(5);

                entity.Property(e => e.ObjectIdentifier)
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<TNotificationRequestChannel>(entity =>
            {
                entity.ToTable("NotificationRequestChannels", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Body)
                    .IsRequired();

                entity.Property(e => e.Format)
                    .HasMaxLength(256);

                entity.Property(e => e.Subject)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TNotificationRequestVariable>(entity =>
            {
                entity.ToTable("NotificationRequestVariables", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.HasOne(d => d.NotificationRequest)
                    .WithMany(p => p.Variables)
                    .HasForeignKey(d => d.NotificationRequestId);
            });

            modelBuilder.Entity<TNotificationRequestRecipient>(entity =>
            {
                entity.ToTable("NotificationRequestRecipients", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.RecipientName)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.Property(e => e.RecipientAddress)
                    .HasMaxLength(500)
                    .IsRequired();

                entity.HasOne(d => d.NotificationRequest)
                    .WithMany(p => p.Recipients)
                    .HasForeignKey(d => d.NotificationRequestId);
            });

            modelBuilder.Entity<TNotificationRequestRecipientVariable>(entity =>
            {
                entity.ToTable("NotificationRequestRecipientVariables", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.HasOne(d => d.NotificationRequestRecipient)
                    .WithMany(p => p.Variables)
                    .HasForeignKey(d => d.NotificationRequestRecipientId);
            });

            modelBuilder.Entity<TNotification>(entity =>
            {
                entity.ToTable("Notifications", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Body)
                    .IsRequired();

                entity.Property(e => e.Format)
                    .HasMaxLength(256);

                entity.Property(e => e.Subject)
                    .HasMaxLength(500);
            });
        }
    }
}
