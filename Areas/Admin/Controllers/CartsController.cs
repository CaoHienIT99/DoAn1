using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DA1.Data;
using DA1.Models.Domain;
using Microsoft.AspNetCore.Authorization;

namespace DA1.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class CartsController : ControllerBase
    {
        private readonly DataContext _context;

        public CartsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToCart>>> GetProductToCart()
        {
            return await _context.ProductToCart.ToListAsync();
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToCart>> GetProductToCart(int id)
        {
            var productToCart = await _context.ProductToCart.FindAsync(id);

            if (productToCart == null)
            {
                return NotFound();
            }

            return productToCart;
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductToCart(int id, ProductToCart productToCart)
        {
            if (id != productToCart.CartID)
            {
                return BadRequest();
            }

            _context.Entry(productToCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductToCartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Carts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductToCart>> PostProductToCart(ProductToCart productToCart)
        {
            _context.ProductToCart.Add(productToCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductToCart", new { id = productToCart.CartID }, productToCart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductToCart>> DeleteProductToCart(int id)
        {
            var productToCart = await _context.ProductToCart.FindAsync(id);
            if (productToCart == null)
            {
                return NotFound();
            }

            _context.ProductToCart.Remove(productToCart);
            await _context.SaveChangesAsync();

            return productToCart;
        }

        private bool ProductToCartExists(int id)
        {
            return _context.ProductToCart.Any(e => e.CartID == id);
        }
    }
}
