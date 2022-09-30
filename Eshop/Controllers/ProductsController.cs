using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eshop.Data;
using Eshop.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity;

namespace Eshop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly EshopContext _context;
        //RoleManager<IdentityRole> roleManager;

        public ProductsController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            //RoleManager<IdentityRole> roleManager,
            EshopContext context)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            //this.roleManager=roleManager; //добавление роли 
            this._context = context;

        }

        // GET: Products
        public async Task<IActionResult> Index()
        {


            string userName = User.Identity?.Name;

            string userid = _context.Users.Single(a => a.UserName == userName).Id;

            int backetId = _context.Baskets.Single(a => a.UserID == userid).Id;

            ViewData["CountOfProducts"]= _context.BasketProduct.Where(a => backetId == a.BasketId).Count();
            //foreach (var item in Model)
            //{
            //    if (item.BasketID != 0)
            //    {
            //        count++;
            //    }
            //}

            //ViewData["CountOfProducts"] = _context.Products.Where(basc => basc.BasketID != 0)
            //	.Count()
            //	.ToString();



            return View(await _context.Products.ToListAsync());
        }

        [HttpPost]
        public async Task<JsonResult> AddProductToSession(string productId, string backetId)
        {

            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Eshop3.Data;Trusted_Connection=True;MultipleActiveResultSets=true";
            //BasketProduct basketProduct = new BasketProduct { BasketId = Int16.Parse(backetId), ProductId = Int16.Parse(productId) };

            //_context.Set<BasketProduct>().Add(basketProduct);

            //await _context.SaveChangesAsync();


            //         Product product = new Product { Id = Int16.Parse(productId) };
            //         _context.Products.Add(product);
            //         _context.Products.Attach(product);

            //         Basket basket = new Basket { Id = Int16.Parse(backetId) };

            //_context.Baskets.Add(basket);
            //_context.Baskets.Attach(basket);

            //product.Baskets = new List<BasketProduct>();
            //product.Baskets.Add(basket);
            //_context.BasketProduct.($"INSERT INTO BasketProduct (BasketId, ProductId) VALUES({Int16.Parse(backetId)}, {Int16.Parse(productId)} ); ");


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = $"INSERT INTO BasketProduct (BasketId, ProductId) VALUES({Int16.Parse(backetId)}, {Int16.Parse(productId)} ); ";


                    //cmd.Parameters.AddWithValue("@name", name);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            string userName = User.Identity?.Name;

            string userid = _context.Users.Single(a => a.UserName == userName).Id;

            int thisbasket = _context.Baskets.Single(a => a.UserID == userid).Id;

            ViewData["CountOfProducts"] = _context.BasketProduct.Where(a => thisbasket == a.BasketId).Count();
            return Json("Success");

        }






        //// GET: Products/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //	if (id == null || _context.Product == null)
        //	{
        //		return NotFound();
        //	}

        //	var product = await _context.Product
        //		.FirstOrDefaultAsync(m => m.ProductID == id);
        //	if (product == null)
        //	{
        //		return NotFound();
        //	}

        //	return View(product);
        //}


        //// GET: Products/Create
        //public async Task<IActionResult> AddToBasket(int? id)
        //{
        //	if (id == null || _context.Product == null)
        //	{
        //		return NotFound();
        //	}

        //	var product = await _context.Product.FindAsync(id);
        //	if (product == null)
        //	{
        //		return NotFound();
        //	}
        //	return View(product);
        //}

        //// POST: Products/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult AddToBasket(int id/*, [Bind("BasketID")] Product product*/)
        //{
        //	if (_context.Product == null)
        //	{
        //		return Problem("Entity set 'EshopContext.Product'  is null.");
        //	}


        //	var product = _context.Product.Find(id);

        //	product.BasketID = 1;
        //	if (product != null)
        //	{
        //		_context.Product.Update(product);
        //	}

        //	_context.SaveChanges();
        //	return RedirectToAction(nameof(Index));
        //}

        //// GET: Products/Create
        //public IActionResult Create()
        //{
        //	return View();
        //}

        //// POST: Products/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ProductID,Name,Description,Price,Type")] Product product)
        //{
        //	if (ModelState.IsValid)
        //	{
        //		_context.Add(product);
        //		await _context.SaveChangesAsync();
        //		return RedirectToAction(nameof(Index));
        //	}
        //	return View(product);
        //}

        //// GET: Products/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //	if (id == null || _context.Product == null)
        //	{
        //		return NotFound();
        //	}

        //	var product = await _context.Product.FindAsync(id);
        //	if (product == null)
        //	{
        //		return NotFound();
        //	}
        //	return View(product);
        //}

        //// POST: Products/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ProductID,Name,Description,Price,Type")] Product product)
        //{
        //	if (id != product.ProductID)
        //	{
        //		return NotFound();
        //	}

        //	if (ModelState.IsValid)
        //	{
        //		try
        //		{
        //			_context.Update(product);
        //			await _context.SaveChangesAsync();
        //		}
        //		catch (DbUpdateConcurrencyException)
        //		{
        //			if (!ProductExists(product.ProductID))
        //			{
        //				return NotFound();
        //			}
        //			else
        //			{
        //				throw;
        //			}
        //		}
        //		return RedirectToAction(nameof(Index));
        //	}
        //	return View(product);
        //}

        //// GET: Products/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //	if (id == null || _context.Product == null)
        //	{
        //		return NotFound();
        //	}

        //	var product = await _context.Product
        //		.FirstOrDefaultAsync(m => m.ProductID == id);
        //	if (product == null)
        //	{
        //		return NotFound();
        //	}

        //	return View(product);
        //}

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //	if (_context.Product == null)
        //	{
        //		return Problem("Entity set 'EshopContext.Product'  is null.");
        //	}
        //	var product = await _context.Product.FindAsync(id);
        //	if (product != null)
        //	{
        //		_context.Product.Remove(product);
        //	}

        //	await _context.SaveChangesAsync();
        //	return RedirectToAction(nameof(Index));
        //}

        //private bool ProductExists(int id)
        //{
        //	return _context.Product.Any(e => e.ProductID == id);
        //}
    }
}
