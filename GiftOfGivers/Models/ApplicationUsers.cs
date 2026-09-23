using Microsoft.AspNetCore.Identity;
namespace GiftOfGivers.Models
{
    public class ApplicationUsers : IdentityUser
    {
        public string FullName { get; set; } = string .Empty;
    }
}
