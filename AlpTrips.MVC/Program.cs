using AlpTrips.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using AlpTrips.Application.Extensions;
using AlpTrips.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes= true);
builder.Services.AddDbContext<AlpTripsDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyAlpTripsConnectionString"))
    );
builder.Services.AddInfrastructure();
builder.Services.AddApplication();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
