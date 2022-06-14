using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using VendasMVC.Data;
using MySqlConnector;
using VendasMVC.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VendasMVCContext>(options =>
    options.UseMySql("server=localhost;initial catalog=vendasmvcdb;uid=root;pwd=1234",
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql")));


    // Add services to the container.
    builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddScoped<ISeedingService, SeedingService>();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    var myDependency = services.GetRequiredService<ISeedingService>();
    myDependency.Seed();
}

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

app.Run();

