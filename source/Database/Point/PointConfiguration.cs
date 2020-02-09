using Domain.Point;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Point
{
    public class PointConfiguration : IEntityTypeConfiguration<PointEntity>
    {
        public void Configure(EntityTypeBuilder<PointEntity> builder)
        {
            builder.ToTable("Points", "Location");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.OwnsOne(point => point.Coordinate, coord =>
            {
                coord.Property(x => x.Latitude).HasColumnName(nameof(PointEntity.Coordinate.Latitude)).IsRequired();
                coord.Property(x => x.Longitude).HasColumnName(nameof(PointEntity.Coordinate.Longitude)).IsRequired();
            });
        }
    }
}
