using System.ComponentModel.DataAnnotations;
namespace GiftOfGivers.Models
{
    public class ReliefProject
    {
        public int ReliefProjectID {  get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description {  get; set; } = string.Empty;

        [StringLength (100)]
        public string Location {  get; set; } = string.Empty;

        public DateTime DatePosted { get; set; } = DateTime.Now;

        public string PostedByEmployee {  get; set; } = string.Empty;
    }
}
