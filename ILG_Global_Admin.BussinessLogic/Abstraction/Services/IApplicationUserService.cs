using ILG_Global_Admin.BussinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Abstraction.Services
{
    public interface IApplicationUserService
    {
        public Task<LoginViewModel> Login(LoginViewModel user);
        public Task Logout();
    }
}
