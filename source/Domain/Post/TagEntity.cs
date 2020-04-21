using DotNetCore.Objects;
using DotNetCoreArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Post
{
    public class TagEntity : Entity
    {
        public string Tag { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public UserEntity CreatedBy { get; set; }
        public long CreatedById { get; set; }

        public ICollection<PostTagEntity> Posts { get; set; }
    }
}
