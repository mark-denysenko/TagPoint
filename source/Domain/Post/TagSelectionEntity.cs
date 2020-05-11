using DotNetCore.Objects;
using DotNetCoreArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Post
{
    public class TagSelectionEntity : Entity
    {
        public TagEntity Tag { get; set; }
        public long TagId { get; set; }
        public DateTime Created { get; set; }
        public UserEntity User { get; set; }
        public long UserId { get; set; }
    }
}
