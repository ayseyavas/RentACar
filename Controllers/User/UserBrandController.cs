using Microsoft.AspNetCore.Mvc;
using RentACar.DTOs.Response;
using RentACar.Models.Business.Abstract;
using RentACar.Models.Entities.Concreate;

namespace RentACar.Controllers.User
{


    //user authantike olacak
    public class UserBrandController : Controller
    {

        private IBrandService<Brand> brandManager;

        public UserBrandController(IBrandService<Brand> brandManager)
        {
            this.brandManager = brandManager;
        }

        public IActionResult Index()
        {

          IEnumerable<GetAllBrandsResponse> brands=  brandManager.GetAll();
            return View(brands);
        }
    }
}
