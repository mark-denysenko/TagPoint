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
                    CountryId = 232
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
                    CountryId = 232
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
                    CountryId = 232
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
                    CountryId = 232
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
                    Username = "Шатровський Андрій",
                    PhoneNumber = "0501231231",
                    Roles = Roles.User,
                    Gender = Gender.Male,
                    Status = Status.Active,
                    CountryId = 232
                });
                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 6L,
                    Address = "anedertaker@ua.com"
                });
                x.OwnsOne(y => y.SignIn).HasData(new
                {
                    UserEntityId = 6L,
                    Login = "anedertaker",
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
                    CountryId = 232
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
                    CountryId = 232
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
                    CountryId = 232
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
            });
        }
    }
}
