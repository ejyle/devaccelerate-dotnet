// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.Lists.Custom;
using Ejyle.DevAccelerate.Lists.Countries;
using Ejyle.DevAccelerate.Lists.Currencies;
using Ejyle.DevAccelerate.Lists.DateFormats;
using Ejyle.DevAccelerate.Lists.SystemLanguages;
using Ejyle.DevAccelerate.Lists.TimeZones;

namespace Ejyle.DevAccelerate.Lists.EF
{
    /// <summary>
    /// Represents database context for list entities.
    /// </summary>
    public class DaListsDbContext : DaListsDbContext<int, int?, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountry, DaCountryRegion, DaCountryTimeZone, DaCountryDateFormat, DaCountrySystemLanguage, DaCustomList, DaCustomListItem>
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

        /// <summary>
        /// Creates an instance of the <see cref="DaListsDbContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for this context.</param>
        public DaListsDbContext(string connectionString)
            : base(connectionString)
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
    /// <typeparam name="TCustomList">Represents the type of the custom list entity.</typeparam>
    /// <typeparam name="TCustomListItem">Represents the type of the custom list item entity.</typeparam>
    public class DaListsDbContext<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TCustomList, TCustomListItem> : DbContext
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
        where TCustomList : DaCustomList<TKey, TNullableKey, TCustomListItem>
        where TCustomListItem : DaCustomListItem<TKey, TNullableKey, TCustomList>
    {
        private const string SCHEMA_NAME = "Lists";

        /// <summary>
        /// Creates an instance of the <see cref="DaListsDbContext{TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TCustomList, TCustomListItem}"/> class.
        /// </summary>
        public DaListsDbContext() : base()
        { }

        /// <summary>
        /// Creates an instance of the <see cref="DaListsDbContext{TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCustomList, TCustomListItem}"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public DaListsDbContext(DbContextOptions options)
            : base(options)
        { }

        public DaListsDbContext(DbContextOptions<DaListsDbContext<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TCustomList, TCustomListItem>> options)
            : base(options)
        { }

        public DaListsDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        private static DbContextOptions<DaListsDbContext<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TCustomList, TCustomListItem>> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<DaListsDbContext<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TCountryTimeZone, TCountryDateFormat, TCountrySystemLanguage, TCustomList, TCustomListItem>>(), connectionString).Options;
        }

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
        /// Gets or sets the <see cref="DbSet{TCustomList}"/> of custom lists.
        /// </summary>
        public virtual DbSet<TCustomList> CustomLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Ejyle.DevAccelerate;Trusted_Connection = True;MultipleActiveResultSets=True";

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        /// <summary>
        /// Overrides this method to futher configure the <see cref="DbSet{TEntity}"/> properties.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model of the context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TCountry>(entity =>
            {
                entity.ToTable("Countries", SCHEMA_NAME);

                entity.Property(e => e.InternationalDialingCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ThreeLetterCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.TwoLetterCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.CurrencyId);

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.HasIndex(e => e.ThreeLetterCode)
                    .IsUnique();

                entity.HasIndex(e => e.TwoLetterCode)
                    .IsUnique();
            });

            modelBuilder.Entity<TCountryDateFormat>(entity =>
            {
                entity.ToTable("CountryDateFormats", SCHEMA_NAME);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CountryDateFormats)
                    .HasForeignKey(d => d.CountryId);

                entity.HasOne(d => d.DateFormat)
                    .WithMany(p => p.CountryDateFormats)
                    .HasForeignKey(d => d.DateFormatId);
            });

            modelBuilder.Entity<TCountryRegion>(entity =>
            {
                entity.ToTable("CountryRegions", SCHEMA_NAME);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.CountryId);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentId);
            });

            modelBuilder.Entity<TCountrySystemLanguage>(entity =>
            {
                entity.ToTable("CountrySystemLanguages", SCHEMA_NAME);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CountrySystemLanguages)
                    .HasForeignKey(d => d.CountryId);

                entity.HasOne(d => d.SystemLanguage)
                    .WithMany(p => p.CountrySystemLanguages)
                    .HasForeignKey(d => d.SystemLanguageId);
            });

            modelBuilder.Entity<TCountryTimeZone>(entity =>
            {
                entity.ToTable("CountryTimeZones", SCHEMA_NAME);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CountryTimeZones)
                    .HasForeignKey(d => d.CountryId);

                entity.HasOne(d => d.TimeZone)
                    .WithMany(p => p.CountryTimeZones)
                    .HasForeignKey(d => d.TimeZoneId);
            });

            modelBuilder.Entity<TCurrency>(entity =>
            {
                entity.ToTable("Currencies", SCHEMA_NAME);

                entity.Property(e => e.AlphabeticCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CurrencySymbol)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.HasIndex(e => e.AlphabeticCode)
                    .IsUnique();
            });

            modelBuilder.Entity<TDateFormat>(entity =>
            {
                entity.ToTable("DateFormats", SCHEMA_NAME);

                entity.Property(e => e.DateFormatExpression)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.HasIndex(e => e.DateFormatExpression)
                    .IsUnique();
            });

            modelBuilder.Entity<TCustomListItem>(entity =>
            {
                entity.ToTable("GenericListItems", SCHEMA_NAME);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.List)
                    .WithMany(p => p.ListItems)
                    .HasForeignKey(d => d.ListId);
            });

            modelBuilder.Entity<TCustomList>(entity =>
            {
                entity.ToTable("GenericLists", SCHEMA_NAME);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasIndex(e => e.Name)
                    .IsUnique(true);
            });

            modelBuilder.Entity<TSystemLanguage>(entity =>
            {
                entity.ToTable("SystemLanguages", SCHEMA_NAME);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasIndex(e => e.Name)
                    .IsUnique(true);
            });

            modelBuilder.Entity<TTimeZone>(entity =>
            {
                entity.ToTable("TimeZones", SCHEMA_NAME);

                entity.Property(e => e.DaylightName).HasMaxLength(256);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.SystemTimeZoneId).HasMaxLength(256);

                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });
        }
    }
}
