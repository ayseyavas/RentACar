

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RentACar.Models.Entities.Concreate;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentACar.DTOs.Request
{
    public class CreateNewCarModelRequest 
    {
        public string name { get; set; }

        
        public int brandId { get; set; }

        //public Brand brand { get; set; }// navigation property

        //public ICollection<Car> cars { get; set; }

        [ValidateNever]
        public string PictureUrl { get; set; }

    }
}
