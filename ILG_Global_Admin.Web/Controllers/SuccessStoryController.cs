using ILG_Global.BussinessLogic.Abstraction.Services;
using ILG_Global.BussinessLogic.ViewModels;
using ILG_Global_Admin.BussinessLogic.Abstraction.Repositories;
using ILG_Global_Admin.BussinessLogic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_Global_Admin.Web.Controllers
{

    [Authorize]
    public class SuccessStoryController : Controller
    {
        #region DI
        private readonly ISuccessStoryService successStoryService;
        private readonly ISucessStoryMasterRepository sucessStoryMasterRepository;
        private readonly IHostEnvironment hostEnvironment;

        public SuccessStoryController(
            ISuccessStoryService successStoryService,
            ISucessStoryMasterRepository sucessStoryMasterRepository,
            IHostEnvironment hostEnvironment)
        {
            this.successStoryService = successStoryService;
            this.sucessStoryMasterRepository = sucessStoryMasterRepository;
            this.hostEnvironment = hostEnvironment;
        }
        #endregion

        // GET: SuccessStoryController
        public async Task<ActionResult> Index()
        {
            List<SuccessStoriesVM> successStories = await successStoryService.SelectAllAsync("en");
            return View(successStories);
        }

        // GET: SuccessStoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            SuccessStoriesVM lSuccessStoriesVMs = await successStoryService.SelectByIdAsync(id);

            return View(lSuccessStoriesVMs);
        }

        // GET: SuccessStoryController/Create
        public async Task<ActionResult> Create()
        {

            return View();
        }

        // POST: SuccessStoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SuccessStoriesVM successStoriesVM)
        {
            try
            {
                string uploadsImagesFolder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/Uploads/SuccessStories");
                string uploadsPdfFolder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/Uploads/SuccessStories/pdf");


                string uniqImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(successStoriesVM.Image.FileName);
                string ImagePath = Path.Combine(uploadsImagesFolder, uniqImageName);
                successStoriesVM.Image.CopyTo(new FileStream(ImagePath, FileMode.Create));
                successStoriesVM.ImageURL = uniqImageName;

                string uniqpdfName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(successStoriesVM.Pdf.FileName);
                string pdfPath = Path.Combine(uploadsPdfFolder, uniqpdfName);
                successStoriesVM.Pdf.CopyTo(new FileStream(pdfPath, FileMode.Create));
                successStoriesVM.PdfURL = uniqpdfName;

                await successStoryService.Insert(successStoriesVM);
                TempData["Message"] = "Created!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<ActionResult> Edit(int id)
        {
             SuccessStoriesVM lSuccessStoriesVMs = await successStoryService.SelectByIdAsync(id);

            return View(lSuccessStoriesVMs);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SuccessStoriesVM successStoriesVM)
        {
            try
            {
                string uploadsImagesFolder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/Uploads/SuccessStories");
                string uploadsPdfFolder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/Uploads/SuccessStories/pdf");
                if (successStoriesVM.Image != null)
                {
                    string uniqFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(successStoriesVM.Image.FileName);
                    string filePath = Path.Combine(uploadsImagesFolder, uniqFileName);
                    successStoriesVM.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    successStoriesVM.ImageURL = uniqFileName;
                }

                if (successStoriesVM.Pdf != null)
                {
                    string uniqpdfName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(successStoriesVM.Pdf.FileName);
                    string pdfPath = Path.Combine(uploadsPdfFolder, uniqpdfName);
                    successStoriesVM.Pdf.CopyTo(new FileStream(pdfPath, FileMode.Create));
                    successStoriesVM.PdfURL = uniqpdfName;
                }

                await successStoryService.Update(successStoriesVM);
                TempData["Message"] = "Updated!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(successStoriesVM);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            SuccessStoriesVM lSuccessStoriesVMs = await successStoryService.SelectByIdAsync(id);

            return View(lSuccessStoriesVMs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SuccessStoriesVM successStoriesVM)
        {
            try
            {
                successStoryService.Delete(successStoriesVM);
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
            await successStoryService.ToggleSwtich(id);
            return RedirectToAction("Index");
        }
    }
}
