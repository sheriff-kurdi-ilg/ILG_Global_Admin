using ILG_Global_Admin.BussinessLogic.Models;
using ILG_Global_Admin.BussinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using ILG_Global_Admin.BussinessLogic.Abstraction.Services;

namespace ILG_Global_Admin.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApplicationUserService applicationUserService;

        public AccountController(IApplicationUserService applicationUserService)
        {
            this.applicationUserService = applicationUserService;
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

  
        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Login(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.ReturnUrl = returnUrl;

            return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {
            loginViewModel.ReturnUrl = loginViewModel.ReturnUrl ?? Url.Content("~/");


            var result =  await applicationUserService.Login(loginViewModel);
            if (result!=null)
            {
                return LocalRedirect(loginViewModel.ReturnUrl);
                //return RedirectToAction("Index","Home");

            }
            else
            {
                return View("ended with error");
            }

        }


        public async Task<IActionResult> Logout()
        {
            await applicationUserService.Logout();

            return RedirectToAction("Login");
        }


    }
}
