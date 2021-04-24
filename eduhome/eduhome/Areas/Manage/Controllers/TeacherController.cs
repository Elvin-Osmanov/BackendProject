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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public TeacherController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            double totalCount = await _context.Teachers.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 5);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            TeacherViewModel teacherViewModel = new TeacherViewModel
            {
                Teachers = _context.Teachers.Skip((page - 1) * 5).Take(5).ToList()
            };

            return View(teacherViewModel);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher teacher)
        {


            #region ModelStateCheck
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }
            #endregion

            if (teacher.File != null)
            {
                #region PhotoLengthChecking
                if (teacher.File.Length > 3 * (1024 * 1024))
                {
                    ModelState.AddModelError("File", "Cannot be more than 3MB");
                    return View();

                }
                #endregion
                #region PhotoContentTypeChecking
                if (teacher.File.ContentType != "image/png" && teacher.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Only jpeg and png files accepted");
                    return View();
                }
                #endregion

                string filename = FileManagerHelper.Save(_env.WebRootPath, "uploads/teachers", teacher.File);

                teacher.Photo = filename;
            }
            teacher.CreatedAt = DateTime.UtcNow;
            teacher.ModifiedAt = DateTime.UtcNow;


            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");


        }

        public async Task<IActionResult> Edit(int id)
        {
            Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(s => s.Id == id);

            #region CheckSlider

            if (teacher == null)
            {
                return NotFound();
            }
            #endregion
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            Teacher existTeacher = await _context.Teachers.FirstOrDefaultAsync(s => s.Id == teacher.Id);

            #region CheckSlider

            if (existTeacher == null)
            {
                return NotFound();
            }
            #endregion

            existTeacher.FullName = teacher.FullName;
            existTeacher.Desc = teacher.Desc;
            existTeacher.Degree = teacher.Degree;
            existTeacher.Faculty = teacher.Faculty;
            existTeacher.TeachingStatus = teacher.TeachingStatus;
            existTeacher.Experience = teacher.Experience;
            existTeacher.Hobby = teacher.Hobby;
            existTeacher.Email = teacher.Email;
            existTeacher.PhoneNumber = teacher.PhoneNumber;
            existTeacher.Skype = teacher.Skype;
            existTeacher.FacebookUrl = teacher.FacebookUrl;
            existTeacher.PinterestUrl = teacher.PinterestUrl;
            existTeacher.VimeoUrl = teacher.VimeoUrl;
            existTeacher.TwitterUrl = teacher.TwitterUrl;
            existTeacher.PinterestUrl = teacher.PinterestUrl;
            existTeacher.LanguagePercentage = teacher.LanguagePercentage;
            existTeacher.TeamLeaderPercentage = teacher.TeamLeaderPercentage;
            existTeacher.DevelopmentPercentage = teacher.DevelopmentPercentage;
            existTeacher.DesignPercentage = teacher.DesignPercentage;
            existTeacher.InnovationPercentage = teacher.InnovationPercentage;
            existTeacher.ModifiedAt = DateTime.UtcNow;
            existTeacher.CommunicationPercentage = teacher.CommunicationPercentage;

            #region ModelStateCheck
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }
            #endregion

            if (teacher.File != null)
            {
                #region CheckPhotoLength
                if (teacher.File.Length > 3 * (1024 * 1024))
                {
                    ModelState.AddModelError("File", "Cannot be more than 3MB");
                    return View();

                }
                #endregion
                #region CheckPhotoContentType
                if (teacher.File.ContentType != "image/png" && teacher.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Only jpeg and png files accepted");
                    return View();
                }
                #endregion

                string filename = FileManagerHelper.Save(_env.WebRootPath, "uploads/teachers", teacher.File);

                if (!string.IsNullOrWhiteSpace(existTeacher.Photo))
                {
                    FileManagerHelper.Delete(_env.WebRootPath, "uploads/teachers", existTeacher.Photo);
                }

                existTeacher.Photo = filename;
            }


            await _context.SaveChangesAsync();

            return RedirectToAction("index");


        }

        public async Task<IActionResult> Detail(int id)
        {
            Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(s => s.Id == id);

            #region CheckTeacherNotFound
            if (teacher == null)
            {
                return NotFound();
            }
            #endregion

            return View(teacher);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(s => s.Id == id);

            #region CheckTeacherNotFound
            if (teacher == null)
            {
                return NotFound();
            }
            #endregion

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Teacher teacherModel)
        {
            Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(s => s.Id == teacherModel.Id);

            #region CheckTeacherNotFound
            if (teacher == null)
            {
                return NotFound();
            }
            #endregion


            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        
    }
}
