/*
 * Entry point of the application.
 */

using Geography.Data.Context;
using Geography.Data.Repository;
using Geography.Services;
using Geography.Data.AutoMapper;
using Geography.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Register MVC and the application services required by controllers.
builder.Services.AddControllersWithViews();

// Register the EF Core context and repository with scoped lifetimes for each HTTP request.
builder.Services.AddDbContext<GeographyContext>();
builder.Services.AddScoped<IRepository, GeographyRepository>();

// Register the business services consumed by the country and continent controllers.
builder.Services.AddScoped<IContinentsService, ContinentsService>();
builder.Services.AddScoped<ICountriesService, CountriesService>();

// Register the profile that maps database entities to view models and back.
builder.Services.AddAutoMapper(config => config.AddProfile<Mapper>());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // Use a friendly error page and HTTP Strict Transport Security outside local development.
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Expose files from wwwroot, including stylesheets and JavaScript.
app.MapStaticAssets();

// Use the conventional MVC route: /{controller}/{action}/{id?}.
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}")
   .WithStaticAssets();

app.Run();