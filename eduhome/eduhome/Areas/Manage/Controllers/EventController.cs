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
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EventController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            double totalCount = await _context.Events.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 5);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;
            
            EventViewModel eventVM = new EventViewModel
            {
                Events = await _context.Events.Include(x => x.Category).Skip((page - 1) * 5).Take(5).ToListAsync()
            };

            return View(eventVM);

        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            ViewBag.Teachers = await _context.Teachers.ToListAsync();

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Event eventModel)
        {

            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            ViewBag.Teachers = await _context.Teachers.ToListAsync();

            if (await _context.Events.AnyAsync(x => x.Title.ToLower() == eventModel.Title.Trim().ToLower()))
            {

                ModelState.AddModelError("Title", "Course already exists!");
                return View();
            }

            if (!await _context.Categories.AnyAsync(c => c.Id == eventModel.CategoryId))
            {

                ModelState.AddModelError("CategoryId", "Category already exists!");
                return View();
            }

           

            if (!ModelState.IsValid)
            {

                return View();
            }

            eventModel.EventTags = await _createEventTags(eventModel.TagIds);

            if (eventModel.File != null)
            {
                #region CheckPhotoLength
                if (eventModel.File.Length > 3 * (1024 * 1024))
                {

                    ModelState.AddModelError("File", "Cannot be more than 3MB");
                    return View();

                }
                #endregion
                #region CheckPhotoContentType
                if (eventModel.File.ContentType != "image/png" && eventModel.File.ContentType != "image/jpeg")
                {

                    ModelState.AddModelError("File", "Only jpeg and png files accepted");
                    return View();
                }
                #endregion

                string filename = FileManagerHelper.Save(_env.WebRootPath, "uploads/events", eventModel.File);

                eventModel.Photo = filename;
            }

            eventModel.CreatedAt = DateTime.UtcNow;
            eventModel.ModifiedAt = DateTime.UtcNow;
            await _context.Events.AddAsync(eventModel);
            await _context.SaveChangesAsync();


            return RedirectToAction("index");
        }

        private async Task<List<EventTag>> _createEventTags(int[] tagIds)
        {

            List<EventTag> eventTags = new List<EventTag>();
            foreach (var tagId in tagIds)
            {
                if (!await _context.Tags.AnyAsync(x => x.Id == tagId))
                {
                    throw new Exception("Tag does not exist!");
                }

                EventTag eventTag = new EventTag
                {
                    TagId = tagId
                };

                eventTags.Add(eventTag);
            }

            return eventTags;
        }
        public async Task<IActionResult> Edit(int id)
        {
            Event eventmodel = await _context.Events
                .Include(x => x.EventTags).Include(x => x.EventTeachers)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (eventmodel == null)
            {
                return NotFound();
            }

            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            ViewBag.Teachers = await _context.Teachers.ToListAsync();

            return View(eventmodel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Event eventModel)
        {
            Event existEvent = await _context.Events
                .Include(x => x.EventTags).Include(x => x.EventTeachers)
                .FirstOrDefaultAsync(x => x.Id == eventModel.Id);

            if (existEvent == null)
                return NotFound();

            if (!await _context.Categories.AnyAsync(x => x.Id == eventModel.CategoryId))
                return NotFound();

            if (await _context.Events.AnyAsync(x => x.Title.ToLower() == eventModel.Title.Trim().ToLower() && x.Id != eventModel.Id))
                return NotFound();

            existEvent.EventTags = await _getUpdatedEventTagsAsync(existEvent.EventTags, eventModel.TagIds, eventModel.Id);

            if (eventModel.File != null)
            {
                #region PhotoLengthChecking
                if (eventModel.File.Length > 3 * (1024 * 1024))
                {
                    ModelState.AddModelError("File", "Cannot be more than 3MB");
                    return View();

                }
                #endregion
                #region PhotoContentTypeChecking
                if (eventModel.File.ContentType != "image/png" && eventModel.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Only jpeg and png files accepted");
                    return View();
                }
                #endregion

                string filename = FileManagerHelper.Save(_env.WebRootPath, "uploads/events", eventModel.File);

                if (!string.IsNullOrWhiteSpace(existEvent.Photo))
                {
                    FileManagerHelper.Delete(_env.WebRootPath, "uploads/events", existEvent.Photo);
                }

                existEvent.Photo = filename;
            }

            existEvent.Title = eventModel.Title.Trim();
            existEvent.Venue = eventModel.Venue;
            existEvent.Desc = eventModel.Desc;
            existEvent.StartDate = eventModel.StartDate;
            existEvent.EndDate = eventModel.EndDate;
            existEvent.EventDate = eventModel.EventDate;
            existEvent.ModifiedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Event eventmodel = await _context.Events.FirstOrDefaultAsync(s => s.Id == id);

            #region CheckSliderNotFound
            if (eventmodel == null)
            {
                return NotFound();
            }
            #endregion
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            ViewBag.Teachers = await _context.Teachers.ToListAsync();
            return View(eventmodel);
        }



        public async Task<IActionResult> Delete(int id)
        {
            Event eventmodel = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);

            if (eventmodel == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            ViewBag.Teachers = await _context.Teachers.ToListAsync();
            return View(eventmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Event eventModel)
        {
            Event existevent = await _context.Events.FirstOrDefaultAsync(x => x.Id == eventModel.Id);

            if (existevent == null)
            {
                return NotFound();
            }

            _context.Events.Remove(existevent);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        
        public async Task<IActionResult> Review(int eventId)
        {
            List<EventReview> eventReviews = await _context.EventReviews.Where(x => x.EventId == eventId).ToListAsync();

            return View(eventReviews);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteReview(int id)
        {
            EventReview review = await _context.EventReviews.FirstOrDefaultAsync(x => x.Id == id);
            Event eventmodel = await _context.Events.Include(x => x.EventReviews).FirstOrDefaultAsync(x => x.Id == review.EventId);


            if (review == null)
                return NotFound();

            _context.EventReviews.Remove(review);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        private async Task<List<EventTeacher>> _createEventTechers(int[] teacherIds)
        {

            List<EventTeacher> eventTeachers = new List<EventTeacher>();
            foreach (var teacherId in teacherIds)
            {
                if (!await _context.Events.AnyAsync(x => x.Id == teacherId))
                {
                    throw new Exception("Teacher does not exist!");
                }

                EventTeacher eventTeacher = new EventTeacher
                {
                    TeacherId = teacherId
                };

            eventTeachers.Add(eventTeacher);
            }

            return eventTeachers;
        }

        #region UpdatedEventTags
        private async Task<List<EventTag>> _getUpdatedEventTagsAsync(List<EventTag> eventTags, int[] tagIds, int eventId)
        {
            List<EventTag> removableTags = new List<EventTag>();
            removableTags.AddRange(eventTags);

            foreach (var tagId in tagIds)
            {
                EventTag tag = eventTags.FirstOrDefault(x => x.TagId == tagId);

                if (tag != null)
                {
                    removableTags.Remove(tag);
                }
                else
                {
                    if (!await _context.Tags.AnyAsync(x => x.Id == tagId))
                    {
                        throw new Exception("Tag does not exist!");
                    }

                    tag = new EventTag
                    {
                        TagId = tagId,
                        EventId = eventId
                    };

                    eventTags.Add(tag);
                }
            }

            eventTags = eventTags.Except(removableTags).ToList();

            return eventTags;
        }

        #endregion


        #region UpdatedEventTags
        private async Task<List<EventTeacher>> _getUpdatedEventTeachersAsync(List<EventTeacher> eventTeachers, int[] teacherIds, int eventId)
        {
            List<EventTeacher> removableTags = new List<EventTeacher>();
            removableTags.AddRange(eventTeachers);

            foreach (var teacherId in teacherIds)
            {
                EventTeacher teacher = eventTeachers.FirstOrDefault(x => x.TeacherId == teacherId);

                if (teacher != null)
                {
                    removableTags.Remove(teacher);
                }
                else
                {
                    if (!await _context.Teachers.AnyAsync(x => x.Id == teacherId))
                    {
                        throw new Exception("Teacher does not exist!");
                    }

                    teacher = new EventTeacher
                    {
                        TeacherId = teacherId,
                        EventId = eventId
                    };

                    eventTeachers.Add(teacher);
                }
            }

            eventTeachers = eventTeachers.Except(removableTags).ToList();

            return eventTeachers;
        }

        #endregion
    }
}
