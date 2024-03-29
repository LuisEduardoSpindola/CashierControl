using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CashierControl.Areas.Identity.Data;
using CashierControl.Interfaces;
using CashierControl.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CashierControlContextConnection") ?? throw new InvalidOperationException("Connection string 'CashierControlContextConnection' not found.");
builder.Services.AddDbContext<CashierControlContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<Cashier>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<CashierControlContext>();

builder.Services.AddScoped<IReports, ReportRepositories>();

// Add services to the container.
builder.Services.AddControllersWithViews();


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

app.MapRazorPages();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
