using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eduhome.Areas.Manage.ViewModels;
using eduhome.Data;
using eduhome.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eduhome.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
    [Area("Manage")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            double totalCount = await _context.Categories.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 4);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            CategoryViewModel categoryVM = new CategoryViewModel
            {
                Categories = await _context.Categories.Skip((page - 1) * 4).Take(4).ToListAsync()
            };
            return View(categoryVM);
        }

        public async Task<IActionResult> Create()
        {
            Category category = await _context.Categories.FirstOrDefaultAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateViewModel categoryVM)
        {
            if (!ModelState.IsValid)
                return View();

            if (await _context.Categories.AnyAsync(x => x.Name.ToLower() == categoryVM.Name.Trim().ToLower()))
            {
                ModelState.AddModelError("Name", "Category already exist!");
                return View();
            }

            Category category = new Category
            {
               
                Name = categoryVM.Name.Trim(),
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };
            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            CategoryCreateViewModel categoryVM = new CategoryCreateViewModel
            {
                Name = category.Name,
               
            };

            ViewBag.Id = id;

            return View(categoryVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryCreateViewModel categoryVM)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return View();

            if (await _context.Categories.AnyAsync(x => x.Id != id && x.Name.ToLower() == categoryVM.Name.Trim().ToLower()))
            {
                ModelState.AddModelError("Name", "Category already exists!");
                return View();
            }

           
            category.Name = categoryVM.Name;
            category.ModifiedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(x =>  x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Category categoryModel)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryModel.Id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
