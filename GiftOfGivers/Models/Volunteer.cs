using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
namespace GiftOfGivers.Models
{
    public class Volunteer
    {
        public int VolunteerID { get; set; }
        [Required(ErrorMessage = "Please enter your full name")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please list your skills")]
        [StringLength(255)]
        public string Skills { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please tell me your availability")]
        [StringLength(100)]
        public string Availability { get; set; } = string.Empty;

        public DateTime DateRegistered { get; set; } = DateTime.Now;
    }
}
