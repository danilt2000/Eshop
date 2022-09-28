//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Eshop.Data;
//using Eshop.Models;

//namespace Eshop.Controllers
//{
//    public class ProductsController : Controller
//    {
//        private readonly EshopContext _context;

//        public ProductsController(EshopContext context)
//        {
//            _context = context;
//        }

//        // GET: Products
//        public async Task<IActionResult> Index()
//        {





//            //foreach (var item in Model)
//            //{
//            //    if (item.BasketID != 0)
//            //    {
//            //        count++;
//            //    }
//            //}

//            ViewData["CountOfProducts"] = _context.Product.Where(basc=> basc.BasketID!=0)
//                .Count()
//                .ToString();



//            return View(await _context.Product.ToListAsync());
//        }

//        // GET: Products/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Product == null)
//            {
//                return NotFound();
//            }

//            var product = await _context.Product
//                .FirstOrDefaultAsync(m => m.ProductID == id);
//            if (product == null)
//            {
//                return NotFound();
//            }

//            return View(product);
//        }


//        // GET: Products/Create
//        public async Task<IActionResult> AddToBasket(int? id)
//        {
//            if (id == null || _context.Product == null)
//            {
//                return NotFound();
//            }

//            var product = await _context.Product.FindAsync(id);
//            if (product == null)
//            {
//                return NotFound();
//            }
//            return View(product);
//        }

//        // POST: Products/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult AddToBasket(int id/*, [Bind("BasketID")] Product product*/)
//        {
//            if (_context.Product == null)
//            {
//                return Problem("Entity set 'EshopContext.Product'  is null.");
//            }


//            var product = _context.Product.Find(id);

//            product.BasketID = 1;
//            if (product != null)
//            {
//                _context.Product.Update(product);
//            }

//            _context.SaveChanges();
//            return RedirectToAction(nameof(Index));
//        }

//        // GET: Products/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Products/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ProductID,Name,Description,Price,Type")] Product product)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(product);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(product);
//        }

//        // GET: Products/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Product == null)
//            {
//                return NotFound();
//            }

//            var product = await _context.Product.FindAsync(id);
//            if (product == null)
//            {
//                return NotFound();
//            }
//            return View(product);
//        }

//        // POST: Products/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Name,Description,Price,Type")] Product product)
//        {
//            if (id != product.ProductID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(product);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ProductExists(product.ProductID))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(product);
//        }

//        // GET: Products/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Product == null)
//            {
//                return NotFound();
//            }

//            var product = await _context.Product
//                .FirstOrDefaultAsync(m => m.ProductID == id);
//            if (product == null)
//            {
//                return NotFound();
//            }

//            return View(product);
//        }

//        // POST: Products/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Product == null)
//            {
//                return Problem("Entity set 'EshopContext.Product'  is null.");
//            }
//            var product = await _context.Product.FindAsync(id);
//            if (product != null)
//            {
//                _context.Product.Remove(product);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ProductExists(int id)
//        {
//            return _context.Product.Any(e => e.ProductID == id);
//        }
//    }
//}
