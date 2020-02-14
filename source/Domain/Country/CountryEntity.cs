using DotNetCoreArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Country
{
    public class CountryEntity
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }

        public ICollection<UserEntity> Users { get; private set; }

        public void AddUser(UserEntity newUser)
        {
            Users.Add(newUser);
        }
    }
}
