using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eduhome.ViewModels;
using eduhome.Data;
using Microsoft.AspNetCore.Mvc;
using eduhome.Data.Entities;

namespace eduhome.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            AboutViewModel aboutVM = new AboutViewModel
            {
                Testimonials = _context.Testimonials.OrderBy(x => x.CreatedAt).ToList(),
                Teachers = _context.Teachers.OrderByDescending(x => x.CreatedAt).Take(4).ToList(),
                Notices = _context.Notices.OrderByDescending(x => x.CreatedAt).ToList(),


            };
            return View(aboutVM);
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
