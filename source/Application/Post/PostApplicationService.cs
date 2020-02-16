using Database.Point;
using Database.Post;
using Domain.Point;
using Domain.Post;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Domain;
using Model.Models.Post;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Post
{
    public class PostApplicationService : IPostApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _postRepository;
        private readonly IPointRepository _pointRepository;
        private readonly IUserRepository _userRepository;

        public PostApplicationService(
            IUnitOfWork unitOfWork,
            IPostRepository postRepository,
            IPointRepository pointRepository,
            IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _postRepository = postRepository;
            _pointRepository = pointRepository;
            _userRepository = userRepository;
        }

        public async Task<IDataResult<long>> CreatePostAsync(PostModel post)
        {
            var user = _userRepository.FirstOrDefault(u => u.Id == post.UserId);

            PointEntity point = await _pointRepository.FirstOrDefaultAsync(p => p.Id == post.Marker.Id);
            if (point is null)
            {
                point = new PointEntity
                {
                    Coordinate = new Domain.ValueObjects.Coordinate
                    {
                        Latitude = post.Marker.Latitude,
                        Longitude = post.Marker.Longitude
                    }
                };
                await _pointRepository.AddAsync(point);
                point.User = user;
            }

            var newPost = new PostEntity
            {
                Message = post.Message,
                Point = point
            };

            await _postRepository.AddAsync(newPost);
            newPost.User = user;

            await _unitOfWork.SaveChangesAsync();

            return DataResult<long>.Success(newPost.Id);
        }

        public Task<IResult> DeletePostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<PostModel>> GetPostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> GetPostsNearAsync()
        {
            throw new NotImplementedException();
        }
    }
}
