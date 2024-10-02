using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RentACar.Controllers
{
    public class UserController : Controller
    {

        [Authorize] 
        public IActionResult Index()
        {

            return View();
        }
    }
}
