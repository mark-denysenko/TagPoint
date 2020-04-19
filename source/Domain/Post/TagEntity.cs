using DotNetCore.Objects;
using DotNetCoreArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Post
{
    public class TagEntity : Entity
    {
        public string Tag { get; private set; }
        public DateTime Created { get; private set; }
        public UserEntity CreatedBy { get; private set; }

    }
}
