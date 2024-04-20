using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dokaanah10.Models;

namespace Dokaanah10.Controllers
{
    public class Cart_ProductController : Controller
    {
        //private readonly DokkanahContex10 _context;
        DokkanahContex10 _context = new DokkanahContex10();
        public Cart_ProductController()
        {
            //_context = context;
        }

        // GET: Cart_Product
        public async Task<IActionResult> Index()
        {
            var dokkanahContex10 = _context.Cart_Products.Include(c => c.Ca).Include(c => c.Pr);
            return View(await dokkanahContex10.ToListAsync());
        }

        // GET: Cart_Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart_Product = await _context.Cart_Products
                .Include(c => c.Ca)
                .Include(c => c.Pr)
                .FirstOrDefaultAsync(m => m.Prid == id);
            if (cart_Product == null)
            {
                return NotFound();
            }

            return View(cart_Product);
        }

        // GET: Cart_Product/Create
        public IActionResult Create()
        {
            ViewData["Caid"] = new SelectList(_context.Carts, "Id", "Id");
            ViewData["Prid"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: Cart_Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Caid,Prid")] Cart_Product cart_Product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart_Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Caid"] = new SelectList(_context.Carts, "Id", "Id", cart_Product.Caid);
            ViewData["Prid"] = new SelectList(_context.Products, "Id", "Id", cart_Product.Prid);
            return View(cart_Product);
        }

        // GET: Cart_Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart_Product = await _context.Cart_Products.FindAsync(id);
            if (cart_Product == null)
            {
                return NotFound();
            }
            ViewData["Caid"] = new SelectList(_context.Carts, "Id", "Id", cart_Product.Caid);
            ViewData["Prid"] = new SelectList(_context.Products, "Id", "Id", cart_Product.Prid);
            return View(cart_Product);
        }

        // POST: Cart_Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Caid,Prid")] Cart_Product cart_Product)
        {
            if (id != cart_Product.Prid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart_Product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cart_ProductExists(cart_Product.Prid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Caid"] = new SelectList(_context.Carts, "Id", "Id", cart_Product.Caid);
            ViewData["Prid"] = new SelectList(_context.Products, "Id", "Id", cart_Product.Prid);
            return View(cart_Product);
        }

        // GET: Cart_Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart_Product = await _context.Cart_Products
                .Include(c => c.Ca)
                .Include(c => c.Pr)
                .FirstOrDefaultAsync(m => m.Prid == id);
            if (cart_Product == null)
            {
                return NotFound();
            }

            return View(cart_Product);
        }

        // POST: Cart_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart_Product = await _context.Cart_Products.FindAsync(id);
            if (cart_Product != null)
            {
                _context.Cart_Products.Remove(cart_Product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cart_ProductExists(int id)
        {
            return _context.Cart_Products.Any(e => e.Prid == id);
        }
    }
}
