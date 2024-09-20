using Microsoft.EntityFrameworkCore;
using MultiTierArchitecture.Business.Abstract;
using MultiTierArchitecture.Business.Concrete;
using MultiTierArchitecture.DataAccess;
using MultiTierArchitecture.DataAccess.Abstract;
using MultiTierArchitecture.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Veritaban� ba�lam� i�in SQL Server ba�lant�s�n� yap�land�rma
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IContentService, ContentService>();

builder.Services.AddControllers();

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

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Main}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
