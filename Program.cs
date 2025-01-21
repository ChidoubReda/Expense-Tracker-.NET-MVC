using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Expense_Tracker.Data;
using System.Security.Policy;
using Expense_Tracker.Models;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Expense_TrackerContextConnection") ?? throw new InvalidOperationException("Connection string 'Expense_TrackerContextConnection' not found.");

builder.Services.AddDbContext<Expense_TrackerContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Expense_TrackerContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injection
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Expense_TrackerContextConnection")));
var app = builder.Build();

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2XVhhQlJHfV1dXGVWfFN0QHNYfVRydV9DZEwxOX1dQl9mSX9SfkVhXHhddnxQQGA=");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
