using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using PriceMaster.Models;
using PriceMaster.Services;
using System.Data;
using System.Data.SqlClient;
using PriceMaster.Repositories;

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area}/{controller}/{action}/{id?}",
    defaults: new { controller = "Home", action = "Index" }
);

var connectionString = configuration.GetConnectionString("PriceMasterConnectionString");
builder.Services.AddTransient<IDbConnection>(provider => new SqlConnection(connectionString));

// Use the configuration values as needed in your application
app.Run();
