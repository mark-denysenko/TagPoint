using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.Post
{
    public class TagModel
    {
        public long Id { get; set; }
        public string Tag { get; set; }
        public DateTime Created { get; set; }
        public long CreatedById { get; set; }
    }
}
