using AppCase.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.EFDataAccess.Mapping
{
    public class CountryHolidayMapping : IEntityTypeConfiguration<CountryHoliday>
    {
        public void Configure(EntityTypeBuilder<CountryHoliday> builder)
        {
            builder.ToTable("COUNTRY_HOLIDAYS");
            builder.Property(c => c.Id).HasColumnName("ID").HasDefaultValueSql("NEWID()");
            builder.Property(c => c.CountryId).HasColumnName("COUNTRY_ID").IsRequired();
            builder.Property(c => c.Holiday).HasColumnName("HOLIDAY").IsRequired();
            builder.Property(c => c.HolidayType).HasColumnName("HOLIDAY_TYPE").IsRequired();
        }
    }
}
