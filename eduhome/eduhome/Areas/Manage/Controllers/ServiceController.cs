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
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            double totalCount = await _context.Tags.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 4);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            ServiceViewModel serviceVM = new ServiceViewModel
            {
                Services = await _context.Services.Skip((page - 1) * 4).Take(4).ToListAsync()
            };
            return View(serviceVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (await _context.Services.AnyAsync(x => x.Name.ToLower() == service.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Service already exists!");
                return View();
            }

            service.Name = service.Name.Trim();
            service.CreatedAt = DateTime.UtcNow;
            service.ModifiedAt = DateTime.UtcNow;

            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Service service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);

            if (service == null)
                return NotFound();

            return View(service);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Service service)
        {
            Service existService = await _context.Services.FirstOrDefaultAsync(x => x.Id == service.Id);

            if (existService == null)
                return NotFound();

            existService.Name = service.Name;
            existService.Desc = service.Desc;
            existService.ModifiedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Service service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);


            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Service service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);

            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Service service)
        {
            Service existService = await _context.Services.FirstOrDefaultAsync(x => x.Id == service.Id);

            if (existService == null)
            {
                return NotFound();
            }

            _context.Services.Remove(existService);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
