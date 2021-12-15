using ILG_Global.BussinessLogic.Abstraction.Services;
using ILG_Global.BussinessLogic.ViewModels;
using ILG_Global_Admin.BussinessLogic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_Global_Admin.Web.Controllers
{
    [Authorize]
    public class HtmlContentController : Controller
    {
        private readonly IHtmlContentService htmlContentService;
        private readonly IHostEnvironment hostEnvironment;

        public HtmlContentController(IHtmlContentService htmlContentService, IHostEnvironment hostEnvironment)
        {
            this.htmlContentService = htmlContentService;
            this.hostEnvironment = hostEnvironment;
        }
        // GET: OurServicesController
        public async Task<ActionResult> Index()
        {
            
            List<HtmlContentVM> HtmlContentVMs = await htmlContentService.SelectAllAsync("en");
            return View(HtmlContentVMs);
        }

        // GET: OurServicesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HtmlContentVM HtmlContentVM = await htmlContentService.SelectByIdAsync(id);
            return View(HtmlContentVM);
        }

        // GET: OurServicesController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: OurServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HtmlContentVM HtmlContentVM)
        {
            try
            {

                await htmlContentService.Insert(HtmlContentVM);
                TempData["Message"] = "Created!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OurServicesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HtmlContentVM HtmlContentVM = await htmlContentService.SelectByIdAsync(id);
            return View(HtmlContentVM);
        }

        // POST: OurServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(HtmlContentVM HtmlContentVM)
        {
            try
            {

                await htmlContentService.Update(HtmlContentVM);
                TempData["Message"] = "Updated!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OurServicesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HtmlContentVM HtmlContentVM = await htmlContentService.SelectByIdAsync(id);

            return View(HtmlContentVM);
        }

        // POST: OurServicesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(HtmlContentVM HtmlContentVM)
        {
            try
            {
                htmlContentService.Delete(HtmlContentVM);
                TempData["Message"] = "Deleted!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> ActivationToggle(int id)
        {
            await htmlContentService.ToggleSwtich(id);
            return RedirectToAction("Index");
        }
    }
}
