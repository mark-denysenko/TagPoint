using DotNetCoreArchitecture.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.User
{
    public class ProfileModel : UserModel
    {
        public int PostsNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public byte[] Avatar { get; set; }
        public string Country { get; set; }
    }
}
