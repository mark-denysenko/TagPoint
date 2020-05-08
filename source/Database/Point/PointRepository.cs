using Domain.Point;
using Domain.ValueObjects;
using DotNetCoreArchitecture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Point
{
    public class PointRepository : DotNetCore.EntityFrameworkCore.EntityFrameworkCoreRelationalRepository<PointEntity>, IPointRepository
    {
        private Context Context { get; set; }
        public PointRepository(Context context) : base(context)
        {
            Context = context;
        }

        public async Task<IEnumerable<PointEntity>> GetPointsInRadius(Coordinate center, double radius)
        {
            return await Context.Points
                .AsNoTracking()
                .Include(p => p.User)
                .Include(p => p.Posts)
                .Where(point
                => (Math.Pow(point.Coordinate.Latitude - center.Latitude, 2) + Math.Pow(point.Coordinate.Longitude - center.Longitude, 2)) < (radius * radius))
                .ToListAsync();
        }

        public async Task IncrementPointViews(IEnumerable<long> pointIds)
        {
            await Context.Points.AsNoTracking().Where(p => pointIds.Contains(p.Id)).ForEachAsync(p => p.TotalViews++);

        }
    }
}
