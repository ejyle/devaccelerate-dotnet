// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Core.Data.Configuration;
using System;
using System.Data.Entity;

namespace Ejyle.DevAccelerate.Notifications.EF
{
    public class DaNotificationsDbContext : DaNotificationsDbContext<int, int?, DaNotificationSubscriber, DaNotificationEvent, DaNotificationEventSubscriber, DaNotificationSubscriberDestination, DaNotificationItem>
    {
        public DaNotificationsDbContext()
            : base()
        { }

        public DaNotificationsDbContext(string nameOfConnectionString)
            : base(nameOfConnectionString)
        { }
    }

    public class DaNotificationsDbContext<TKey, TNullableKey, TNotificationSubscriber, TNotificationEvent, TNotificationEventSubscriber, TNotificationSubscriberDestination, TNotificationItem>
        : DbContext
        where TKey : IEquatable<TKey>
        where TNotificationSubscriber : DaNotificationSubscriber<TKey, TNotificationEventSubscriber, TNotificationSubscriberDestination>
        where TNotificationEvent : DaNotificationEvent<TKey, TNotificationEventSubscriber>
        where TNotificationSubscriberDestination: DaNotificationSubscriberDestination<TKey, TNotificationSubscriber, TNotificationEventSubscriber>
        where TNotificationEventSubscriber : DaNotificationEventSubscriber<TKey, TNotificationEvent, TNotificationSubscriber, TNotificationSubscriberDestination>
        where TNotificationItem : DaNotificationItem<TKey>
    {
        private const string SCHEMA_NAME = "Notifications";

        public DaNotificationsDbContext()
            : base(DaDbConnectionHelper.GetConnectionString())
        { }

        public DaNotificationsDbContext(string nameOfConnectionString)
            : base(nameOfConnectionString)
        { }

        public virtual DbSet<TNotificationSubscriber> Subscribers { get; set; }
        public virtual DbSet<TNotificationEvent> Events { get; set; }
        public virtual DbSet<TNotificationEventSubscriber> EventSubscribers { get; set; }
        public virtual DbSet<TNotificationSubscriberDestination> ChannelDestinations { get; set; }
        public virtual DbSet<TNotificationItem> Items { get; set; }

        public static DaNotificationsDbContext<TKey, TNullableKey, TNotificationSubscriber, TNotificationEvent, TNotificationEventSubscriber, TNotificationSubscriberDestination, TNotificationItem> Create()
        {
            return new DaNotificationsDbContext<TKey, TNullableKey, TNotificationSubscriber, TNotificationEvent, TNotificationEventSubscriber, TNotificationSubscriberDestination, TNotificationItem>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TNotificationSubscriber>().ToTable("Subscribers", SCHEMA_NAME);
            modelBuilder.Entity<TNotificationSubscriberDestination>().ToTable("SubscriberChannelDestinations", SCHEMA_NAME);
            modelBuilder.Entity<TNotificationEvent>().ToTable("Events", SCHEMA_NAME);
            modelBuilder.Entity<TNotificationEventSubscriber>().ToTable("EventSubscribers", SCHEMA_NAME);
            modelBuilder.Entity<TNotificationItem>().ToTable("Items", SCHEMA_NAME);

            modelBuilder.Entity<TNotificationEvent>()
                .HasMany(e => e.EventSubscribers)
                .WithRequired(e => e.Event)
                .HasForeignKey(e => e.EventId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TNotificationSubscriber>()
                .HasMany(e => e.EventSubscribers)
                .WithRequired(e => e.Subscriber)
                .HasForeignKey(e => e.SubscriberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TNotificationSubscriberDestination>()
                .HasMany(e => e.EventSubscribers)
                .WithRequired(e => e.SubscriberChannelDestination)
                .HasForeignKey(e => e.SubscriberChannelDestinationId)
                .WillCascadeOnDelete(false);
        }
    }
}
