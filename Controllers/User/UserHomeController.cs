using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using System.Diagnostics;

namespace RentACar.Controllers.User
{
    public class UserHomeController : Controller
    {

        private readonly ILogger<UserHomeController> _logger;

        public UserHomeController(ILogger<UserHomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();

            }
            else
            {
                //login sayfasına yönlendirme yapıyor
                return Redirect("/Identity/Account/Login");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
