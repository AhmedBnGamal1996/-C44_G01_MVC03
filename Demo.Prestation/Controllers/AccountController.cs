using Demo.DataAccess.Models.IdentityModule;
using Demo.Prestation.viewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Prestation.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager) : Controller
    {

        // Register 

        [HttpGet]

        public IActionResult Register() => View();


        [HttpPost]

        public IActionResult Register(RegisterViewModel registerViewModel )
        {
            if( !ModelState.IsValid ) return View(registerViewModel);

            var user = new ApplicationUser()
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Username,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName
            };
            
            var result = _userManager.CreateAsync(user , registerViewModel.Password).Result;

            if (result.Succeeded) { return RedirectToAction("Login"); }
            else 
            {

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description); 
                }


                return View(result);
            }



        }

        // Sign In 

       

        [HttpPost]
        public IActionResult SignUp()
        {
            return View("~/Views/Home/Index.cshtml");

        }
        // Sign Out











    }




}
