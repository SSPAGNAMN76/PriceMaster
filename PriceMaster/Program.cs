using Microsoft.Extensions.Options;
using PriceMaster.Models;
using PriceMaster.Repository;

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

// Accessing the configuration values
var appSettings = app.Services.GetRequiredService<IOptions<AppSettings>>().Value;
var connectionString = configuration.GetConnectionString("PriceMasterConnectionString");

// Use the configuration values as needed in your application
app.Run();