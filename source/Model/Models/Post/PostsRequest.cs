using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.Post
{
    public class PostsRequest
    {
        public bool? OrderByDateAsc { get; set; }
        public bool? OrderByLikesAsc { get; set; }
        public string Keyword { get; set; }
    }
}
