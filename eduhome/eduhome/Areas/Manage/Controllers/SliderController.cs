using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eduhome.Areas.Manage.ViewModels;
using eduhome.Data;
using eduhome.Data.Entities;
using eduhome.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eduhome.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            double totalCount = await _context.Sliders.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 4);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            SliderViewModel sliderVm = new SliderViewModel
            {
                Sliders = _context.Sliders.Skip((page - 1) * 4).Take(4).ToList()
            };

            return View(sliderVm);
        }

        public async Task<IActionResult> Create()
        {

            Slider lastSlider = _context.Sliders.OrderByDescending(s => s.Order).FirstOrDefault();
            if (lastSlider != null)
            {
                ViewBag.BiggestOrder = lastSlider.Order;
            }
            else
            {
                ViewBag.BiggestOrder = 1;
            }

            return View();
        }
    

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Slider slider)
    {


        #region ModelStateCheck
        if (ModelState.IsValid)
        {
            return View(slider);
        }
        #endregion

        if (slider.File != null)
        {
            #region CheckPhotoLength
            if (slider.File.Length > 3 * (1024 * 1024))
            {
                ModelState.AddModelError("File", "Cannot be more than 3MB");
                return View();

            }
            #endregion
            #region CheckPhotoContentType
            if (slider.File.ContentType != "image/png" && slider.File.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("File", "Only jpeg and png files accepted");
                return View();
            }
            #endregion

            string filename = FileManagerHelper.Save(_env.WebRootPath, "uploads/sliders", slider.File);

            slider.Photo = filename;
        }


        await _context.Sliders.AddAsync(slider);
        await _context.SaveChangesAsync();

        return RedirectToAction("index");


    }

    public async Task<IActionResult> Edit(int id)
    {
        Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

        #region CheckSlider

        if (slider == null)
        {
            return NotFound();
        }
        #endregion
        return View(slider);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Slider slider)
    {
        Slider existSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == slider.Id);

        #region CheckSlider

        if (existSlider == null)
        {
            return NotFound();
        }
        #endregion

        existSlider.Title = slider.Title;
        existSlider.Desc = slider.Desc;
        existSlider.RedirectUrl = slider.RedirectUrl;
        existSlider.Order = slider.Order;

        #region ModelStateCheck
        if (ModelState.IsValid)
        {
            return View(slider);
        }
        #endregion

        if (slider.File != null)
        {
            #region CheckPhotoLength
            if (slider.File.Length > 3 * (1024 * 1024))
            {
                ModelState.AddModelError("File", "Cannot be more than 3MB");
                return View();

            }
            #endregion
            #region CheckPhotoContentType
            if (slider.File.ContentType != "image/png" && slider.File.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("File", "Only jpeg and png files accepted");
                return View();
            }
            #endregion

            string filename = FileManagerHelper.Save(_env.WebRootPath, "uploads/sliders", slider.File);

            if (!string.IsNullOrWhiteSpace(existSlider.Photo))
            {
                FileManagerHelper.Delete(_env.WebRootPath, "uploads/sliders", existSlider.Photo);
            }

            existSlider.Photo = filename;
        }


        await _context.SaveChangesAsync();

        return RedirectToAction("index");


    }

    public async Task<IActionResult> Detail(int id)
    {
        Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

        #region CheckSliderNotFound
        if (slider == null)
        {
            return NotFound();
        }
        #endregion

        return View(slider);
    }

    public async Task<IActionResult> Delete(int id)
    {
        Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

        #region CheckSliderNotFound
        if (slider == null)
        {
            return NotFound();
        }
        #endregion

        return View(slider);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Slider sliderModel)
    {
        Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == sliderModel.Id);

        #region CheckSliderNotFound
        if (slider == null)
        {
            return NotFound();
        }
        #endregion


        _context.Sliders.Remove(slider);
        await _context.SaveChangesAsync();

        return RedirectToAction("index");
    }
}
    
}
