using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RentACar.Models.Entities.Concreate;
using System.ComponentModel.DataAnnotations;

namespace RentACar.DTOs.Response
{
    public class GetAllBrandsResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        [ValidateNever]
        public string PictureUrl { get; set; }

        //public ICollection<CarModel> carModels { get; set; }
    }
}
