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
using Ejyle.DevAccelerate.Notifications.Events;
using Ejyle.DevAccelerate.Notifications.EventDefinitions;
using Ejyle.DevAccelerate.Notifications.Delivery;
using Ejyle.DevAccelerate.Notifications.Subscriptions;

namespace Ejyle.DevAccelerate.Notifications.EF
{
    public class DaNotificationsDbContext
        : DaNotificationsDbContext<string, DaNotificationEventDefinition, DaNotificationEventDefinitionChannel, DaNotificationSubscription, DaNotificationEvent, DaNotificationEventChannel, DaNotificationEventVariable, DaNotificationEventSubscriber, DaNotificationEventSubscriberVariable, DaNotification>
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

    public class DaNotificationsDbContext<TKey, TNotificationEventDefinition, TNotificationEventDefinitionChannel, TNotificationSubscription, TNotificationEvent, TNotificationEventChannel, TNotificationEventVariable, TNotificationEventSubscriber, TNotificationEventSubscriberVariable, TNotification> : DbContext
        where TKey : IEquatable<TKey>
        where TNotificationEventDefinition : DaNotificationEventDefinition<TKey, TNotificationEventDefinitionChannel>
        where TNotificationEventDefinitionChannel : DaNotificationEventDefinitionChannel<TKey, TNotificationEventDefinition>
        where TNotificationSubscription : DaNotificationSubscription<TKey>
        where TNotificationEvent : DaNotificationEvent<TKey, TNotificationEventChannel, TNotificationEventVariable, TNotificationEventSubscriber>
        where TNotificationEventChannel : DaNotificationEventChannel<TKey, TNotificationEvent>
        where TNotificationEventVariable : DaNotificationEventVariable<TKey, TNotificationEvent>
        where TNotificationEventSubscriber : DaNotificationEventSubscriber<TKey, TNotificationEvent, TNotificationEventSubscriberVariable>
        where TNotificationEventSubscriberVariable : DaNotificationEventSubscriberVariable<TKey, TNotificationEventSubscriber>
        where TNotification : DaNotification<TKey>
    {
        private const string SCHEMA_NAME = "Da.Notifications";

        public DaNotificationsDbContext() : base()
        { }

        public DaNotificationsDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaNotificationsDbContext(DbContextOptions<DaNotificationsDbContext<TKey, TNotificationEventDefinition, TNotificationEventDefinitionChannel, TNotificationSubscription, TNotificationEvent, TNotificationEventChannel, TNotificationEventVariable, TNotificationEventSubscriber, TNotificationEventSubscriberVariable, TNotification>> options)
            : base(options)
        { }

        public DaNotificationsDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaNotificationsDbContext<TKey, TNotificationEventDefinition, TNotificationEventDefinitionChannel, TNotificationSubscription, TNotificationEvent, TNotificationEventChannel, TNotificationEventVariable, TNotificationEventSubscriber, TNotificationEventSubscriberVariable, TNotification>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaNotificationsDbContext<TKey, TNotificationEventDefinition, TNotificationEventDefinitionChannel, TNotificationSubscription, TNotificationEvent, TNotificationEventChannel, TNotificationEventVariable, TNotificationEventSubscriber, TNotificationEventSubscriberVariable, TNotification>>(), connectionString).Options;
        }

        public virtual DbSet<TNotification> Notifications { get; set; }
        public virtual DbSet<TNotificationEvent> NotificationEvents { get; set; }
        public virtual DbSet<TNotificationSubscription> NotificationSubscriptions { get; set; }
        public virtual DbSet<TNotificationEventDefinition> NotificationEventDefinitions { get; set; }

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

            modelBuilder.Entity<TNotificationEventDefinition>(entity =>
            {
                entity.ToTable("EventDefinitions", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.Property(e => e.VariableDelimiter)
                    .HasMaxLength(5);

                entity.HasIndex(e => e.Name).IsUnique();
            });


            modelBuilder.Entity<TNotificationEventDefinitionChannel>(entity =>
            {
                entity.ToTable("EventDefinitionChannels", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Body)
                    .IsRequired();

                entity.Property(e => e.Format)
                    .HasMaxLength(256);

                entity.Property(e => e.Subject)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TNotificationSubscription>(entity =>
            {
                entity.ToTable("Subscriptions", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .IsRequired();
            });

            modelBuilder.Entity<TNotificationEvent>(entity =>
            {
                entity.ToTable("Events", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.VariableDelimiter)
                    .HasMaxLength(5);

                entity.Property(e => e.ObjectIdentifier)
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<TNotificationEventChannel>(entity =>
            {
                entity.ToTable("EventChannels", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Body)
                    .IsRequired();

                entity.Property(e => e.Format)
                    .HasMaxLength(256);

                entity.Property(e => e.Subject)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TNotificationEventVariable>(entity =>
            {
                entity.ToTable("EventVariables", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.HasOne(d => d.NotificationEvent)
                    .WithMany(p => p.Variables)
                    .HasForeignKey(d => d.NotificationEventId);
            });

            modelBuilder.Entity<TNotificationEventSubscriber>(entity =>
            {
                entity.ToTable("EventSubscribers", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.SubscriberName)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.Property(e => e.SubscriberAddress)
                    .HasMaxLength(500)
                    .IsRequired();

                entity.HasOne(d => d.NotificationEvent)
                    .WithMany(p => p.Subscribers)
                    .HasForeignKey(d => d.NotificationEventId);
            });

            modelBuilder.Entity<TNotificationEventSubscriberVariable>(entity =>
            {
                entity.ToTable("EventSubscriberVariables", SCHEMA_NAME);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.HasOne(d => d.NotificationEventSubscriber)
                    .WithMany(p => p.Variables)
                    .HasForeignKey(d => d.NotificationEventSubscriberId);
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
