using GiftOfGivers.Data;
using GiftOfGivers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

QuestPDF.Settings.License = LicenseType.Community;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseInMemoryDatabase("GiftOfGiversProtoype"));

builder.Services.AddIdentity<ApplicationUsers, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDdenied";

});

builder.Services.AddControllersWithViews();

var app= builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedData.InitializeAsync(services);
}
if (!app.Environment.IsDevelopment())
{
    
        app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    }
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

string pattern = "{controller=Home}/{action=Index}/{id?}";
Console.WriteLine("Pattern: " + pattern);
for (int i = 0; i < pattern.Length; i++)
{
    Console.WriteLine($"[{i}] '{pattern[i]}' (U+{(int)pattern[i]:X4})");
}
app.MapControllerRoute(name: "default", pattern: pattern);

app.Run();

