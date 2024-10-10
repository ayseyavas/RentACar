using RentACar.DTOs.Request;
using RentACar.DTOs.Response;
using RentACar.Models.Entities.Concreate;

namespace RentACar.Models.Business.Abstract
{
    public interface ICarService<T> where T : class
    {
        void AddNewCar(CreateNewCarRequest createNewCarRequest, IFormFile file);
        public IEnumerable<GetAllCarsResponse> GetAll( string? includeProps = null);

        IEnumerable<GetAllCarsResponse> GetCarsByFilters(int? brandId = null, int? modelId = null, int? minPrice = null, int? maxPrice = null);

        //public IEnumerable<GetAllCarsResponse> GetAll();

        public IEnumerable<GetAllCarModelsResponse> GetAllCarModels();

        public IEnumerable<GetAllBrandsResponse> GetAllBrands();

        public void DeleteCar(GetCarByIdResponse getCarByIdResponse);

        public GetCarByIdResponse GetCarById(int id);

    }
}
