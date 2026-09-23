using GiftOfGivers;
using GiftOfGivers.Models;
using Microsoft.AspNetCore.Identity;
namespace GiftOfGivers.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUsers>>();

            string[] roles = { "Employee", "Donor" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            const string employeeEmail = "employee@gitofthegivers.org";
            if (await userManager.FindByEmailAsync(employeeEmail) == null)
            {
                var employee = new ApplicationUsers
                {
                    UserName = employeeEmail,
                    Email = employeeEmail,
                    FullName = "Demo Employee",
                    EmailConfirmed = true,

                };
                var result = await userManager.CreateAsync(employee, "Employee123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(employee, "Employee");
                }
            }
        }
    }
}