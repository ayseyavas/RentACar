using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using RentACar.Models;
using RentACar.Models.KpsService;
using RentACar.Models.Repository.Concreate;

namespace RentACar.Areas.Identity.Pages.Account.Manage
{
    public class ConfirmIdentitiy : PageModel
    {

        UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<ConfirmIdentitiy> _logger;
        //private readonly IUserStore<AppUser> _userStore;


        public ConfirmIdentitiy(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<ConfirmIdentitiy> logger)
        {
            //_userStore = userStore;
            _signInManager = signInManager;
            _logger = logger;

            _userManager = userManager;

        }


        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }


        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string Name { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }


            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Text)]
            [Display(Name = "National ID")]
            public long? NationalId { get; set; } 

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Birth Year")]
            public int? BirthYear { get; set; }

            [Required]

            public bool isVerified {get; set; }


        }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            Input = new InputModel
            {
                Name = user.name,
                LastName = user.lastName,
                NationalId = user.nationalId,
                BirthYear = user.birthYear
            };

            return Page();
        }




        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            ServiceKpsPublic service = new ServiceKpsPublic();
            Response response=new Response();

            response._parametters.TCKimlikNo=Input.NationalId.Value;

            response._parametters.Ad=Input.Name;
            response._parametters.Soyad=Input.LastName;
            response._parametters.DogumYili=Input.BirthYear.Value;
            response._parametters.TCKimlikNo = Input.NationalId.Value;

            var result =service.OnGetService(response._parametters);

            user.isVerified = result.Result;
            Input.isVerified = result.Result;

            if(result == null) 
            {


                TempData["Success"] = "Servis Çalýþmadý";
            }
            else 
            {
                if(result.Result == true) 
                {
                    TempData["Success"] = "Tc Kimlik No Doðrulandý";





                    user.name = Input.Name;
                    user.lastName = Input.LastName;
                    user.nationalId = Input.NationalId.Value;
                    user.birthYear = Input.BirthYear.Value;



                    await _userManager.UpdateAsync(user);
                }
                else 
                {
                    TempData["Fail"] = "TcNo Eþleþmedi";


                }
            }




            //var user = await _userManager.GetUserAsync(User);



            
            //user.name = Input.Name;
            //user.lastName = Input.LastName;
            //user.nationalId = Input.NationalId;
            //user.birthYear = Input.BirthYear;

           

            //await _userManager.UpdateAsync(user);



            //var result = await _userManager.UpdateAsync(user);

            // Eðer güncelleme baþarýlý deðilse hata mesajlarýný iþle
            //if (!result.Succeeded)
            //{
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError(string.Empty, error.Description);
            //    }
            //    return Page();
            //}













            return Page();
        }



       
    }
}
