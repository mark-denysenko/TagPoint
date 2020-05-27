using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Statistic
{
    public interface IStatisticService
    {
        Task IncrementPointViews(IEnumerable<long> pointIds);
        Task IncrementPostViews(long postId);
    }
}
