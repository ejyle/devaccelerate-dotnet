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
    public class DaCountryEntityConfiguration<TKey, TNullableKey, TCountry, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage> : EntityTypeConfiguration<TCountry>
        where TKey : IEquatable<TKey>
        where TCountry : DaCountry<TKey, TNullableKey, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage>
        where TCurrency : DaCurrency<TKey, TNullableKey, TCountry>
        where TTimeZone : DaTimeZone<TKey, TNullableKey, TCountry>
        where TCountryRegion : DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TSystemLanguage : DaSystemLanguage<TKey, TNullableKey, TCountry>
    {
        public DaCountryEntityConfiguration(string schemaName)
            : base()
        {
            var country = ToTable("Countries", schemaName);

            country.HasMany<TTimeZone>(c => c.TimeZones)
                .WithMany(c => c.Countries)
                .Map(cs =>
                {
                    cs.MapLeftKey("CountryId");
                    cs.MapRightKey("TimeZoneId");
                    cs.ToTable("CountryTimeZones", schemaName);
                });

            country.HasMany<TSystemLanguage>(c => c.SystemLanguages)
                .WithMany(c => c.Countries)
                .Map(cs =>
                {
                    cs.MapLeftKey("CountryId");
                    cs.MapRightKey("SystemLanguageId");
                    cs.ToTable("CountrySystemLanguages", schemaName);
                });

            country.HasMany(cu => cu.Regions).WithRequired().HasForeignKey(co => co.CountryId).WillCascadeOnDelete(false);

            country.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute($"IX_{schemaName}.Countries_Name") { IsUnique = true }));

            country.Property(c => c.DialingCode)
                .IsOptional()
                .HasMaxLength(10);

            country.Property(c => c.TwoLetterCode)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute($"IX_{schemaName}.Countries_TwoLetterCode") { IsUnique = true }));

            country.Property(c => c.ThreeLetterCode)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute($"IX_{schemaName}.Countries_ThreeLetterCode") { IsUnique = true }));
        }
    }
}
