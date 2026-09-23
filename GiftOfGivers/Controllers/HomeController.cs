using GiftOfGivers.Data;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace GiftOfGivers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
            public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index() => View();
        public IActionResult About() => View();
        public IActionResult Contact() => View();
        public IActionResult Projects()
        {
            var projects = _context.ReliefProjects
                .OrderByDescending(p => p.DatePosted)
                .ToList();
            return View(projects);
        }
    public IActionResult error() => View(); }
}
