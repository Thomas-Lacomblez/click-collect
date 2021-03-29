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
    public class PaymmentsController : ControllerBase
    {
        private readonly Net5EcommerceDbContext _context;

        public PaymmentsController(Net5EcommerceDbContext context)
        {
            _context = context;
        }

        // GET: api/Paymments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paymment>>> GetPaymments()
        {
            return await _context.Paymments.ToListAsync();
        }

        // GET: api/Paymments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paymment>> GetPaymment(int id)
        {
            var paymment = await _context.Paymments.FindAsync(id);

            if (paymment == null)
            {
                return NotFound();
            }

            return paymment;
        }

        // PUT: api/Paymments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymment(int id, Paymment paymment)
        {
            if (id != paymment.PaymmentId)
            {
                return BadRequest();
            }

            _context.Entry(paymment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymmentExists(id))
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

        // POST: api/Paymments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Paymment>> PostPaymment(Paymment paymment)
        {
            _context.Paymments.Add(paymment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymment", new { id = paymment.PaymmentId }, paymment);
        }

        // DELETE: api/Paymments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paymment>> DeletePaymment(int id)
        {
            var paymment = await _context.Paymments.FindAsync(id);
            if (paymment == null)
            {
                return NotFound();
            }

            _context.Paymments.Remove(paymment);
            await _context.SaveChangesAsync();

            return paymment;
        }

        private bool PaymmentExists(int id)
        {
            return _context.Paymments.Any(e => e.PaymmentId == id);
        }
    }
}
