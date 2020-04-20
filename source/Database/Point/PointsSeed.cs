using Domain.Point;
using Domain.Vote;
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

                // Vokzalyna
                x.HasData(new
                {
                    Id = 8L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 8L,
                    Altitude = 0.0,
                    Latitude = 50.441143361690266,
                    Longitude = 30.490863663056775
                });

                // Krest
                x.HasData(new
                {
                    Id = 9L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 9L,
                    Altitude = 0.0,
                    Latitude = 50.45026534358043,
                    Longitude = 30.523908693191213
                });

                // Truhanov
                x.HasData(new
                {
                    Id = 10L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 10L,
                    Altitude = 0.0,
                    Latitude = 50.45924231266672,
                    Longitude = 30.53789255515232
                });

                // Red university
                x.HasData(new
                {
                    Id = 11L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 11L,
                    Altitude = 0.0,
                    Latitude = 50.44199277391987,
                    Longitude = 30.511145857195284
                });

                // National Opera
                x.HasData(new
                {
                    Id = 12L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 12L,
                    Altitude = 0.0,
                    Latitude = 50.4465100689513,
                    Longitude = 30.512378069446477
                });

                // Hidropark
                x.HasData(new
                {
                    Id = 13L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 13L,
                    Altitude = 0.0,
                    Latitude = 50.44445107529402,
                    Longitude = 30.576645012845443
                });

                // Petrovka
                x.HasData(new
                {
                    Id = 14L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 14L,
                    Altitude = 0.0,
                    Latitude = 50.48555779981737,
                    Longitude = 30.497621435018434
                });

                // Olympic stadium
                x.HasData(new
                {
                    Id = 15L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 15L,
                    Altitude = 0.0,
                    Latitude = 50.43362975210512,
                    Longitude = 30.521773531962232
                });

                // Zhuliany
                x.HasData(new
                {
                    Id = 16L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 16L,
                    Altitude = 0.0,
                    Latitude = 50.412129529824426,
                    Longitude = 30.443488524470833
                });

                // Protasiv
                x.HasData(new
                {
                    Id = 17L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 17L,
                    Altitude = 0.0,
                    Latitude = 50.42309410348277,
                    Longitude = 30.50022154882122
                });

                // NAU
                x.HasData(new
                {
                    Id = 18L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 18L,
                    Altitude = 0.0,
                    Latitude = 50.44041448621017,
                    Longitude = 30.429733484641968
                });

                // TSUM
                x.HasData(new
                {
                    Id = 19L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 19L,
                    Altitude = 0.0,
                    Latitude = 50.445347649033494,
                    Longitude = 30.52044238196472
                });

                // Cycletrack
                x.HasData(new
                {
                    Id = 20L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 20L,
                    Altitude = 0.0,
                    Latitude = 50.448779529826595,
                    Longitude = 30.505650357711648
                });

                // Nationa Circus
                x.HasData(new
                {
                    Id = 21L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 21L,
                    Altitude = 0.0,
                    Latitude = 50.44773706128985,
                    Longitude = 30.492595030882566
                });

                // Shulia bridge
                x.HasData(new
                {
                    Id = 22L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 22L,
                    Altitude = 0.0,
                    Latitude = 50.45461720941383,
                    Longitude = 30.445855265689
                });

                // Oceanarium
                x.HasData(new
                {
                    Id = 23L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 23L,
                    Altitude = 0.0,
                    Latitude = 50.45842960112408,
                    Longitude = 30.614189533347695
                });

                // Troya
                x.HasData(new
                {
                    Id = 24L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 24L,
                    Altitude = 0.0,
                    Latitude = 50.5163232688928,
                    Longitude = 30.6050871658709
                });

                // Kyiv Pechersk LAvra
                x.HasData(new
                {
                    Id = 25L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 25L,
                    Altitude = 0.0,
                    Latitude = 50.43450405904663,
                    Longitude = 30.557718644098774
                });

                // Ocean Plaza
                x.HasData(new
                {
                    Id = 26L,
                    UserId = 1L
                });
                x.OwnsOne(y => y.Coordinate).HasData(new
                {
                    PointEntityId = 26L,
                    Altitude = 0.0,
                    Latitude = 50.41222302235643,
                    Longitude = 30.52234968645207
                });

            });
        }
    }
}
