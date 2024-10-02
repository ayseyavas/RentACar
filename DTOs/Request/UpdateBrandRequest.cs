namespace RentACar.DTOs.Request
{
    public class UpdateBrandRequest
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public int brandId { get; set; }

    }
}
