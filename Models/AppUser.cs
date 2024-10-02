using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Models
{
    public class AppUser : IdentityUser
    {

        [Required]
        public string name { get; set; }
        [Required]
        public string lastName { get; set; }

        [Required]
        public long nationalId { get; set; }

        [Required]
        public int birthYear { get; set; }

        public bool isVerified { get; set; }    
    
     

    }
}
