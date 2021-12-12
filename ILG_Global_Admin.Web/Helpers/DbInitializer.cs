using ILG_Global_Admin.BussinessLogic.Models;
using ILG_Global_Admin.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_Global_Admin.Web.Helpers
{

    public static class DbInitializer
    {
        public static async Task Ensure(ILG_GlobalContext context, UserManager<ApplicationUser> userman, RoleManager<IdentityRole> roles)
        {
            //context.Database.Migrate();
            if (!roles.Roles.Any())
            {
                IdentityRole adminrole = new IdentityRole
                {
                    Name = "adminstrator",
                    NormalizedName = "adminstrator"
                };


                await roles.CreateAsync(adminrole);




            }

            if (!userman.Users.Any())
            {
                ApplicationUser user = new ApplicationUser
                {
                    Email = "admin@ilgglobal.com",
                    UserName = "admin@ilgglobal.com",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890",
                };

                await userman.CreateAsync(user, "Test@123");
                await userman.AddToRoleAsync(user, "adminstrator");

            }

        }
    }
}