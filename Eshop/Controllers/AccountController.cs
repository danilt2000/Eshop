using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Eshop.Data;
using Eshop.Models;



namespace Eshop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly EshopContext _context;
        //RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            //RoleManager<IdentityRole> roleManager,
            EshopContext context)
        {
            
            this.userManager = userManager;
            this.signInManager = signInManager;
            //this.roleManager=roleManager; //добавление роли 
            this._context = context;
         
        }




        [HttpGet]
        public ActionResult Register()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User model, string Password)
        {

            if (ModelState.IsValid)
            {
                IdentityUser User = new IdentityUser { UserName = model.Name };
                var result = await userManager.CreateAsync(User, Password);

                if (result.Succeeded)
				{
					await signInManager.SignInAsync(User, isPersistent: true);// false без сохранения
					return RedirectToAction("Index", "Products");
				}
				//            foreach (var error Ein result.Errors)
				//{
				//                ModelState.AddModelError("", errorMessage.)

				//            }



			}
            return View(model);



        }

        [HttpGet]
        public ActionResult SignIn()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(string Name, string Password)
        {

            if (ModelState.IsValid)
            {
                //IdentityUser User = new IdentityUser { UserName = model.Name };
                 var result = await signInManager.PasswordSignInAsync(Name, Password, true,false);
				if (result.Succeeded)
				{
                return RedirectToAction("Index", "Products");

				}
                
                //            if (result.Succeeded)
                //{
                //	await signInManager.SignInAsync(User, isPersistent: true);// false без сохранения
                //	return RedirectToAction("Index", "Products");
                //}
                //            foreach (var error Ein result.Errors)
                //{
                //                ModelState.AddModelError("", errorMessage.)

                //            }



            }
            return View();



        }


    }
}
