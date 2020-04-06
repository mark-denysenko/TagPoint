using Database.Contact;
using Database.Country;
using Database.Point;
using Database.Post;
using Database.User;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DotNetCoreArchitecture.Database
{
    internal static class ContextSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.SeedCountries();
            builder.SeedUsers();
            builder.SeedContactTypes();
            builder.SeedPoints();
            builder.SeedPosts();
        }
    }
}
