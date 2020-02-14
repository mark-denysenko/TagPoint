using Model;
using Model.Models;

namespace DotNetCoreArchitecture.Model
{
    public class UserModel
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string About { get; set; }

        public Gender Gender { get; set; }

        public Roles Roles { get; set; }

        public int CountryId { get; set; }
    }
}
