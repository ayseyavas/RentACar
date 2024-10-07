using Microsoft.AspNetCore.Mvc;
using RentACar.DTOs.Response;
using RentACar.Models.Business.Abstract;
using RentACar.Models.Entities.Concreate;

namespace RentACar.Controllers.User
{
    public class UserCarModelController : Controller
    {
        public readonly ICarModelService<CarModel> carModelManager;

        public UserCarModelController(ICarModelService<CarModel> carModelManager)
        {
            this.carModelManager = carModelManager;
        }

        public IActionResult Index()
        {

            IEnumerable<GetAllCarModelsResponse> carModels =carModelManager.GetAll();
            return View(carModels);
        }
    }
}
