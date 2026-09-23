using GiftOfGivers.Data;
using GiftOfGivers.Models;
using GiftOfTheGivers.Helpers; 
using Microsoft.AspNetCore.Mvc;

namespace GiftOfGivers.Controllers
{
    public class DonateController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DonateController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index() => View(new Donation());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Donation donation)
        {
            if (!ModelState.IsValid) return View(donation);

            donation.DonationDate = DateTime.Now;

            _context.Donations.Add(donation);
            _context.SaveChanges();

            // NOW we have the ID, use Helper correctly
            donation.CertificateNumber = DonationHelper.FormatCertificate(donation.DonationID.ToString());
            _context.SaveChanges();

            return RedirectToAction("Certificate", new { id = donation.DonationID });
        }

        public IActionResult Certificate(int id)
        {
            var donation = _context.Donations.Find(id);
            if (donation == null) return NotFound();

            ViewBag.ThankYou = DonationHelper.ThankYou(donation.DonorName);
            ViewBag.Total = DonationHelper.CalctOTAL(donation.Amount);

            return View(donation);
        }
    }
}
