// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.Lists.Culture;
using Ejyle.DevAccelerate.Lists.Generic;

namespace Ejyle.DevAccelerate.Lists.EF
{
    /// <summary>
    /// Represents database context for list entities.
    /// </summary>
    public class DaListsDbContext : DaListsDbContext<int, int?, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountry, DaCountryRegion, DaCountryTimeZone, DaCountryDateFormat, DaCountrySystemLanguage, DaGenericList, DaGenericListItem>
    {
        public DaListsDbContext() : base()
        { }

        /// <summary>
        /// Creates an instance of the <see cref="DaListsDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public DaListsDbContext(DbContextOptions<DaListsDbContext> options)
            : base(options)
        { }
    }

    /// <summary>
    /// Represents the database context for list entities.
    /// </summary>
    /// <typeparam name="TKey">Represents a non-nullable type of an entity ID.</typeparam>
    /// <typeparam name="TNullableKey">Represents a nullable type for an entity ID.</typeparam>
    /// <typeparam name="TTimeZone">Represents the type of the time zone entity.</typeparam>
    /// <typeparam name="TDateFormat">Represents the type of the date format entity.</typeparam>
    /// <typeparam name="TSystemLanguage">Represents the type of the system language entity.</typeparam>
    /// <typeparam name="TCurrency">Represents the type of the currency entity.</typeparam>
    /// <typeparam name="TCountry">Represents the type of the country entity.</typeparam>
    /// <typeparam name="TCountryRegion">Represents the type of the country region entity.</typeparam>
    /// <typeparam name="TGenericList">Represents the type of the generic list entity.</typeparam>
    /// <typeparam name="TGenericListItem">Represents the type of the generic list item entity.</typeparam>
    public class DaListsDbContext<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TGenericList, TGenericListItem> : DbContext
        where TKey : IEquatable<TKey>
        where TTimeZone : DaTimeZone<TKey, TCountryTimeZone>
        where TDateFormat : DaDateFormat<TKey, TCountryDateFormat>
        where TSystemLanguage : DaSystemLanguage<TKey, TCountrySystemLanguage>
        where TCurrency : DaCurrency<TKey, TNullableKey, TCountry>
        where TCountry : DaCountry<TKey, TNullableKey, TCurrency, TCountryTimeZone, TCountryRegion, TCountrySystemLanguage, TCountryDateFormat>
        where TCountryRegion : DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TCountryTimeZone : DaCountryTimeZone<TKey, TNullableKey, TCountry, TTimeZone>
        where TCountryDateFormat : DaCountryDateFormat<TKey, TNullableKey, TCountry, TDateFormat>
        where TCountrySystemLanguage : DaCountrySystemLanguage<TKey, TNullableKey, TCountry, TSystemLanguage>
        where TGenericList : DaGenericList<TKey, TGenericListItem>
        where TGenericListItem : DaGenericListItem<TKey, TGenericList>
    {
        private const string SCHEMA_NAME = "Lists";

        /// <summary>
        /// Creates an instance of the <see cref="DaListsDbContext{TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TGenericList, TGenericListItem}"/> class.
        /// </summary>
        public DaListsDbContext() : base()
        { }

        /// <summary>
        /// Creates an instance of the <see cref="DaListsDbContext{TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TGenericList, TGenericListItem}"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public DaListsDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaListsDbContext(DbContextOptions<DaListsDbContext<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TGenericList, TGenericListItem>> options)
            : base(options)
        { }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TTimeZone}"/> of time zones.
        /// </summary>
        public virtual DbSet<TTimeZone> TimeZones { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="DbSet{TSystemLanguage}"/> of system languages.
        /// </summary>
        public virtual DbSet<TSystemLanguage> SystemLanguages { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TCountry}"/> of countries.
        /// </summary>
        public virtual DbSet<TCountry> Countries { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TCountryRegion}"/> of country regions.
        /// </summary>
        public virtual DbSet<TCountryRegion> CountryRegions { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TCurrency}"/> of currencies.
        /// </summary>
        public virtual DbSet<TCurrency> Currencies { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TDateFormat}"/> of date formats.
        /// </summary>
        public virtual DbSet<TDateFormat> DateFormats { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TGenericList}"/> of generic lists.
        /// </summary>
        public virtual DbSet<TGenericList> GenericLists { get; set; }

        /// <summary>
        /// Overrides this method to futher configure the <see cref="DbSet{TEntity}"/> properties.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model of the context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TCurrency>().ToTable("Currencies", SCHEMA_NAME);
            modelBuilder.Entity<TDateFormat>().ToTable("DateFormats", SCHEMA_NAME);
            modelBuilder.Entity<TSystemLanguage>().ToTable("SystemLanguages", SCHEMA_NAME);
            modelBuilder.Entity<TTimeZone>().ToTable("TimeZones", SCHEMA_NAME);

            modelBuilder.Entity<TCountry>().ToTable("Countries", SCHEMA_NAME);
            modelBuilder.Entity<TCountryRegion>().ToTable("CountryRegions", SCHEMA_NAME);
            modelBuilder.Entity<TCountryDateFormat>().ToTable("CountryDateFormats", SCHEMA_NAME);
            modelBuilder.Entity<TCountryTimeZone>().ToTable("CountryTimeZones", SCHEMA_NAME);
            modelBuilder.Entity<TCountrySystemLanguage>().ToTable("CountrySystemLanguages", SCHEMA_NAME);

            modelBuilder.Entity<TGenericList>().ToTable("GenericLists", SCHEMA_NAME);
            modelBuilder.Entity<TGenericListItem>().ToTable("GenericListItems", SCHEMA_NAME);

            modelBuilder.Entity<TCountry>()
                .HasOne(p => p.Currency)
                .WithMany(b => b.Countries)
                .HasForeignKey(p => p.CurrencyId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TCountryRegion>()
                .HasOne(p => p.Country)
                .WithMany(b => b.Regions)
                .HasForeignKey(p => p.CountryId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TCountryRegion>()
                .HasOne(p => p.Parent)
                .WithMany(b => b.Children)
                .HasForeignKey(p => p.ParentId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TCountryDateFormat>()
                .HasOne(p => p.Country)
                .WithMany(b => b.CountryDateFormats)
                .HasForeignKey(p => p.CountryId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TCountryDateFormat>()
                .HasOne(p => p.DateFormat)
                .WithMany(b => b.CountryDateFormats)
                .HasForeignKey(p => p.DateFormatId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TCountrySystemLanguage>()
                .HasOne(p => p.Country)
                .WithMany(b => b.CountrySystemLanguages)
                .HasForeignKey(p => p.CountryId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TCountrySystemLanguage>()
                .HasOne(p => p.SystemLanguage)
                .WithMany(b => b.CountrySystemLanguages)
                .HasForeignKey(p => p.SystemLanguageId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TCountryTimeZone>()
                .HasOne(p => p.Country)
                .WithMany(b => b.CountryTimeZones)
                .HasForeignKey(p => p.CountryId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TCountryTimeZone>()
                .HasOne(p => p.TimeZone)
                .WithMany(b => b.CountryTimeZones)
                .HasForeignKey(p => p.TimeZoneId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<TGenericListItem>()
                .HasOne(p => p.List)
                .WithMany(b => b.ListItems)
                .HasForeignKey(p => p.ListId)
                .HasPrincipalKey(b => b.Id);
        }
    }
}
