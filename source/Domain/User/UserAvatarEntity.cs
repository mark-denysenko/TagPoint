using DotNetCore.Objects;
using DotNetCoreArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User
{
    public class UserAvatarEntity : Entity
    {
        public string Filename { get; set; }
        public byte[] Avatar { get; set; }
        public UserEntity User { get; set; }
        public long UserId { get; set; }
        public DateTime UploadedTime { get; set; }
    }
}
