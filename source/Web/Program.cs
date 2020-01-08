using DotNetCore.AspNetCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DotNetCoreArchitecture.Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder().Run<Startup>();
            //WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
            //CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
