using Database.Point;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Statistic
{
    public class StatisticService : IStatisticService
    {
        private readonly IPointRepository pointRepository;

        public StatisticService(IPointRepository pointRepository)
        {
            this.pointRepository = pointRepository;
        }

        public void IncrementPointViews(IEnumerable<long> pointIds)
        {
            
            throw new NotImplementedException();
        }
    }
}
