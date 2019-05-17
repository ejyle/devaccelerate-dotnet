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
    public class DaSystemLanguageEntityConfiguration<TKey, TNullableKey, TSystemLanguage, TCurrency, TCountry, TTimeZone, TCountryRegion> : EntityTypeConfiguration<TSystemLanguage>
        where TKey : IEquatable<TKey>
        where TCurrency : DaCurrency<TKey, TNullableKey, TCountry>
        where TCountry : DaCountry<TKey, TNullableKey, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage>
        where TTimeZone : DaTimeZone<TKey, TNullableKey, TCountry>
        where TCountryRegion : DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TSystemLanguage : DaSystemLanguage<TKey, TNullableKey, TCountry>
    {
        public DaSystemLanguageEntityConfiguration(string schemaName) : base()
        {
            var systemLanguage = ToTable("SystemLanguages", schemaName);

            systemLanguage.Property(sl => sl.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute($"IX_{schemaName}.SystemLanguages_Name") { IsUnique = true }));

            systemLanguage.Property(sl => sl.DisplayName)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
