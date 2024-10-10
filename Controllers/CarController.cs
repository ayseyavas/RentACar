using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentACar.DTOs.Request;
using RentACar.DTOs.Response;
using RentACar.Models.Business.Abstract;
using RentACar.Models.Business.Concreate;
using RentACar.Models.Entities.Concreate;
using RentACar.Utilities.Filters;

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

            var cars = carManager.GetAll();

           


            // IEnumerable<GetAllCarsResponse> cars = carManager.GetAll();

            //IEnumerable<SelectListItem> carModelList = carManager.GetAllCarModels()
            //    .Select(x => new SelectListItem
            //    {
            //        Text = x.name,
            //        Value = x.id.ToString()

            //    });

            //ViewBag.carModelList = carModelList;

             IEnumerable<SelectListItem> brandList = carManager.GetAllCarModels()
               .DistinctBy(x=>x.brand.id)
              .Select(x => new SelectListItem
              {
                  Text = x.brand.name,
                  Value = x.brand.id.ToString()

              });

            ViewBag.brandList = brandList;

            return View(cars);
        }


        public IActionResult GetCarModelsByBrand(int brandId)
            {
            // Marka ID'sine göre ilgili modelleri getir
            var carModels = carManager.GetAllCarModels()
                .Where(x => x.brandId == brandId)
                .Select(x => new SelectListItem
                {
                    Text = x.name,
                    Value = x.id.ToString()
                })
                .ToList();

            return Json(carModels); // JSON formatında döndür
        }


        [HttpGet]
        public IActionResult Sa(CarFilerAjaxData carFilerAjaxData)
        {
            int? brandId = carFilerAjaxData.brandId;
            int? modelId = carFilerAjaxData.modelId;

            int? minPrice = carFilerAjaxData.minPrice;
            int? maxPrice = carFilerAjaxData.maxPrice;

            var cars = carManager.GetCarsByFilters(brandId, modelId, minPrice, maxPrice);


            return Json(cars);
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

            carManager.AddNewCar(createNewCarRequest, file);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult DeleteCar(int id)
        {

            GetCarByIdResponse getCarByIdResponse = carManager.GetCarById(id);

            

            return View(getCarByIdResponse);
        }

        [HttpPost]
        public IActionResult DeleteCar(GetCarByIdResponse getCarByIdResponse)
        {

             

            carManager.DeleteCar(getCarByIdResponse);

            


            return RedirectToAction("Index");
        }

    }
}
