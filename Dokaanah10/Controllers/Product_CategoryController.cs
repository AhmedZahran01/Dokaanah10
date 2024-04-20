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
    public class Product_CategoryController : Controller
    {
        //private readonly DokkanahContex10 _context;
        DokkanahContex10 _context = new DokkanahContex10();

        public Product_CategoryController( ) //DokkanahContex10 context)
        {
            //_context = context;
        }

        // GET: Product_Category
        public async Task<IActionResult> Index()
        {
            var dokkanahContex10 = _context.Product_Categories.Include(p => p.C).Include(p => p.P);
            return View(await dokkanahContex10.ToListAsync());
        }

        // GET: Product_Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Category = await _context.Product_Categories
                .Include(p => p.C)
                .Include(p => p.P)
                .FirstOrDefaultAsync(m => m.Pid == id);
            if (product_Category == null)
            {
                return NotFound();
            }

            return View(product_Category);
        }

        // GET: Product_Category/Create
        public IActionResult Create()
        {
            ViewData["Cid"] = new SelectList(_context.Categories, "Id", "Id");
            ViewData["Pid"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: Product_Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pid,Cid")] Product_Category product_Category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product_Category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cid"] = new SelectList(_context.Categories, "Id", "Id", product_Category.Cid);
            ViewData["Pid"] = new SelectList(_context.Products, "Id", "Id", product_Category.Pid);
            return View(product_Category);
        }

        // GET: Product_Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Category = await _context.Product_Categories.FindAsync(id);
            if (product_Category == null)
            {
                return NotFound();
            }
            ViewData["Cid"] = new SelectList(_context.Categories, "Id", "Id", product_Category.Cid);
            ViewData["Pid"] = new SelectList(_context.Products, "Id", "Id", product_Category.Pid);
            return View(product_Category);
        }

        // POST: Product_Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pid,Cid")] Product_Category product_Category)
        {
            if (id != product_Category.Pid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product_Category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Product_CategoryExists(product_Category.Pid))
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
            ViewData["Cid"] = new SelectList(_context.Categories, "Id", "Id", product_Category.Cid);
            ViewData["Pid"] = new SelectList(_context.Products, "Id", "Id", product_Category.Pid);
            return View(product_Category);
        }

        // GET: Product_Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Category = await _context.Product_Categories
                .Include(p => p.C)
                .Include(p => p.P)
                .FirstOrDefaultAsync(m => m.Pid == id);
            if (product_Category == null)
            {
                return NotFound();
            }

            return View(product_Category);
        }

        // POST: Product_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product_Category = await _context.Product_Categories.FindAsync(id);
            if (product_Category != null)
            {
                _context.Product_Categories.Remove(product_Category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product_CategoryExists(int id)
        {
            return _context.Product_Categories.Any(e => e.Pid == id);
        }
    }
}
