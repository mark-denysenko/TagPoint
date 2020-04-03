using Domain.Point;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Point
{
    internal static class PointsSeed
    {
        public static void SeedPoints(this ModelBuilder builder)
        {
            builder.Entity<PointEntity>(x =>
            {
                // KPI
                x.HasData(new
                {
                    Id = 1L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 1L,
                    Altitude = 0.0,
                    Latitude = 50.4477020181189,
                    Longitude = 30.4586529645237
                });

                // hostel 20
                x.HasData(new
                {
                    Id = 2L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 2L,
                    Altitude = 0.0,
                    Latitude = 50.4464387572148,
                    Longitude = 30.4501353382044
                });

                // polyana
                x.HasData(new
                {
                    Id = 3L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 3L,
                    Altitude = 0.0,
                    Latitude = 50.4470734141835,
                    Longitude = 30.4538539192094
                });

                // Poltava
                x.HasData(new
                {
                    Id = 4L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 4L,
                    Altitude = 0.0,
                    Latitude = 49.58495931279606,
                    Longitude = 34.491557082023526
                });

                // Odessa
                x.HasData(new
                {
                    Id = 5L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 5L,
                    Altitude = 0.0,
                    Latitude = 46.48395951623806,
                    Longitude = 30.724066257373547
                });

                // Lviv
                x.HasData(new
                {
                    Id = 6L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 6L,
                    Altitude = 0.0,
                    Latitude = 49.83642390694658,
                    Longitude = 24.036011141256388
                });

                // Black Sea treasures
                x.HasData(new
                {
                    Id = 7L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 7L,
                    Altitude = 0.0,
                    Latitude = 43.442949787054694,
                    Longitude = 31.577622498304017
                });
            });
        }
    }
}
