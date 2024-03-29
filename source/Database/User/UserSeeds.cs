using Domain.User;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Database.User
{
    internal static class UserSeeds
    {
        public static void SeedUsers(this ModelBuilder builder)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var sysDir = Path.GetDirectoryName(location);
            var dir = new DirectoryInfo(sysDir + "\\Seeds");

            var avatars = new DirectoryInfo(sysDir + "\\Seeds").GetFiles("user*");

            builder.Entity<UserAvatarEntity>(x =>
            {
                foreach (var avatar in avatars)
                {
                    var id = long.Parse(avatar.Name.Replace("user", "").Replace(".jpg", ""));
                    x.HasData(new
                    {
                        Avatar = File.ReadAllBytes(avatar.FullName),
                        Filename = avatar.Name,
                        UserId = id,
                        Id = id
                    });
                }
            });

            builder.Entity<UserEntity>(x =>
            {
                x.HasData(new
                {
                    Id = 1L,
                    Username = "Денисенко Марк",
                    PhoneNumber = "0501231231",
                    Roles = Roles.User | Roles.Admin,
                    Gender = Gender.Male,
                    Status = Status.Active,
                    CountryId = 232
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 1L,
                    Address = "mark@administrator.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 1L,
                    Login = "mark",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });

                x.HasData(new
                {
                    Id = 2L,
                    Username = "Шатровський Андрій",
                    PhoneNumber = "0501231231",
                    Roles = Roles.User,
                    Gender = Gender.Male,
                    Status = Status.Active,
                    CountryId = 1
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 2L,
                    Address = "shatrik@ua.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 2L,
                    Login = "shatrik",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });

                x.HasData(new
                {
                    Id = 3L,
                    Username = "Кушка Михайло",
                    PhoneNumber = "0501231231",
                    Roles = Roles.User,
                    Gender = Gender.Male,
                    Status = Status.Active,
                    CountryId = 151
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 3L,
                    Address = "kushka@ua.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 3L,
                    Login = "kushka",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });

                x.HasData(new
                {
                    Id = 4L,
                    Username = "Недашківський Євген",
                    PhoneNumber = "0501231231",
                    Roles = Roles.User,
                    Gender = Gender.Male,
                    Status = Status.Active,
                    CountryId = 180
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 4L,
                    Address = "yevhen@ua.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 4L,
                    Login = "yevhen",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });

                x.HasData(new
                {
                    Id = 5L,
                    Username = "Шаверський Іван",
                    PhoneNumber = "0501231231",
                    Roles = Roles.User,
                    Gender = Gender.Male,
                    Status = Status.Active,
                    CountryId = 180
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 5L,
                    Address = "ivan@ua.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 5L,
                    Login = "ivan",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });

                x.HasData(new
                {
                    Id = 6L,
                    Username = "Пащевський Руслан",
                    PhoneNumber = "0501231231",
                    Roles = Roles.User,
                    Gender = Gender.Male,
                    Status = Status.Active,
                    CountryId = 215
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 6L,
                    Address = "pavlo@ua.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 6L,
                    Login = "pavlo",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });

                x.HasData(new
                {
                    Id = 7L,
                    Username = "Денисенко Софія",
                    PhoneNumber = "0501231231",
                    Roles = Roles.User,
                    Gender = Gender.Female,
                    Status = Status.Active,
                    CountryId = 1
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 7L,
                    Address = "sofa@ua.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 7L,
                    Login = "sofa",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });

                x.HasData(new
                {
                    Id = 8L,
                    Username = "Денисенко Таня",
                    PhoneNumber = "0501231231",
                    Roles = Roles.User,
                    Gender = Gender.Female,
                    Status = Status.Active,
                    CountryId = 151
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 8L,
                    Address = "tanya@ua.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 8L,
                    Login = "tanya",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });

                x.HasData(new
                {
                    Id = 9L,
                    Username = "Денисенко Олександр",
                    PhoneNumber = "0501231231",
                    Roles = Roles.User,
                    Gender = Gender.Male,
                    Status = Status.Active,
                    CountryId = 180
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 9L,
                    Address = "alex@ua.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 9L,
                    Login = "alex",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });

                x.HasData(new
                {
                    Id = 10L,
                    Username = "Денисенко Віктор",
                    PhoneNumber = "0501231231",
                    Roles = Roles.User,
                    Gender = Gender.Male,
                    Status = Status.Active,
                    CountryId = 232
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 10L,
                    Address = "victor@ua.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 10L,
                    Login = "victor",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });

                x.HasData(new
                {
                    Id = 11L,
                    Username = "Василенко Олександр",
                    PhoneNumber = "0501231231",
                    Roles = Roles.User,
                    Gender = Gender.Male,
                    Status = Status.Active,
                    CountryId = 232
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 11L,
                    Address = "stepan@ua.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 11L,
                    Login = "stepan",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });

                x.HasData(new
                {
                    Id = 12L,
                    Username = "Кришталь Світлана",
                    PhoneNumber = "0501231231",
                    Roles = Roles.User,
                    Gender = Gender.Female,
                    Status = Status.Active,
                    CountryId = 232
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 12L,
                    Address = "svitlana@ua.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 12L,
                    Login = "svitlana",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });
            });
        }
    }
}
