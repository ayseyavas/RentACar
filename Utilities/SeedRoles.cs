using Microsoft.AspNetCore.Identity;
using RentACar.Models;
using RentACar.Utilities;

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

        if (await userManager.FindByEmailAsync(email) == null)
        {
            var user = new AppUser();
            user.UserName = email;
            user.Email = email;
            user.EmailConfirmed = true;

            userManager.CreateAsync(user, password);

           await userManager.AddToRoleAsync(user, "Admin");
        }



    }
}
