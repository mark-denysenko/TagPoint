using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Post
{
    public class PostTagEntity
    {
        public PostEntity Post { get; set; }
        public long PostId { get; set; }

        public TagEntity Tag { get; set; }
        public long TagId { get; set; }
    }
}
