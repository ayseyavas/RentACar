using Microsoft.AspNetCore.Identity;

namespace RentACar.Utilities
{
    public class UserRoles :IdentityRole
    {
        public const string Role_Admin = "Admin";
        public const string Role_User = "User";

    }
}
