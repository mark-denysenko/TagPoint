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
            builder.Property(x => x.Created).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.TotalViews).IsRequired().HasDefaultValue(0L);

            builder.OwnsOne(point => point.Coordinate, coord =>
            {
                coord.Property(x => x.Latitude).HasColumnName(nameof(PointEntity.Coordinate.Latitude)).IsRequired();
                coord.Property(x => x.Longitude).HasColumnName(nameof(PointEntity.Coordinate.Longitude)).IsRequired();
            });

            //builder.HasMany(p => p.Posts).WithOne(p => p.Point).HasForeignKey(p => p.PointId).OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(p => p.User).WithMany(p => p.Points).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
