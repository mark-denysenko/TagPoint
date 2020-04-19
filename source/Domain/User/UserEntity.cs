using Domain.Country;
using Domain.Point;
using Domain.Post;
using Domain.User;
using Domain.Vote;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Model;
using Model;
using System;
using System.Collections.Generic;

namespace DotNetCoreArchitecture.Domain
{
    public class UserEntity : Entity
    {
        public UserEntity
        (
            long id,
            string username,
            Email email,
            SignIn signIn,
            Roles roles,
            Status status,
            Gender gender,
            string phoneNumber,
            string about = null
        )
        {
            Id = id;
            Username = username;
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

        public string Username { get; private set; }
        public Gender Gender { get; private set; }
        public Email Email { get; private set; }
        public SignIn SignIn { get; private set; }
        public Roles Roles { get; private set; }
        public Status Status { get; private set; }
        public string About { get; private set; }
        public string PhoneNumber { get; private set; }
        public CountryEntity Country { get; set; }
        public UserAvatarEntity Avatar { get; set; }
        public DateTime RegisterDate { get; set; }

        public ICollection<UserLogEntity> UsersLogs { get; private set; }
        public ICollection<PointEntity> Points { get; private set; }
        public ICollection<PostEntity> Posts { get; private set; }
        public ICollection<LikeEntity> Likes { get; private set; }

        public void Add()
        {
            Roles = Roles.User;
            Status = Status.Active;
        }

        public void ChangeEmail(string address)
        {
            Email = new Email(address);
        }

        public void ChangeUsername(string username)
        {
            Username = username;
        }

        public void ChangePhone(string phone)
        {
            PhoneNumber = phone ?? string.Empty;
        }
        public void ChangeAbout(string about)
        {
            About = about ?? string.Empty;
        }

        public void ChangeGender(Gender gender)
        {
            Gender = gender;
        }
        public void ChangeSignIn(SignIn signIn)
        {
            SignIn = signIn;
        }

        public void Inactivate()
        {
            Status = Status.Inactive;
        }

        public void AddPoint(PointEntity newPoint)
        {
            Points.Add(newPoint);
        }

        public void AddPost(PostEntity newPost)
        {
            Posts.Add(newPost);
        }
    }
}
