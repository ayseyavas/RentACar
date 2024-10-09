using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar.DTOs.Request;
using RentACar.DTOs.Response;
using RentACar.Models.Business.Abstract;
using RentACar.Models.Entities.Concreate;

namespace RentACar.Controllers
{

    public class CarModelController : Controller
    {
        public ICarModelService<CarModel> carModelManager;
        //public IBrandService<Brand> _brandManager;

        public CarModelController(ICarModelService<CarModel> carModelManager, IBrandService<Brand> brandManager)
        {
            this.carModelManager = carModelManager;
            //_brandManager = brandManager;
        }
        public IActionResult Index()
        {

            IEnumerable<GetAllCarModelsResponse> getAllCarModelsResponses = carModelManager.GetAll();


            return View(getAllCarModelsResponses);
        }

        [HttpGet]
        public IActionResult AddNewCarModel()
        {

            IEnumerable<SelectListItem> brandList = carModelManager.getAllBrandsResponses()
                .Select(x => new SelectListItem
                {
                    Text = x.name,
                    Value = x.id.ToString()

                });

            ViewBag.BrandList = brandList;

            return View();
        }

        [HttpPost]
        public IActionResult AddNewCarModel(CreateNewCarModelRequest createNewCarModelRequest, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                carModelManager.AddNewCarModel(createNewCarModelRequest,file);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateCarModel(int id)
        {
            
            GetCarModelByIdResponse getCarModelByIdResponse=carModelManager.GetCarModelById(id);


            IEnumerable<SelectListItem> brandList = carModelManager.getAllBrandsResponses()
                .Select(x => new SelectListItem
                {
                    Text = x.name,
                    Value = x.id.ToString()

                });

            ViewBag.BrandList = brandList;



            return View(getCarModelByIdResponse);
            

        }
        [HttpPost]
        public IActionResult UpdateCarModel(UpdateCarModelRequest updateCarModelRequest, IFormFile? file) 
        {

            if (ModelState.IsValid) { 
            carModelManager.updateCarModel(updateCarModelRequest,file);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCarModel(int id) 
        {
            GetCarModelByIdResponse getCarModelBy= carModelManager.GetCarModelById(id);

            

            return View(getCarModelBy);
            
        }

        [HttpPost]
        public IActionResult DeleteCarModel(GetCarModelByIdResponse getCarModelByIdResponse) 
        {

            carModelManager.deleteCarModel(getCarModelByIdResponse);

            return RedirectToAction("Index");

        }
    }
}
