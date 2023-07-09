using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PriceMaster.Models;
using PriceMaster.Services;
using PriceMaster.Repositories;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddTransient<IConfigureOptions<AppSettings>>(provider =>
    new ConfigureFromConfigurationOptions<AppSettings>(configuration.GetSection("AppSettings")));

builder.Services.AddTransient<IConfiguratonParameterRepository, ConfiguratonParameterRepository>();
builder.Services.AddTransient<IConfigurationParameterService, ConfigurationParameterService>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "PriceMaster.Cookie";
        options.LoginPath = "/Account/Login";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
});

var app = builder.Build();

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

app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area}/{controller}/{action}/{id?}",
    defaults: new { controller = "Home", action = "Index" }
);

// Use the configuration values as needed in your application
app.Run();
