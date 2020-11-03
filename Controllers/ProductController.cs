using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DA1.Data;
using DA1.Models;
using DA1.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DA1.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        IMapper mapper;
        public ProductController(DataContext context, IMapper mapper)
        {

            _context = context;
            this.mapper = mapper;
        }

        private void CategoriesList()
        {
            var data = _context.Categories.ToList();
            List<CategoryProduct> list = new List<CategoryProduct>();
            foreach (var item in data)
            {
                list.Add(new CategoryProduct
                {
                    CategoryID = item.CategoryID,
                    CategoryName = item.CategoryName
                });
            }
            ViewBag.Categories2 = list;
        }
        public IActionResult Product(int? begin)
        {

            CategoriesList();
            int k = 0;
            if (begin != null)
            {
                k = begin.GetValueOrDefault() * 9;
            }
            List<Product> products = _context.Products.Skip(k).Take(9).ToList();
            ViewBag.count = _context.Products.Count() / 6;
            return View(products);
        }
        public async Task<IActionResult> ProductDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDetail = await _context.ProductDetails
                .Include(p => p.Product)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productDetail == null)
            {
                return NotFound();
            }

            return View(productDetail);
        }
        private bool ProductDetailExists(int id)
        {
            return _context.ProductDetails.Any(e => e.ProductIdDetail == id);
        }



        //Search
        public IActionResult Search( string search)
        {
            var item = _context.Products.Where(p => p.ProductName.Contains(search));
            CategoriesList();
            return View(item.ToList());
        }

        //Model
        public IActionResult Aventador()
        {
            CategoriesList();
            return View(_context.Products.Where(p => p.Category.CategoryName.Equals("Aventador")));
        }
        public IActionResult Huracán()
        {
            CategoriesList();
            return View(_context.Products.Where(p => p.Category.CategoryName.Equals("Huracan")));
        }
        public IActionResult Urus()
        {
            CategoriesList();
            return View(_context.Products.Where(p => p.Category.CategoryName.Equals("Urus")));
        }
        public IActionResult LimitedSeries()
        {
            CategoriesList();
            return View(_context.Products.Where(p => p.Category.CategoryName.Equals("Limited Series")));
        }
    }
}
