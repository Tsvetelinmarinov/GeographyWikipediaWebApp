/*
 * Entry point of the application.
 */

using Geography.Data.Context;
using Geography.Data.Repository;
using Geography.Services.AutoMapper;
using Geography.Services.Continent;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GeographyContext>();
builder.Services.AddScoped<IRepository, GeographyRepository>();
builder.Services.AddScoped<IContinentsService, ContinentsService>();
builder.Services.AddAutoMapper(config => config.AddProfile<Mapper>());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}")
   .WithStaticAssets();

app.Run();