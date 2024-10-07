using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar.DTOs.Request;
using RentACar.DTOs.Response;
using RentACar.Models.Business.Abstract;
using RentACar.Models.Business.Concreate;
using RentACar.Models.Entities.Concreate;

namespace RentACar.Controllers
{

    //kullanıcın giriş yapmış olması gerekir bu sayfalara ulaşabilmesi için


    public class CarController : Controller
    {
        private ICarService<Car> carManager;
        public CarController(ICarService<Car> carManager)
        {
            this.carManager = carManager;
        }

        public IActionResult Index()
        {
            IEnumerable<GetAllCarsResponse> cars = carManager.GetAll();

            return View(cars);
        }


        [HttpGet]
        public IActionResult AddNewCar()
        {
            IEnumerable<SelectListItem> carModelList = carManager.GetAllCarModels()
                .Select(x => new SelectListItem
                {
                    Text = x.name,
                    Value = x.id.ToString()

                });

            ViewBag.carModelList = carModelList;

            return View();

        }

        [HttpPost]
        public IActionResult AddNewCar(CreateNewCarRequest createNewCarRequest, IFormFile file)
        {

            carManager.AddNewCar(createNewCarRequest,file);
        
            return RedirectToAction("Index");
        }
    }
}
