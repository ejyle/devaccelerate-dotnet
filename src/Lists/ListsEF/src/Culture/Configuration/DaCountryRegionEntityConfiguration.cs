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
    public class DaCountryRegionEntityConfiguration<TKey, TNullableKey, TCountryRegion, TCurrency, TCountry, TTimeZone, TSystemLanguage> : EntityTypeConfiguration<TCountryRegion>
        where TKey : IEquatable<TKey>
        where TCurrency : DaCurrency<TKey,TNullableKey, TCountry>
        where TCountry : DaCountry<TKey, TNullableKey, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage>
        where TTimeZone : DaTimeZone<TKey, TNullableKey, TCountry>
        where TCountryRegion : DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TSystemLanguage : DaSystemLanguage<TKey, TNullableKey, TCountry>
    {
        public DaCountryRegionEntityConfiguration(string schemaName) : base()
        {
            var countryRegion = ToTable("CountryRegions", schemaName);

            countryRegion.HasMany(r => r.Children)
                .WithOptional(r => r.Parent)
                .HasForeignKey(r => r.ParentId);

            countryRegion.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(256);

            countryRegion.Property(r => r.RegionCode)
                .HasMaxLength(50);
        }
    }
}
