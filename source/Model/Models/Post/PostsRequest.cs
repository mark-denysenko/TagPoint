using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.Post
{
    public class PostsRequest
    {
        public bool? OrderByDateDesc { get; set; }
        public bool? OrderByLikesDesc { get; set; }
        public string Keyword { get; set; }
    }
}
