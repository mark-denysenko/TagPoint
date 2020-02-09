using Database.Country;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreArchitecture.Database
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.SeedUsers();
            builder.SeedCountries();
        }

        private static void SeedUsers(this ModelBuilder builder)
        {
            builder.Entity<UserEntity>(x =>
            {
                x.HasData(new
                {
                    Id = 1L,
                    Username = "Administrator",
                    Roles = Roles.User | Roles.Admin,
                    Status = Status.Active
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
            });
        }
    }
}
