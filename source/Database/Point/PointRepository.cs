using Domain.Point;
using Domain.ValueObjects;
using DotNetCore.EntityFrameworkCore;
using DotNetCoreArchitecture.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Point
{
    public class PointRepository : EntityFrameworkCoreRelationalRepository<PointEntity>, IPointRepository
    {
        public PointRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<PointEntity>> GetPointsInRadius(Coordinate center, double radius)
        {
            return await ListWhereIncludeAsync(point
                => (Math.Pow(point.Coordinate.Latitude - center.Latitude, 2) + Math.Pow(point.Coordinate.Longitude - center.Longitude, 2)) < (radius * radius),
                p => p.Posts,
                m => m.User);
        }
    }
}
