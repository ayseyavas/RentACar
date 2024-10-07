using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace RentACar.DTOs.Request
{
    public class CreateNewBrandRequest
    {
        
        public string name { get; set; }
        public string description { get; set; }

        [ValidateNever]
        public string PictureUrl { get; set; }


    }
}
