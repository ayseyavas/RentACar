using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentACar.Models;
using RentACar.Models.Business.Abstract;
using RentACar.Models.Business.Concreate;
using RentACar.Models.Entities.Concreate;
using RentACar.Models.Repository.Abstract;
using RentACar.Models.Repository.Concreate;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBrandService<Brand>, BrandManager>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICarModelService<CarModel>, CarModelManager>();
builder.Services.AddScoped<ICarModelRepository,CarModelRepository>();
builder.Services.AddScoped<ICarService<Car>, CarManager>();

builder.Services.AddScoped<ICarRepository,CarRepository>();
builder.Services.AddScoped<AppUser>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();


//oldu oroospuçcou bunlarý yapýnca karýnýnamk
builder.Services.AddScoped<UserManager<AppUser>>();
builder.Services.AddScoped<SignInManager<AppUser>>();
builder.Services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();  // Token bazlý iþlemler için (email doðrulama gibi)







builder.Services.AddRazorPages();










builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


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





app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
