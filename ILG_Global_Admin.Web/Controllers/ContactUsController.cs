using ILG_Global.BussinessLogic.Abstraction.Services;
using ILG_Global.BussinessLogic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_Global_Admin.Web.Controllers
{
    [Authorize]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            this.contactUsService = contactUsService;
        }

        // GET: OurServicesController
        public async Task<ActionResult> Index()
        {
            List<ContactUsSectionVM> ContactUsSectionVMs = await contactUsService.SelectAllAsync("en");
            return View(ContactUsSectionVMs);
        }

        // GET: OurServicesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ContactUsSectionVM ContactUsSectionVM = await contactUsService.SelectByIdAsync(id);
            return View(ContactUsSectionVM);
        }

        // GET: OurServicesController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: OurServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContactUsSectionVM ContactUsSectionVM)
        {
            try
            {
                await contactUsService.Insert(ContactUsSectionVM);
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
            ContactUsSectionVM ContactUsSectionVM = await contactUsService.SelectByIdAsync(id);
            return View(ContactUsSectionVM);
        }

        // POST: OurServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ContactUsSectionVM ContactUsSectionVM)
        {
            try
            {
                await contactUsService.Update(ContactUsSectionVM);
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
            ContactUsSectionVM ContactUsSectionVM = await contactUsService.SelectByIdAsync(id);

            return View(ContactUsSectionVM);
        }

        // POST: OurServicesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ContactUsSectionVM ContactUsSectionVM)
        {
            try
            {
                contactUsService.Delete(ContactUsSectionVM);
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
            await contactUsService.ToggleSwtich(id);
            return RedirectToAction("Index");
        }
    }
}
