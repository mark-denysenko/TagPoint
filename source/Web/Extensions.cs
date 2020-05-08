using Application.Post;
using DotNetCore.AspNetCore;
using DotNetCore.IoC;
using DotNetCoreArchitecture.Application;
using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.OpenApi.Models;
using System;

namespace DotNetCoreArchitecture.Web
{
    public static class Extensions
    {
        public static void AddClassesMatchingInterfaces(this IServiceCollection services)
        {
            services.AddClassesMatchingInterfaces(typeof(IUserApplicationService).Assembly);
            services.AddClassesMatchingInterfaces(typeof(IPostApplicationService).Assembly);
            services.AddClassesMatchingInterfaces(typeof(IUnitOfWork).Assembly);
            services.AddClassesMatchingInterfaces(typeof(ISignInService).Assembly);
        }

        public static void AddContext(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            var connectionString = configuration.GetConnectionString(nameof(Context));

            services.AddDbContextMigrate<Context>(options => options.UseSqlServer(connectionString));
        }

        public static void AddSecurity(this IServiceCollection services)
        {
            services.AddHash(10000, 128);
            services.AddJsonWebToken("6bzaw-vTSOZpViwUiKmYG5oLmFcp5l273swV6LNWLlEZSXRDtbf9b7_bDFswKVeS8hE92DdhiZp1KOAhcckk4Rq88_1sKlXedUY06_BngPMnTKWTY3MVmGpn96Lxqu2mlE6qIzSu3-LG9v1yJKct0loTHspDCTd0xx2Aw85xEL0", TimeSpan.FromHours(12));
            services.AddAuthenticationJwtBearer();
        }

        public static void AddSpa(this IServiceCollection services)
        {
            services.AddSpaStaticFiles("Frontend/dist");
        }

        public static void UseSpa(this IApplicationBuilder application)
        {
            application.UseSpaAngularServer("Frontend", "start");
        }
    }
}
