using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.DTOs;
using RentACar.DTOs.Request;
using RentACar.DTOs.Response;
using RentACar.Models.Business.Abstract;
using RentACar.Models.Business.Concreate;
using RentACar.Models.Entities.Concreate;
using RentACar.Utilities;

namespace RentACar.Controllers
{
    //[Authorize(Roles =UserRoles.Role_Admin)]
    public class BrandController : Controller
    {
        private IBrandService<Brand> brandManager;

        public BrandController(IBrandService<Brand> brandManager)
        {
            this.brandManager = brandManager;
        }
        public IActionResult Index()
        {



            return View(brandManager.GetAll());
        }


        public IActionResult AddNewBrand()
        {

            return View();
        }

        public IActionResult DeleteBrand(int id)
        {

          GetBrandByIdResponse getBrandByIdResponse=  brandManager.GetBrandById(id);

            return View(getBrandByIdResponse);
        }

        [HttpPost]
        public IActionResult DeleteBrand(GetBrandByIdResponse getBrandByIdResponse)
        {
            if (ModelState.IsValid) 
            {
                brandManager.DeleteBrand(getBrandByIdResponse);
            }
            else 
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult AddNewBrand(CreateNewBrandRequest createNewBrandRequest, IFormFile file)
        {
            if (ModelState.IsValid)
            {
               



                    brandManager.AddNewBrand(createNewBrandRequest, file);

                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult UpdateBrand(int id)
        {
            if (id == 0 )
            {
                return NotFound();
            }
            else
            {
                GetBrandByIdResponse getBrandByIdResponse = brandManager.GetBrandById(id);



                return View(getBrandByIdResponse);

            }
        }

        [HttpPost]
        public IActionResult UpdateBrand(UpdateBrandRequest updateBrandRequest, IFormFile file)
        {
            if (ModelState.IsValid)
            {

                brandManager.UpdateBrand(updateBrandRequest,file);



            }
            return RedirectToAction("Index","Brand");
        }
    }
}
