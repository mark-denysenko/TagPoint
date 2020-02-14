using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DotNetCoreArchitecture.Database
{
    public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Context>();

            builder.UseSqlServer(@"Server=DESKTOP-LANBNAJ\SQLEXPRESS;Database=TagPoint;Integrated Security=False;Persist Security Info=True;Trusted_Connection=True;MultipleActiveResultSets=True;",
                x => x.UseNetTopologySuite());

            return new Context(builder.Options);
        }
    }
}
