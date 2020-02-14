using Domain.Point;
using DotNetCore.EntityFrameworkCore;
using DotNetCoreArchitecture.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Point
{
    public class PointRepository : EntityFrameworkCoreRelationalRepository<PointEntity>, IPointRepository
    {
        public PointRepository(Context context) : base(context)
        {
        }
    }
}
