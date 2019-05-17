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
    public class DaDateFormatEntityConfiguration<TKey, TNullableKey, TDateFormat> : EntityTypeConfiguration<TDateFormat>
        where TKey : IEquatable<TKey>
        where TDateFormat : DaDateFormat<TKey, TNullableKey>
    {
        public DaDateFormatEntityConfiguration(string schemaName)
            : base()
        {
            var dateFormat = ToTable("DateFormats", schemaName);

            dateFormat.Property(df => df.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute($"IX_{schemaName}.DateFormats_Name") { IsUnique = true }));

            dateFormat.Property(df => df.DateFormatExpression)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
