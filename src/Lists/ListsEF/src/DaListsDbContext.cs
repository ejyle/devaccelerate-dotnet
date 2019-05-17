// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.List.Culture;
using Ejyle.DevAccelerate.List.EF.Culture.Configuration;

namespace Ejyle.DevAccelerate.List.EF
{
    public class DaListsDbContext : DaListsDbContext<int, int?, DaTimeZone, DaDateFormat, DaSystemLanguage, DaCurrency, DaCountry, DaCountryRegion>
    {
        public DaListsDbContext()
            : base()
        {
        }

        public DaListsDbContext(string nameOfConnectionString)
            : base(nameOfConnectionString)
        { }

        public static DaListsDbContext Create()
        {
            return new DaListsDbContext();
        }
    }

    public class DaListsDbContext<TKey, TNullableKey, TTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion> : DbContext
        where TKey : IEquatable<TKey>
        where TTimeZone : DaTimeZone<TKey, TNullableKey, TCountry>
        where TDateFormat : DaDateFormat<TKey, TNullableKey>
        where TSystemLanguage : DaSystemLanguage<TKey, TNullableKey, TCountry>
        where TCurrency : DaCurrency<TKey, TNullableKey, TCountry>, new()
        where TCountry : DaCountry<TKey, TNullableKey, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage>
        where TCountryRegion : DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
    {
        private const string SCHEMA_NAME = "Lists";

        public DaListsDbContext()
            : base(DaDbConnectionHelper.GetConnectionString())
        {
        }

        public DaListsDbContext(string nameOfConnectionString)
            : base(nameOfConnectionString)
        { }

        public virtual DbSet<TTimeZone> TimeZones { get; set; }
        public virtual DbSet<TSystemLanguage> SystemLanguages { get; set; }
        public virtual DbSet<TCountry> Countries { get; set; }
        public virtual DbSet<TCountryRegion> CountryRegions { get; set; }
        public virtual DbSet<TCurrency> Currencies { get; set; }
        public virtual DbSet<TDateFormat> DateFormats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new DaCurrencyEntityConfiguration<TKey, TNullableKey, TCurrency, TCountry, TTimeZone, TCountryRegion, TSystemLanguage>(SCHEMA_NAME));
            modelBuilder.Configurations.Add(new DaCountryEntityConfiguration<TKey, TNullableKey, TCountry, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage>(SCHEMA_NAME));
            modelBuilder.Configurations.Add(new DaCountryRegionEntityConfiguration<TKey, TNullableKey, TCountryRegion, TCurrency, TCountry, TTimeZone, TSystemLanguage>(SCHEMA_NAME));
            modelBuilder.Configurations.Add(new DaTimeZoneEntityConfiguration<TKey, TNullableKey, TTimeZone, TCurrency, TCountry, TCountryRegion, TSystemLanguage>(SCHEMA_NAME));
            modelBuilder.Configurations.Add(new DaSystemLanguageEntityConfiguration<TKey, TNullableKey, TSystemLanguage, TCurrency, TCountry, TTimeZone, TCountryRegion>(SCHEMA_NAME));
            modelBuilder.Configurations.Add(new DaDateFormatEntityConfiguration<TKey, TNullableKey, TDateFormat>(SCHEMA_NAME));
        }
    }
}
