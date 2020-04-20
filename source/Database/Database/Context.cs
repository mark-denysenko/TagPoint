using Domain.Post;
using Domain.Country;
using Domain.Point;
using Domain.User;
using Domain.Vote;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DotNetCoreArchitecture.Domain;

namespace DotNetCoreArchitecture.Database
{
    public sealed class Context : DbContext
    {
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<LikeEntity> Likes { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<PointEntity> Points { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly();
            builder.Seed();
        }
    }
}
