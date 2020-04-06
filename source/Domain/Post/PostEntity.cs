using Domain.Point;
using Domain.Vote;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Post
{
    public class PostEntity : Entity
    {
        public string Message { get; set; }
        public DateTime PostDate { get; set; }
        public UserEntity User { get; set; }
        public PointEntity Point { get; set; }
        public ICollection<LikeEntity> Likes { get; set; }
    }
}
