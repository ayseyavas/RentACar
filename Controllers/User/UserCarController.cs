using Microsoft.AspNetCore.Mvc;
using RentACar.DTOs.Response;
using RentACar.Models.Business.Abstract;

namespace RentACar.Controllers.User
{

    public class UserCarController : Controller
    {
        private ICarService<Car> carManager;
        public UserCarController(ICarService<Car> carManager)
        {
            this.carManager = carManager;
        }
        public IActionResult Index(int? brandId, int? carModelId)
        {

            IEnumerable<GetAllCarsResponse> cars = carManager.GetAll();

            return View(cars);
        }
    }
}
