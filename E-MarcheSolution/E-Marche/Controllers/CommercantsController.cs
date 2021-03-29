using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Marche.Models;
using E_Marche.Models.Request;

namespace E_Marche.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommercantsController : ControllerBase
    {
        private readonly Net5EcommerceDbContext _context;

        public CommercantsController(Net5EcommerceDbContext context)
        {
            _context = context;
        }

        // GET: api/Commercants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commercant>>> GetCommercants([FromQuery] String SearchingString,
                                       String orderby,
                                       [FromQuery] Paging paging)
        {
            var CommercantQuery = _context.Commercants.AsQueryable();
            CommercantQuery = CommercantQuery.Where(x => x.CommercantId != null);
            //var client = _context.Clients.Where(u=>u.ClientId!=null);
            CommercantQuery = CommercantQuery.Skip((paging.PageNumber - 1) * paging.RowCount).
           Take(paging.RowCount);
            return await CommercantQuery.ToListAsync();
        }
        // GET: api/Commercants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commercant>> GetCommercant(int id)
        {
            var commercant = await _context.Commercants.FindAsync(id);

            if (commercant == null)
            {
                return NotFound();
            }

            return commercant;
        }

        // PUT: api/Commercants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommercant(int id, Commercant commercant)
        {
            if (id != commercant.CommercantId)
            {
                return BadRequest();
            }

            _context.Entry(commercant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommercantExists(id))
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

        // POST: api/Commercants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Commercant>> PostCommercant(Commercant commercant)
        {
            _context.Commercants.Add(commercant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommercant", new { id = commercant.CommercantId }, commercant);
        }

        // DELETE: api/Commercants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Commercant>> DeleteCommercant(int id)
        {
            var commercant = await _context.Commercants.FindAsync(id);
            if (commercant == null)
            {
                return NotFound();
            }

            _context.Commercants.Remove(commercant);
            await _context.SaveChangesAsync();

            return commercant;
        }

        private bool CommercantExists(int id)
        {
            return _context.Commercants.Any(e => e.CommercantId == id);
        }

        //login méthode
        // POST: api/Clients
        [HttpPost("LoginCommercant")]
        public async Task<ActionResult<Commercant>> LoginCommercant(Commercant commercant)
        {
            var user = await _context.Commercants.Where(u => u.LoginUser == commercant.LoginUser
                                                && u.MdpUser == commercant.MdpUser).FirstOrDefaultAsync();
            user.MdpUser = null;
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
    }
}
