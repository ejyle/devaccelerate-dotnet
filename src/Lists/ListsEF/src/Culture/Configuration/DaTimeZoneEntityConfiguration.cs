// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.List.Culture;

namespace Ejyle.DevAccelerate.List.EF.Culture.Configuration
{
    public class DaTimeZoneEntityConfiguration<TKey, TNullableKey, TTimeZone, TCurrency, TCountry, TCountryRegion, TSystemLanguage> : EntityTypeConfiguration<TTimeZone>
        where TKey : IEquatable<TKey>
        where TCurrency : DaCurrency<TKey, TNullableKey, TCountry>
        where TCountry : DaCountry<TKey, TNullableKey, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage>
        where TTimeZone : DaTimeZone<TKey, TNullableKey, TCountry>
        where TCountryRegion : DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TSystemLanguage : DaSystemLanguage<TKey, TNullableKey, TCountry>
    {
        public DaTimeZoneEntityConfiguration(string schemaName) : base()
        {
            var timeZone = ToTable("TimeZones", schemaName);

            timeZone.Property(gtz => gtz.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute($"IX_{schemaName}.TimeZones_Name") { IsUnique = true }));

            timeZone.Property(gtz => gtz.DisplayName)
                .IsRequired()
                .HasMaxLength(256);

            timeZone.Property(gtz => gtz.DaylightName)
                .HasMaxLength(256);

            timeZone.Property(gtz => gtz.SystemTimeZoneId)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
