using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
namespace GiftOfGivers.Models
{
    public class Donation
    {
        public int DonationID { get; set; }

       public string? DonorName { get; set; }

        [Required]
        [Range(1, 1000000, ErrorMessage = "Please enter an amount greater than 0")]
        public decimal Amount { get; set; }

        [Required]
        public string Currency { get; set; } = "ZAR";

        public bool IsRecurring { get; set; }

        public DateTime DonationDate { get; set; } = DateTime.Now;

        public string CertificateNumber { get; set; } = string.Empty;
    }
}
