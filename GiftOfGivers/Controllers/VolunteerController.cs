using System;
using GiftOfGivers.Data;
using GiftOfGivers.Models;
using Microsoft.AspNetCore.Mvc;
namespace GiftOfGivers.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VolunteerController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index() => View(new Volunteer());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Volunteer volunteer)
        {
            if (!ModelState.IsValid) return View(volunteer);

            volunteer.DateRegistered = DateTime.Now;
            _context.Volunteers.Add(volunteer);
            _context.SaveChanges();

            return RedirectToAction("ThankYou");
        }
        public IActionResult ThankYou() => View();
    }
}
