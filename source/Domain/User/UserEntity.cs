using DotNetCore.Objects;
using DotNetCoreArchitecture.Model;
using Model;
using System.Collections.Generic;

namespace DotNetCoreArchitecture.Domain
{
    public class UserEntity : Entity
    {
        public UserEntity
        (
            long id,
            FullName fullName,
            Email email,
            SignIn signIn,
            Roles roles,
            Status status,
            Gender gender,
            string about,
            string phoneNumber
        )
        {
            Id = id;
            FullName = fullName;
            Email = email;
            SignIn = signIn;
            Roles = roles;
            Status = status;
            Gender = gender;
            About = about;
            PhoneNumber = phoneNumber;
        }

        public UserEntity(long id)
        {
            Id = id;
        }

        public FullName FullName { get; private set; }
        public Gender? Gender { get; private set; }

        public Email Email { get; private set; }

        public SignIn SignIn { get; private set; }

        public Roles Roles { get; private set; }

        public Status Status { get; private set; }
        public string About { get; private set; }
        public string PhoneNumber { get; private set; }

        public ICollection<UserLogEntity> UsersLogs { get; private set; }

        public void Add()
        {
            Roles = Roles.User;
            Status = Status.Active;
        }

        public void ChangeEmail(string address)
        {
            Email = new Email(address);
        }

        public void ChangeFullName(string name, string surname)
        {
            FullName = new FullName(name, surname);
        }

        public void Inactivate()
        {
            Status = Status.Inactive;
        }
    }
}
