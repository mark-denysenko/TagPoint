using Database.Point;
using Database.Post;
using DotNetCoreArchitecture.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Statistic
{
    public class StatisticService : IStatisticService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPointRepository pointRepository;
        private readonly IPostRepository postRepository;

        public StatisticService(IUnitOfWork unitOfWork, IPointRepository pointRepository, IPostRepository postRepository)
        {
            this.unitOfWork = unitOfWork;
            this.pointRepository = pointRepository;
            this.postRepository = postRepository;
        }

        public async Task IncrementPointViews(IEnumerable<long> pointIds)
        {
            await unitOfWork.SaveChangesAsync();
        }

        public async Task IncrementPostViews(long postId)
        {
            await unitOfWork.SaveChangesAsync();
        }
    }
}
