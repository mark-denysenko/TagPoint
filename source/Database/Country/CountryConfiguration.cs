using Domain.Country;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Country
{
    public class CountryConfiguration : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.ToTable("Countries", "Location");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Country).IsRequired().HasMaxLength(128);
            //builder.Property(x => x.CountryCode).IsRequired().HasMaxLength(5);
        }
    }
}
