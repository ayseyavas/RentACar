using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar.DTOs.Response;
using RentACar.Models.Business.Abstract;
using RentACar.Utilities.Filters;

namespace RentACar.Controllers.User
{

    public class UserCarController : Controller
    {
        private ICarService<Car> carManager;
        public UserCarController(ICarService<Car> carManager)
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
              .DistinctBy(x => x.brand.id)
             .Select(x => new SelectListItem
             {
                 Text = x.brand.name,
                 Value = x.brand.id.ToString()

             });

            ViewBag.brandList = brandList;

            return View(cars);
        }

        [HttpGet]
        public IActionResult Filter(CarFilerAjaxData carFilerAjaxData)
        {
            int? brandId = carFilerAjaxData.brandId;
            int? modelId = carFilerAjaxData.modelId;

            int? minPrice = carFilerAjaxData.minPrice;
            int? maxPrice = carFilerAjaxData.maxPrice;

            var cars = carManager.GetCarsByFilters(brandId, modelId, minPrice, maxPrice);

            return Json(cars);
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
    }
}
