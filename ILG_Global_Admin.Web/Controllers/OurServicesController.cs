using ILG_Global.BussinessLogic.Abstraction.Services;
using ILG_Global.BussinessLogic.ViewModels;
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
    public class OurServicesController : Controller
    {
        private readonly IOurServicesService ourServicesService;
        private readonly IHostEnvironment hostEnvironment;

        public OurServicesController(IOurServicesService ourServicesService, IHostEnvironment hostEnvironment)
        {
            this.ourServicesService = ourServicesService;
            this.hostEnvironment = hostEnvironment;
        }
        // GET: OurServicesController
        public async Task<ActionResult> Index()
        {
            List<OurServiceVM> ourServiceVMs = await ourServicesService.SelectAllAsync("en");
            return View(ourServiceVMs);
        }

        // GET: OurServicesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            OurServiceVM ourServiceVM = await ourServicesService.SelectByIdAsync(id);
            return View(ourServiceVM);
        }

        // GET: OurServicesController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: OurServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OurServiceVM ourServiceVM)
        {
            try
            {

                string uploadsFolder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/Uploads");
                string uniqFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(ourServiceVM.Image.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqFileName);
                ourServiceVM.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                ourServiceVM.ImageURL = uniqFileName;


                await ourServicesService.Insert(ourServiceVM);

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
            OurServiceVM ourServiceVM = await ourServicesService.SelectByIdAsync(id);
            return View(ourServiceVM);
        }

        // POST: OurServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OurServiceVM ourServiceVM)
        {
            try
            {
                await ourServicesService.Update(ourServiceVM);
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
            OurServiceVM ourServiceVM = await ourServicesService.SelectByIdAsync(id);

            return View(ourServiceVM);
        }

        // POST: OurServicesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(OurServiceVM ourServiceVM)
        {
            try
            {
                ourServicesService.Delete(ourServiceVM);
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
            await ourServicesService.ToggleSwtich(id);
            return RedirectToAction("Index");
        }
    }
}
