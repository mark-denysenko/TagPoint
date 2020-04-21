using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Statistic
{
    public interface IStatisticService
    {
        void IncrementPointViews(IEnumerable<long> pointIds);
    }
}
