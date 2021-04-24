using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eduhome.Areas.Manage.ViewModels;
using eduhome.Data;
using eduhome.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eduhome.Areas.Manage.Controllers
{

    [Area("Manage")]
    public class NoticeController : Controller
    {
        private readonly AppDbContext _context;

        public NoticeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            double totalCount = await _context.Categories.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 5);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            NoticeViewModel noticeVM = new NoticeViewModel
            {
                Notices = await _context.Notices.Skip((page - 1) * 5).Take(5).ToListAsync()
            };
            return View(noticeVM);
        }

        public async Task<IActionResult> Create()
        {
            Notice notice = await _context.Notices.FirstOrDefaultAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Notice notice)
        {
            if (!ModelState.IsValid)
                return View();

            notice.Desc = notice.Desc.Trim();
            notice.CreatedAt = DateTime.UtcNow;
            notice.ModifiedAt = DateTime.UtcNow;

            await _context.Notices.AddAsync(notice);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Notice notice = await _context.Notices.FirstOrDefaultAsync(x => x.Id == id);

            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Notice notice)
        {
            Notice existNotice = await _context.Notices.FirstOrDefaultAsync(x => x.Id == notice.Id);

            if (existNotice == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return View();

            existNotice.Desc = notice.Desc;
            existNotice.ModifiedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Notice notice = await _context.Notices.FirstOrDefaultAsync(x => x.Id == id);


            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Notice notice = await _context.Notices.FirstOrDefaultAsync(x => x.Id == id);

            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Notice notice)
        {
            Notice existNotice = await _context.Notices.FirstOrDefaultAsync(x => x.Id == notice.Id);

            if (existNotice == null)
            {
                return NotFound();
            }

            _context.Notices.Remove(existNotice);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

    }
}
