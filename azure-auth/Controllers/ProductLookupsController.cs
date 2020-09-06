using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using azureauth.Entities;

namespace azureauth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductLookupsController : ControllerBase
    {
        private readonly MgsmasterdbContext _context;

        public ProductLookupsController(MgsmasterdbContext context)
        {
            _context = context;
        }

        // GET: api/ProductLookups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductLookup>>> GetProductLookups()
        {
            return await _context.ProductLookups.ToListAsync();
        }

        // GET: api/ProductLookups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductLookup>> GetProductLookup(long id)
        {
            var productLookup = await _context.ProductLookups.FindAsync(id);

            if (productLookup == null)
            {
                return NotFound();
            }

            return productLookup;
        }

        // PUT: api/ProductLookups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductLookup(long id, ProductLookup productLookup)
        {
            if (id != productLookup.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(productLookup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductLookupExists(id))
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

        // POST: api/ProductLookups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductLookup>> PostProductLookup(ProductLookup productLookup)
        {
            _context.ProductLookups.Add(productLookup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductLookup", new { id = productLookup.ProductId }, productLookup);
        }

        // DELETE: api/ProductLookups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductLookup>> DeleteProductLookup(long id)
        {
            var productLookup = await _context.ProductLookups.FindAsync(id);
            if (productLookup == null)
            {
                return NotFound();
            }

            _context.ProductLookups.Remove(productLookup);
            await _context.SaveChangesAsync();

            return productLookup;
        }

        private bool ProductLookupExists(long id)
        {
            return _context.ProductLookups.Any(e => e.ProductId == id);
        }
    }
}
