using AlpTrips.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using AlpTrips.Application.Extensions;
using AlpTrips.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using AlpsTrips.MVC.Models;
using AlpsTrips.MVC.Services;
using AlpTrips.Domain.Entities;
using System;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes= true);
builder.Services.AddDbContext<AlpTripsDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyAlpTripsConnectionString"))
    );

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<AlpTripsDbContext>()
            .AddDefaultTokenProviders();
builder.Services.Configure<SMTPConfigModel>(builder.Configuration.GetSection("SMTPConfig"));
builder.Services.AddScoped<IEmailService,EmailService>();

builder.Services.AddInfrastructure();
builder.Services.AddApplication();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "Details",
    pattern: "Trip/{encodedName}/Details",
    defaults: new { controller = "Trip", action = "Details"}
);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "trip_comment",
        pattern: "Trip/{encodedName}/CommentForTrip",
        defaults: new { controller = "Trip", action = "CommentForTrip" });
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
