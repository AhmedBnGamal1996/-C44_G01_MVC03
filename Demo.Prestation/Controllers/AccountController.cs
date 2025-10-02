using Demo.DataAccess.Models.IdentityModule;
using Demo.Prestation.viewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Prestation.Controllers
{

    
    public class AccountController(UserManager<ApplicationUser> _userManager , SignInManager<ApplicationUser> _signInManager) : Controller
    {


        #region Register
          

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


        #endregion













        #region  Login 

        [HttpGet]
            public IActionResult Login() => View();



        [HttpPost]

        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);


            var user = _userManager.FindByEmailAsync(loginViewModel.Email).Result;

            if (user != null)

            {

                var flag = _userManager.CheckPasswordAsync(user, loginViewModel.Password).Result;

                if (flag)
                {
                    var result = _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, false).Result;


                    if (result.IsNotAllowed)
                    {
                        ModelState.AddModelError(string.Empty, "You are not allowed to login");
                    }

                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "You are locked out");
                    }


                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }


                }
                
                ModelState.AddModelError(string.Empty, "Invalid Login...");



            }

            return View(loginViewModel);


        }



        #endregion







        #region  SignOuts

        public new IActionResult SignOut()
        {
            _signInManager.SignOutAsync().GetAwaiter().GetResult();
            return RedirectToAction("Login");
        }



        #endregion











    }




}
