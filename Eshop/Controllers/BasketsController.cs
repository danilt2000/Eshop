using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eshop.Data;
using Eshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Eshop.Controllers
{
    public class BasketsController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly EshopContext _context;
        //RoleManager<IdentityRole> roleManager;
        private readonly ILogger<HomeController> _logger;

        public BasketsController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            //RoleManager<IdentityRole> roleManager,
            EshopContext context, ILogger<HomeController> logger)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            //this.roleManager=roleManager; //добавление роли 
            this._context = context;
            this._logger = logger;
        }

        // GET: Baskets
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("This is the Basket page");
            _logger.LogInformation($"Count of all Products{_context.Products.Count()}");



            return View(await _context.Products.ToListAsync());
        }

        //// GET: Baskets/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Basket == null)
        //    {
        //        return NotFound();
        //    }

        //    var basket = await _context.Basket
        //        .FirstOrDefaultAsync(m => m.BasketID == id);
        //    if (basket == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(basket);
        //}

        //// GET: Baskets/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Baskets/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////[Authorize]
        //public async Task<IActionResult> Create([Bind("BasketID,Name")] Basket basket)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(basket);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(basket);
        //}

        //// GET: Baskets/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Basket == null)
        //    {
        //        return NotFound();
        //    }

        //    var basket = await _context.Basket.FindAsync(id);
        //    if (basket == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(basket);
        //}

        //// POST: Baskets/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("BasketID,Name")] Basket basket)
        //{
        //    if (id != basket.BasketID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(basket);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BasketExists(basket.BasketID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(basket);
        //}

        //// GET: Baskets/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Basket == null)
        //    {
        //        return NotFound();
        //    }

        //    var basket = await _context.Basket
        //        .FirstOrDefaultAsync(m => m.BasketID == id);
        //    if (basket == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(basket);
        //}

        //// POST: Baskets/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Basket == null)
        //    {
        //        return Problem("Entity set 'EshopContext.Basket'  is null.");
        //    }
        //    var basket = await _context.Basket.FindAsync(id);
        //    if (basket != null)
        //    {
        //        _context.Basket.Remove(basket);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BasketExists(int id)
        //{
        //    return _context.Basket.Any(e => e.BasketID == id);
        //}
    }
}
