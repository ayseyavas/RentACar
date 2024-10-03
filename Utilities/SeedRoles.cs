using Microsoft.AspNetCore.Identity;
using RentACar.Models;
using RentACar.Utilities;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class SeedRoles
{
    public static async Task InitializeRoles(IServiceProvider serviceProvider)
    {
        //Kullanıcı rollerinin oluşturulması

        string[] roleNames = { UserRoles.Role_Admin, UserRoles.Role_User };

        IdentityResult roleResult;

        foreach (var role in roleNames)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roleExists = await roleManager.RoleExistsAsync(role);

            if (!roleExists)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(role));
            }
        }



        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

        string email = "admin@admin.com";
        string password = "Test1.";

        var user = await userManager.FindByEmailAsync(email);

        if (user==null)
        {
             user = new AppUser();
            user.UserName = email;
            user.Email = email;
            user.EmailConfirmed = true;
            user.isVerified = true;

            var createAdminResult=await userManager.CreateAsync(user, password);

            if(createAdminResult.Succeeded)
            {
                await userManager.AddToRoleAsync(user,UserRoles.Role_Admin);

            }
            else
            {
                foreach(var err in createAdminResult.Errors)
                {
                    Console.WriteLine($"Error: {err.Description}");

                }
            }
        }



    }
}
