using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Marche.Models;

namespace E_Marche.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieCommercantsController : ControllerBase
    {
        private readonly Net5EcommerceDbContext _context;

        public CategorieCommercantsController(Net5EcommerceDbContext context)
        {
            _context = context;
        }

        // GET: api/CategorieCommercants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorieCommercant>>> GetCategorieCommercants()
        {
            return await _context.CategorieCommercants.ToListAsync();
        }

        // GET: api/CategorieCommercants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategorieCommercant>> GetCategorieCommercant(int id)
        {
            var categorieCommercant = await _context.CategorieCommercants.FindAsync(id);

            if (categorieCommercant == null)
            {
                return NotFound();
            }

            return categorieCommercant;
        }

        // PUT: api/CategorieCommercants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorieCommercant(int id, CategorieCommercant categorieCommercant)
        {
            if (id != categorieCommercant.CommercantId)
            {
                return BadRequest();
            }

            _context.Entry(categorieCommercant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieCommercantExists(id))
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

        // POST: api/CategorieCommercants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CategorieCommercant>> PostCategorieCommercant(CategorieCommercant categorieCommercant)
        {
            _context.CategorieCommercants.Add(categorieCommercant);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategorieCommercantExists(categorieCommercant.CommercantId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategorieCommercant", new { id = categorieCommercant.CommercantId }, categorieCommercant);
        }

        // DELETE: api/CategorieCommercants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategorieCommercant>> DeleteCategorieCommercant(int id)
        {
            var categorieCommercant = await _context.CategorieCommercants.FindAsync(id);
            if (categorieCommercant == null)
            {
                return NotFound();
            }

            _context.CategorieCommercants.Remove(categorieCommercant);
            await _context.SaveChangesAsync();

            return categorieCommercant;
        }

        private bool CategorieCommercantExists(int id)
        {
            return _context.CategorieCommercants.Any(e => e.CommercantId == id);
        }
    }
}
