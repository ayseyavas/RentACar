using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RentACar.Models.Entities.Concreate;
using System.ComponentModel.DataAnnotations;

namespace RentACar.DTOs.Response
{
    public class GetAllCarsResponse
    {
        
        public int id { get; set; }

        
        public string plate { get; set; }

        
        public int dailyPrice { get; set; }


        public int modelId { get; set; }


        public CarModel model { get; set; }

        public int brandId { get; set; }

        public Brand brand { get; set; }

        [ValidateNever]
        public string PictureUrl { get; set; }

    }
}
