using RentACar.Models.Entities.Concreate;

namespace RentACar.Utilities.Filters
{
    public class CarFilerAjaxData
    {

        public int? brandId { get; set; }
        public int? modelId { get; set; }

        public int? minPrice { get; set; }
        public int? maxPrice { get; set; }

    }
}
