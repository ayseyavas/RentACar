using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Models.Entities.Concreate
{
    public class Brand
    {



        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [ValidateNever]
        public string description { get; set; }

        [ValidateNever]
        public ICollection<CarModel> carModels { get; set; }

        //public ICollection<Car> cars { get; set; }

        [ValidateNever]
        public string PictureUrl { get; set; }




    }
}
