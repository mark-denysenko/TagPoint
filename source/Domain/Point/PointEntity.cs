using Domain.Post;
using Domain.ValueObjects;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Point
{
    public class PointEntity : Entity
    {
        public Coordinate Coordinate { get; set; }

        public UserEntity User { get; set; }
        public long UserId { get; set; }
        public DateTime Created { get; set; }

        public ICollection<PostEntity> Posts { get; private set; }

        public void AddPost(PostEntity newPost)
        {
            Posts.Add(newPost);
        }
    }
}
