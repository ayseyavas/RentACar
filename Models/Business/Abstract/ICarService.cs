using RentACar.DTOs.Request;
using RentACar.DTOs.Response;
using RentACar.Models.Entities.Concreate;

namespace RentACar.Models.Business.Abstract
{
    public interface ICarService<T> where T : class
    {
        void AddNewCar(CreateNewCarRequest createNewCarRequest);
        public IEnumerable<GetAllCarsResponse> GetAll(string? includeProps = null);

        //public IEnumerable<GetAllCarsResponse> GetAll();

        public IEnumerable<GetAllCarModelsResponse> GetAllCarModels();
    }
}
