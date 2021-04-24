using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eduhome.Data;
using eduhome.Data.Entities;
using eduhome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eduhome.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ContactViewModel contactVM = new ContactViewModel
            {
                Contact = _context.Contacts.FirstOrDefault()
            };
            return View(contactVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Message(ContactMessage message1)
        {
            Contact contact = await _context.Contacts.Include(x => x.ContactMessages).FirstOrDefaultAsync(x => x.Id == message1.ContactId);

            if (contact == null)
                return NotFound();


            ContactMessage contactMessage = new ContactMessage
            {
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                Email = message1.Email,
                FullName = message1.FullName,
                ContactId = message1.ContactId,
                Subject = message1.Subject,
                Message = message1.Message
            };

            contact.ContactMessages.Add(contactMessage);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
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
