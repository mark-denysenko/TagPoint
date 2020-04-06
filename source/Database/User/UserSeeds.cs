using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.User
{
    internal static class UserSeeds
    {
        public static void SeedUsers(this ModelBuilder builder)
        {
            builder.Entity<UserEntity>(x =>
            {
                x.HasData(new
                {
                    Id = 1L,
                    Username = "Administrator",
                    Roles = Roles.User | Roles.Admin,
                    Gender = Gender.Male,
                    Status = Status.Active,
                    CountryId = 232
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 1L,
                    Address = "administrator@administrator.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 1L,
                    Login = "admin",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });

                x.HasData(new
                {
                    Id = 2L,
                    Username = "Олена",
                    Roles = Roles.User | Roles.Admin,
                    Gender = Gender.Male,
                    Status = Status.Active,
                    CountryId = 232
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 2L,
                    Address = "olena@olena.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 2L,
                    Login = "olena",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });

                x.HasData(new
                {
                    Id = 3L,
                    Username = "Василь",
                    Roles = Roles.User | Roles.Admin,
                    Gender = Gender.Male,
                    Status = Status.Active,
                    CountryId = 232
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 3L,
                    Address = "vasyl@vasyl.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 3L,
                    Login = "vasyl",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });

                x.HasData(new
                {
                    Id = 4L,
                    Username = "Петро",
                    Roles = Roles.User | Roles.Admin,
                    Gender = Gender.Male,
                    Status = Status.Active,
                    CountryId = 232
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 4L,
                    Address = "petro@petro.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 4L,
                    Login = "petro",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                });
            });
        }
    }
}
