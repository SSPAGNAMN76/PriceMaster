using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PriceMaster.Models;
using PriceMaster.Repositories;
using PriceMaster.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
builder.Services.AddSingleton(configuration);
builder.Services.AddTransient<IConfigureOptions<AppSettings>>(provider =>
    new ConfigureFromConfigurationOptions<AppSettings>(configuration.GetSection("AppSettings")));

builder.Services.AddTransient<IConfiguratonParameterRepository, ConfiguratonParameterRepository>();
builder.Services.AddTransient<IConfigurationParameterService, ConfigurationParameterService>();

// Configurazione del servizio di autenticazione
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "PriceMaster.Cookie";
        options.LoginPath = "/Account/Login";
    });

// Configurazione dei requisiti di autorizzazione
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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areaRoute",
        pattern: "{area}/{controller}/{action}/{id?}",
        defaults: new { controller = "Home", action = "Index" }
    );
});

// Accessing the configuration values
var appSettings = app.Services.GetRequiredService<IOptions<AppSettings>>().Value;
var connectionString = configuration.GetConnectionString("PriceMasterConnectionString");

// Use the configuration values as needed in your application
app.Run();