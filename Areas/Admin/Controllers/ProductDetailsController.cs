using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DA1.Data;
using DA1.Models;
using Microsoft.AspNetCore.Authorization;

namespace DA1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductDetailsController : Controller
    {
        private readonly DataContext _context;

        public ProductDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/ProductDetails
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.ProductDetails.Include(p => p.Product).Include(p => p.Supplier);
            return View(await dataContext.ToListAsync());
        }

        // GET: Admin/ProductDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDetail = await _context.ProductDetails
                .Include(p => p.Product)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductIdDetail == id);
            if (productDetail == null)
            {
                return NotFound();
            }

            return View(productDetail);
        }

        // GET: Admin/ProductDetails/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID");
            return View();
        }

        // POST: Admin/ProductDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductIdDetail,Description,Displacement,Maxpower,Topspeed,TAcceleration,SupplierID,Invented,ProductId")] ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", productDetail.ProductId);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", productDetail.SupplierID);
            return View(productDetail);
        }

        // GET: Admin/ProductDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDetail = await _context.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", productDetail.ProductId);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", productDetail.SupplierID);
            return View(productDetail);
        }

        // POST: Admin/ProductDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductIdDetail,Description,Displacement,Maxpower,Topspeed,TAcceleration,SupplierID,Invented,ProductId")] ProductDetail productDetail)
        {
            if (id != productDetail.ProductIdDetail)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductDetailExists(productDetail.ProductIdDetail))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", productDetail.ProductId);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", productDetail.SupplierID);
            return View(productDetail);
        }

        // GET: Admin/ProductDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDetail = await _context.ProductDetails
                .Include(p => p.Product)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductIdDetail == id);
            if (productDetail == null)
            {
                return NotFound();
            }
            return View(productDetail);
        }

        // POST: Admin/ProductDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDetail = await _context.ProductDetails.FindAsync(id);
            _context.ProductDetails.Remove(productDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductDetailExists(int id)
        {
            return _context.ProductDetails.Any(e => e.ProductIdDetail == id);
        }
    }
}
