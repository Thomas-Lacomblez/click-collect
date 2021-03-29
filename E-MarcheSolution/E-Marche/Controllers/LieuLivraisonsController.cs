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
    public class LieuLivraisonsController : ControllerBase
    {
        private readonly Net5EcommerceDbContext _context;

        public LieuLivraisonsController(Net5EcommerceDbContext context)
        {
            _context = context;
        }

        // GET: api/LieuLivraisons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LieuLivraison>>> GetLieuLivraisons()
        {
            return await _context.LieuLivraisons.ToListAsync();
        }

        // GET: api/LieuLivraisons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LieuLivraison>> GetLieuLivraison(int id)
        {
            var lieuLivraison = await _context.LieuLivraisons.FindAsync(id);

            if (lieuLivraison == null)
            {
                return NotFound();
            }

            return lieuLivraison;
        }

        // PUT: api/LieuLivraisons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLieuLivraison(int id, LieuLivraison lieuLivraison)
        {
            if (id != lieuLivraison.LieuLivraisonId)
            {
                return BadRequest();
            }

            _context.Entry(lieuLivraison).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LieuLivraisonExists(id))
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

        // POST: api/LieuLivraisons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LieuLivraison>> PostLieuLivraison(LieuLivraison lieuLivraison)
        {
            _context.LieuLivraisons.Add(lieuLivraison);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLieuLivraison", new { id = lieuLivraison.LieuLivraisonId }, lieuLivraison);
        }

        // DELETE: api/LieuLivraisons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LieuLivraison>> DeleteLieuLivraison(int id)
        {
            var lieuLivraison = await _context.LieuLivraisons.FindAsync(id);
            if (lieuLivraison == null)
            {
                return NotFound();
            }

            _context.LieuLivraisons.Remove(lieuLivraison);
            await _context.SaveChangesAsync();

            return lieuLivraison;
        }

        private bool LieuLivraisonExists(int id)
        {
            return _context.LieuLivraisons.Any(e => e.LieuLivraisonId == id);
        }
    }
}
