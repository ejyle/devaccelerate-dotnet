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
    public class DaCurrencyEntityConfiguration<TKey, TNullableKey, TCurrency, TCountry, TTimeZone, TCountryRegion, TSystemLanguage> : EntityTypeConfiguration<TCurrency>
        where TKey : IEquatable<TKey>
        where TCurrency : DaCurrency<TKey, TNullableKey, TCountry>
        where TCountry : DaCountry<TKey, TNullableKey, TCurrency, TTimeZone, TCountryRegion, TSystemLanguage>
        where TTimeZone : DaTimeZone<TKey, TNullableKey, TCountry>
        where TCountryRegion : DaCountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TSystemLanguage : DaSystemLanguage<TKey, TNullableKey, TCountry>
    {
        public DaCurrencyEntityConfiguration(string schemaName) : base()
        {
            var currency = ToTable("Currencies", schemaName);

            currency.HasMany(cu => cu.Countries).WithOptional().HasForeignKey(co => co.CurrencyId).WillCascadeOnDelete(false);
 
            currency.Property(cu => cu.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute($"IX_{schemaName}.Currencies_Name") { IsUnique = true }));

            currency.Property(c => c.NativeName)
                .IsRequired()
                .HasMaxLength(256);

            currency.Property(c => c.CurrencyCode)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute($"IX_{schemaName}.Currencies_CurrencyCode") { IsUnique = true }));

            currency.Property(c => c.CurrencySymbol)
                .HasMaxLength(5);
        }
    }
}
