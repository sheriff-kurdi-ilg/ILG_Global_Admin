using ILG_Global.BussinessLogic.Abstraction.Services;
using ILG_Global.BussinessLogic.ViewModels;
using ILG_Global_Admin.BussinessLogic.Abstraction.Repositories;
using ILG_Global_Admin.BussinessLogic.Models;
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
    public class SuccessStoryController : Controller
    {
        private readonly ISuccessStoryService successStoryService;
        private readonly ISucessStoryMasterRepository sucessStoryMasterRepository;
        private readonly IHostEnvironment hostEnvironment;

        public SuccessStoryController(ISuccessStoryService successStoryService, ISucessStoryMasterRepository sucessStoryMasterRepository, IHostEnvironment hostEnvironment)
        {
            this.successStoryService = successStoryService;
            this.sucessStoryMasterRepository = sucessStoryMasterRepository;
            this.hostEnvironment = hostEnvironment;
        }

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

                string uploadsFolder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/Uploads");
                string uniqFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(successStoriesVM.Image.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqFileName);
                successStoriesVM.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                successStoriesVM.ImageURL = uniqFileName;


                await successStoryService.Insert(successStoriesVM);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuccessStoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
             SuccessStoriesVM lSuccessStoriesVMs = await successStoryService.SelectByIdAsync(id);

            return View(lSuccessStoriesVMs);
        }


        // POST SuccessStoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SuccessStoriesVM successStoriesVM)
        {
            

            try
            {

                if (successStoriesVM.Image != null)
                {
                    string uploadsFolder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/Uploads");
                    string uniqFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(successStoriesVM.Image.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqFileName);
                    successStoriesVM.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    successStoriesVM.ImageURL = uniqFileName;

                }


                await successStoryService.Update(successStoriesVM);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(successStoriesVM);
            }
        }

        // GET: SuccessStoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            SuccessStoriesVM lSuccessStoriesVMs = await successStoryService.SelectByIdAsync(id);

            return View(lSuccessStoriesVMs);
        }

        // POST: SuccessStoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SuccessStoriesVM successStoriesVM)
        {
            try
            {
                successStoryService.Delete(successStoriesVM);
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
