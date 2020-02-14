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
            var point = new PointEntity
            {
                Coordinate = new Domain.ValueObjects.Coordinate
                {
                    Latitude = post.Marker.Latitude,
                    Longitude = post.Marker.Longitude
                }
            };

            if (post.Marker.Id == default)
            {
                await _pointRepository.AddAsync(point);
            }

            var user = _userRepository.FirstOrDefault(u => u.Id == post.UserId);

            var newPost = new PostEntity
            {
                Message = post.Message,
                Point = point,
                //User = user
            };

            await _postRepository.AddAsync(newPost);
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
