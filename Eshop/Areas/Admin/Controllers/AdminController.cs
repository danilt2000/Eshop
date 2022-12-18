using Eshop.Data;
using Eshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Eshop.Areas.Admin.Controllers
{

	public class AdminController : Controller
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly SignInManager<IdentityUser> signInManager;
		private readonly EshopContext _context;
		private readonly IWebHostEnvironment _hostEnvironment;
		//RoleManager<IdentityRole> roleManager;

		public AdminController(UserManager<IdentityUser> userManager,
	    SignInManager<IdentityUser> signInManager,
	    //RoleManager<IdentityRole> roleManager,
	    EshopContext context, IWebHostEnvironment hostEnvironment)
		{

			this.userManager = userManager;
			this.signInManager = signInManager;
			//this.roleManager=roleManager; //добавление роли 
			this._context = context;
			this._hostEnvironment = hostEnvironment;

		}

		// GET: AdminController
		[Authorize(Roles = "Admin")]
		public ViewResult Index()
		{
			return View("~/Areas/Admin/Views/Admin/Index.cshtml", _context.Products.ToList());
		}

		// GET: Products/Edit/5
		public async Task<IActionResult> EditProduct(int? id)
		{
			if (id == null || _context.Products == null)
			{
				return NotFound();
			}

			var product = await _context.Products.FindAsync(id);
			if (product == null)
			{
				return NotFound();
			}
			return View("~/Areas/Admin/Views/Admin/EditProduct.cshtml", product);
		}

		// POST: Products/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditProduct(int id, [Bind("Id,Name,Description,Price,Type,ImageTitle")] Product product)
		{
			if (id != product.Id)
			{
				return NotFound();
			}

			//if (ModelState.IsValid)
			//{
			try
			{
				_context.Update(product);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				if (!ProductExists(product.Id))
				{
					//return NotFound();
					return View("~/Areas/Admin/Views/Admin/EditProduct.cshtml", product);

				}
				else
				{
					//throw;
					return View("~/Areas/Admin/Views/Admin/EditProduct.cshtml", product);
				}
			}
			return RedirectToAction(nameof(Index));
			//}

		}  // GET: Products/Edit/5
		public async Task<IActionResult> EditUser(string? id)
		{
			if (id == null || _context.Users == null)
			{
				return NotFound();
			}

			var user = await _context.Users.FindAsync(id);
			if (user == null)
			{
				return NotFound();
			}
			return View("~/Areas/Admin/Views/Admin/EditUser.cshtml", user);
		}

		// POST: Products/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditUser(string id, [Bind("UserName,Email,PhoneNumber")] IdentityUser user)
		{
			string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Eshop3.Data;Trusted_Connection=True;MultipleActiveResultSets=true";
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.Connection = con;

					cmd.CommandText = $"UPDATE AspNetUsers SET UserName = '{user.UserName}' , Email = '{user.Email}' , PhoneNumber='{user.PhoneNumber}'  WHERE  Id = '{id}' ";

					con.Open();

					cmd.ExecuteNonQuery();

					con.Close();
				}
			}

			return RedirectToAction(nameof(Index));

		}

		public IActionResult CreateProduct()
		{
			return View("~/Areas/Admin/Views/Admin/CreateProduct.cshtml");
		}

		// POST: Client/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateProduct([Bind("Id,Name,Description,Price,Type,ImageFile,ImageTitle")] Product product)
		{

			if (ModelState.IsValid)
			{
				string wwwRootPath = _hostEnvironment.WebRootPath;

				string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
				string extension = Path.GetExtension(product.ImageFile.FileName);
				//product.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
				string path = Path.Combine(wwwRootPath + "/assets/images/", fileName + extension);
				product.ImageTitle = String.Format("{0}{1}", fileName, extension);
				using (var fileStream = new FileStream(path, FileMode.Create))
				{
					await product.ImageFile.CopyToAsync(fileStream);
				}

				_context.Add(product);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}



			return View("~/Areas/Admin/Views/Admin/CreateProduct.cshtml", product);
		}
		// GET: Products/Delete/5
		public async Task<IActionResult> DeleteProduct(int? id)
		{
			if (id == null || _context.Products == null)
			{
				return NotFound();
			}

			var product = await _context.Products
			    .FirstOrDefaultAsync(m => m.Id == id);
			if (product == null)
			{
				return NotFound();
			}

			return View("~/Areas/Admin/Views/Admin/DeleteProduct.cshtml", product);

		}

		// POST: Products/Delete/5
		[HttpPost, ActionName("DeleteProductConfirmed")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteProductConfirmed(int id)
		{
			if (_context.Products == null)
			{
				return Problem("Entity set 'EshopContext.Product'  is null.");
			}
			var product = await _context.Products.FindAsync(id);
			if (product != null)
			{
				_context.Products.Remove(product);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		private bool ProductExists(int id)
		{
			return _context.Products.Any(e => e.Id == id);
		}

	}
}
