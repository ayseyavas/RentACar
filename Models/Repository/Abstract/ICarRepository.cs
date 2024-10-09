using RentACar.DTOs.Response;
using RentACar.Models.Entities.Concreate;

namespace RentACar.Models.Repository.Abstract
{
    public interface ICarRepository: IRepository<Car> 
    {
        IEnumerable<Car> GetCarsByFilters(int? brandId = null, int? modelId = null, int? minPrice = null, int? maxPrice = null);

    }
}
