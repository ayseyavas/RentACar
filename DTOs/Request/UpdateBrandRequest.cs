using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RentACar.DTOs.Request
{
    public class UpdateBrandRequest
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }

        [ValidateNever]
        public string PictureUrl { get; set; }

    }
}
