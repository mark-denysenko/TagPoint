using Domain.Post;
using DotNetCoreArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Vote
{
    public class BaseVote
    {
        public long UserId { get; set; }
        public long PostId { get; set; }
        public UserEntity User { get; set; }
        public PostEntity Post { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
