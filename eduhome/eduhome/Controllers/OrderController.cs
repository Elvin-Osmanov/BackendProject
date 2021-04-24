﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using eduhome.Data;
using eduhome.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eduhome.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Member", AuthenticationSchemes = "Member_Auth")]
        public async Task<IActionResult> Index()
        {
            string userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            List<Order> orders = await _context.Orders
                .Include(x => x.Course)
                .Where(x => x.AppUserId == userId).OrderByDescending(x => x.CreatedAt).ToListAsync();

            return View(orders);
        }

        [HttpPost]
        [Authorize(Roles = "Member", AuthenticationSchemes = "Member_Auth")]
        public async Task<IActionResult> Create(Order order)
        {
            Course course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == order.CourseId);

            if (course == null)
                return NotFound();

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            order.AppUserId = user.Id;
            order.Price = course.Price;
            order.Status = Data.Enums.OrderStatus.Pending;
            order.CreatedAt = DateTime.UtcNow;
            order.ModifiedAt = DateTime.UtcNow;

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
