using Microsoft.AspNetCore.Identity;
using TicketManagementSystem.Data;
using TicketManagementSystem.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityCore<ApplicationUser>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 12;
        options.SignIn.RequireConfirmedAccount = true;
        options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789- ";
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddErrorDescriber<CustomIdentityErrorDescriber>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication(); // IMPORTANT : Doit être avant UseAuthorization
app.UseAuthorization();

app.UseAntiforgery();

app.MapGet("/", () => "Hello World!");

app.Run();
