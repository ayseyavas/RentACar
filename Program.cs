using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using RentACar.Models;
using RentACar.Models.Business.Abstract;
using RentACar.Models.Business.Concreate;
using RentACar.Models.Entities.Concreate;
using RentACar.Models.Repository.Abstract;
using RentACar.Models.Repository.Concreate;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();




builder.Services.AddScoped<IBrandService<Brand>, BrandManager>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICarModelService<CarModel>, CarModelManager>();
builder.Services.AddScoped<ICarModelRepository,CarModelRepository>();
builder.Services.AddScoped<ICarService<Car>, CarManager>();


builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddScoped<ICarRepository,CarRepository>();
builder.Services.AddScoped<AppUser>();
builder.Services.AddAutoMapper(typeof(Program));





////oldu oroospuçcou bunlarý yapýnca karýnýnamk
//builder.Services.AddScoped<UserManager<AppUser>>();
//builder.Services.AddScoped<SignInManager<AppUser>>();





//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<AppDbContext>();


//builder.Services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
//  .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddDefaultTokenProviders();  // Token bazlý iþlemler için (email doðrulama gibi)


builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    // Diðer Identity ayarlarý
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();





builder.Services.AddRazorPages();












var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        SeedRoles.InitializeRoles(services).Wait();

    }
    catch(Exception ex)
    {
        var logger= services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Hata bro");
    }


    
}





app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();


app.UseAuthentication(); // Bu satýrý ekleyin

app.UseAuthorization();





app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
