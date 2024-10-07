using RentACar.DTOs;
using RentACar.DTOs.Request;
using RentACar.DTOs.Response;
using RentACar.Models.Entities.Concreate;

namespace RentACar.Models.Business.Abstract
{
    public interface IBrandService<T> where T : class
    {
        void AddNewBrand(CreateNewBrandRequest createNewBrandRequest, IFormFile? file);
        public IEnumerable<GetAllBrandsResponse> GetAll(string? includeProps = null);

        void UpdateBrand(UpdateBrandRequest updateBrandRequest, IFormFile file);

        GetBrandByIdResponse GetBrandById(int id);    

        void DeleteBrand(GetBrandByIdResponse getBrandByIdResponse);

    }
}
