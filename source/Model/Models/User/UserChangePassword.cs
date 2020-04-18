using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.User
{
    public class UserChangePassword
    {
        public long UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
