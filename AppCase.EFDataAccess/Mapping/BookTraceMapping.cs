using AppCase.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.EFDataAccess.Mapping
{
    public class BookTraceMapping : IEntityTypeConfiguration<BookTrace>
    {
        public void Configure(EntityTypeBuilder<BookTrace> builder)
        {
            builder.ToTable("BOOK_TRACES");
            builder.Property(c => c.Id).HasColumnName("ID").HasDefaultValueSql("NEWID()");
            builder.Property(c => c.BookCheckoutDate).HasColumnName("BOOK_CHECKOUT_DATE").IsRequired();
            builder.Property(c => c.BookReturnDate).HasColumnName("BOOK_RETURN_DATE");
            builder.Property(c => c.Calculated).HasColumnName("CALCULATED");
            builder.Property(c => c.CountryId).HasColumnName("COUNTRY_ID").IsRequired();
        }
    }
}
