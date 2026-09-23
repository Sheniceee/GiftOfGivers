using GiftOfGivers.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace GiftOfGivers.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers>
    { 
    public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base (options)
    { 
            }
    
    public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<ReliefProject> ReliefProjects { get; set; }
    }
}
