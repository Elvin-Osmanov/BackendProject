using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eduhome.Areas.Manage.ViewModels;
using eduhome.Data;
using eduhome.Data.Entities;
using eduhome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace eduhome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            HomeViewModel homeVM = new HomeViewModel
            {
                Sliders = _context.Sliders.OrderBy(s => s.Order).Take(3).ToList(),

                Notices = _context.Notices.OrderByDescending(s => s.CreatedAt).ToList(),

                Testimonials = _context.Testimonials.ToList(),

                Courses=_context.Courses.Include(c=>c.Category).Take(3).ToList(),

                Events = _context.Events.Include(c => c.Category).Take(4).ToList(),

                Services=_context.Services.Take(3).ToList()

            };
            return View(homeVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Subscribe(Subscriber subscriber)
        {
            

            Subscriber sub = new Subscriber
            {
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                Email = subscriber.Email

            };

            _context.Subscribers.Add(sub);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }

    

} 
