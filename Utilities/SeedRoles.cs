using Microsoft.AspNetCore.Identity;
using RentACar.Utilities;

public class SeedRoles
{
    public static async Task InitializeRoles(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roles = { UserRoles.Role_Admin, UserRoles.Role_User };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
