using RentACar.DTOs.Request;
using RentACar.DTOs.Response;
using RentACar.Models.Entities.Concreate;

namespace RentACar.Models.Business.Abstract
{
    public interface ICarModelService<T> where T : class
    {
        void AddNewCarModel(CreateNewCarModelRequest createNewCarModelRequest, IFormFile? file);

        public IEnumerable<GetAllCarModelsResponse> GetAll(string? includeProps = null);

        public GetCarModelByIdResponse GetCarModelById(int id);

        //public UpdateCarModelRequest UpdateCarModel(UpdateCarModelRequest updateCarModelRequest);   

        public IEnumerable<GetAllBrandsResponse> getAllBrandsResponses(string? includeProps = null);

        public void updateCarModel(UpdateCarModelRequest updateCarModelRequest, IFormFile file);

        public void deleteCarModel(GetCarModelByIdResponse getCarModelByIdResponse);
    }
}
