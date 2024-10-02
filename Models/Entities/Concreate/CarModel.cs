using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Models.Entities.Concreate
{
    public class CarModel
    {
        [Key]
        public int id { get; set; }
        [ValidateNever]
        public string name { get; set; }

        [ValidateNever]
        public int brandId { get; set; }

       
        public Brand brand { get; set; }// navigation property

        public ICollection<Car> cars { get; set; }
    }
}
