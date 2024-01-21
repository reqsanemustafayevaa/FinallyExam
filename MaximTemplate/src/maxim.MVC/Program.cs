using maxim.business.Services.Implementations;
using maxim.business.Services.Interfaces;
using maxim.core.Repositories.Interfaces;
using maxim.data.DAL;
using maxim.data.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFeatureRepository,FeatureRepository>();
builder.Services.AddScoped<IFeatureService,FeatureService>();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer("server=DESKTOP-FJ28S1F;database=MaximTemplate;Trusted_Connection=True;");
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

app.UseAuthorization();
app.MapControllerRoute(
			name: "areas",
			pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
		  );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
