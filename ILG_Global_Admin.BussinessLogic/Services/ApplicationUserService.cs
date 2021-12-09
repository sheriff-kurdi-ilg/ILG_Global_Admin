using ILG_Global_Admin.BussinessLogic.Abstraction.Services;
using ILG_Global_Admin.BussinessLogic.Models;
using ILG_Global_Admin.BussinessLogic.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<LoginViewModel> Login(LoginViewModel user)
        {
            var User = await userManager.FindByEmailAsync(user.Email);
            SignInResult result;
            if (User != null)
            {
                result = await signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, true);
                if (result.Succeeded)
                {
                    return user;
                }

                throw new Exception("Not Allowed");
            }
            else
            {
                throw new Exception("No Such User");
            }
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
