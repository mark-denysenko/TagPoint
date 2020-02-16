using Domain.Point;
using Domain.ValueObjects;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Point
{
    public interface IPointRepository : IRelationalRepository<PointEntity>
    {
        Task<IEnumerable<PointEntity>> GetPointsInRadius(Coordinate center, double radius);
    }
}
