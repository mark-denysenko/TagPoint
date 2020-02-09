using Domain.Point;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Point
{
    public interface IPointRepository : IRelationalRepository<PointEntity>
    {
    }
}
