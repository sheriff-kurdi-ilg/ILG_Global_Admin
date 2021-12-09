using ILG_Global_Admin.BussinessLogic.Models;
using ILG_Global_Admin.DataAccess;
using ILG_Global_Admin.Web.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace ILG_Global_Admin.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var build = CreateHostBuilder(args).Build();
            CreateDb(build).Wait();
            build.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });



        private static async Task CreateDb(IHost host)
        {
            var scope = host.Services.CreateScope();
            var userman = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var context = scope.ServiceProvider.GetRequiredService<ILG_GlobalContext>();
            var roles = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await DbInitializer.Ensure(context, userman, roles);
        }
    }
}
