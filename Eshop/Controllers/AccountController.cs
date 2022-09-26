using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;



namespace Eshop.Controllers
{
	public class AccountController : Controller
	{
		private	readonly UserManager<IdentityUser> userManager;

		public AccountController(UserManager<IdentityUser> userManager,
			SignInManager)
		{
			this.userManager = userManager;
		}



		// GET: AccountController
		public ActionResult Index()
		{
			return View();
		}

	}
}
