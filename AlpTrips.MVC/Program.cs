using AlpTrips.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using AlpTrips.Application.Extensions;
using AlpTrips.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes= true);
builder.Services.AddDbContext<AlpTripsDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyAlpTripsConnectionString"))
    );



//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    //.AddEntityFrameworkStores<AlpTripsDbContext>();


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
