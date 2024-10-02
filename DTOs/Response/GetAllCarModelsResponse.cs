using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RentACar.Models.Entities.Concreate;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentACar.DTOs.Response
{
    public class GetAllCarModelsResponse
    {
     
        public int id { get; set; }
     
        public string name { get; set; }

        
        public int brandId { get; set; }

        public Brand brand { get; set; }



    }
}
