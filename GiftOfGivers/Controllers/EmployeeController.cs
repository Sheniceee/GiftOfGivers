using GiftOfGivers.Data;
using GiftOfGivers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace GiftOfGivers.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Dashboard()
        {
            ViewBag.VolunteerCount = _context.Volunteers.Count();
            ViewBag.DonationTotal = _context.Donations.Sum(d => (decimal?)d.Amount) ?? 0;
            ViewBag.ProjectCount = _context.ReliefProjects.Count();
            return View();
        }
        public IActionResult VolunteerSignUps(string? skillFilter)
        {
            var volunteers = _context.Volunteers.AsQueryable();
            if (!string.IsNullOrWhiteSpace(skillFilter))
            {
                volunteers = volunteers.Where(v => v.Skills.Contains(skillFilter));
            }
            ViewBag.SkillFilter = skillFilter;
            return View(volunteers.OrderByDescending(v => v.DateRegistered).ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostUpdate(ReliefProject project)
        {
            if (!ModelState.IsValid) return View(project);

            project.DatePosted = DateTime.Now;
            project.PostedByEmployee = User.Identity?.Name ?? "Employee";

            _context.ReliefProjects.Add(project);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }
    }
}