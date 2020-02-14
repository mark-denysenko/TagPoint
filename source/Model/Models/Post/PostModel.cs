using DotNetCoreArchitecture.Model;
using Model.Models.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.Post
{
    public class PostModel
    {
        public long Id { get; set; }

        public string Message { get; set; }

        public MarkerModel Marker { get; set; }

        public long UserId { get; set; }
    }
}
