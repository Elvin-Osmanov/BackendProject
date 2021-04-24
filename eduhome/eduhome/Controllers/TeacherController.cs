using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eduhome.Areas.Manage.ViewModels;
using eduhome.Data;
using eduhome.Data.Entities;
using eduhome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eduhome.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;

        public TeacherController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            double totalCount = _context.Teachers.Count();
            int pageCount = (int)Math.Ceiling(totalCount / 12);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            return View();
        }
        public async Task<IActionResult> Detail(int id)
        {
            Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);

            if (teacher == null)
                return NotFound();

            TeacherDetailViewModel teacherVM = new TeacherDetailViewModel
            {
                Teacher = teacher
            };

            return View(teacherVM);
        }

        public IActionResult Search(string search)
        {
            var model = _context.Teachers.Where(t => t.FullName.Contains(search)).OrderByDescending(t => t.Id).Take(5).ToList();
            return PartialView("_SearchPartial", model);
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
