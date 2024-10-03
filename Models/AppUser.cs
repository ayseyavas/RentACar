using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Models
{
    [ValidateNever]
    public class AppUser : IdentityUser
    {
        
        public string? name { get; set; }
        public string? lastName { get; set; }

        public long? nationalId { get; set; }

        public int? birthYear { get; set; }

        public bool? isVerified { get; set; }    
    
     

    }
}
