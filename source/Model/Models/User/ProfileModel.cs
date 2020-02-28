using DotNetCoreArchitecture.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.User
{
    public class ProfileModel : UserModel
    {
        public byte[] Avatar { get; set; }
        public string Country { get; set; }
    }
}
