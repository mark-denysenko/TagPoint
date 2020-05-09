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
        public bool Recommended { get; set; }
        public string Location { get; set; }
        public DateTime CreationDate { get; set; }
        public MarkerModel Marker { get; set; }
        public bool Liked { get; set; }
        public long Views { get; set; }
        public int TimesLiked { get; set; }
        public bool Editable { get; set; }
        public long UserId { get; set; }
        public string Username { get; set; }
        public byte[] UserAvatar { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
