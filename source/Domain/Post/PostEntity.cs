using Domain.Point;
using DotNetCoreArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Post
{
    public class PostEntity
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public DateTime PostDate { get; set; }
        public UserEntity User { get; set; }
        public PointEntity Point { get; set; }
    }
}
