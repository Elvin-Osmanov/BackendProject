using eduhome.Areas.Manage.ViewModels;
using eduhome.Data;
using eduhome.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eduhome.Services
{
    public class LayoutViewModelService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public Subscriber Subscriber { get; set; }

      

        public LayoutViewModelService(AppDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Setting GetSettings()
        {
            return _context.Settings.FirstOrDefault();
        }


        
        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

    }
}
