using DotNetCoreArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User
{
    public class UserContactEntity
    {
        public ContactTypeEntity ContactType { get; set; }
        public long ContactTypeId { get; set; }
        public UserEntity User { get; set; }
        public long UserId { get; set; }
        public string Contact { get; set; }
    }
}
