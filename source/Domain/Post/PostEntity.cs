using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Post
{
    public class PostEntity
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Message { get; set; }
        public DateTime PostDate { get; set; }
    }
}
