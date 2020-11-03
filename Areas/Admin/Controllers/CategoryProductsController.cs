using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DA1.Data;
using DA1.Models.Domain;
using Microsoft.AspNetCore.Authorization;

namespace DA1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CategoryProductsController : Controller
    {
        private readonly DataContext _context;

        public CategoryProductsController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/CategoryProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Admin/CategoryProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryProduct = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (categoryProduct == null)
            {
                return NotFound();
            }

            return View(categoryProduct);
        }

        // GET: Admin/CategoryProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoryProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryID,CategoryName")] CategoryProduct categoryProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryProduct);
        }

        // GET: Admin/CategoryProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryProduct = await _context.Categories.FindAsync(id);
            if (categoryProduct == null)
            {
                return NotFound();
            }
            return View(categoryProduct);
        }

        // POST: Admin/CategoryProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryID,CategoryName")] CategoryProduct categoryProduct)
        {
            if (id != categoryProduct.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryProductExists(categoryProduct.CategoryID))
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
            return View(categoryProduct);
        }

        // GET: Admin/CategoryProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryProduct = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (categoryProduct == null)
            {
                return NotFound();
            }

            return View(categoryProduct);
        }

        // POST: Admin/CategoryProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryProduct = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(categoryProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryProductExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryID == id);
        }
    }
}
