using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RentACar.Models.Entities.Concreate;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentACar.DTOs.Response
{
    public class GetCarByIdResponse
    {
        public int id { get; set; }

        public string plate { get; set; }

        public int dailyPrice { get; set; }

        public int modelId { get; set; }


        public CarModel model { get; set; }

        public string PictureUrl { get; set; }
    }
}
