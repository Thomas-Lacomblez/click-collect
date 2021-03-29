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
    public class SmsController : ControllerBase
    {
        private readonly Net5EcommerceDbContext _context;

        public SmsController(Net5EcommerceDbContext context)
        {
            _context = context;
        }

        // GET: api/Sms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sms>>> GetSms()
        {
            return await _context.Sms.ToListAsync();
        }

        // GET: api/Sms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sms>> GetSms(int id)
        {
            var sms = await _context.Sms.FindAsync(id);

            if (sms == null)
            {
                return NotFound();
            }

            return sms;
        }

        // PUT: api/Sms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSms(int id, Sms sms)
        {
            if (id != sms.Smsid)
            {
                return BadRequest();
            }

            _context.Entry(sms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmsExists(id))
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

        // POST: api/Sms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sms>> PostSms(Sms sms)
        {
            _context.Sms.Add(sms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSms", new { id = sms.Smsid }, sms);
        }

        // DELETE: api/Sms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sms>> DeleteSms(int id)
        {
            var sms = await _context.Sms.FindAsync(id);
            if (sms == null)
            {
                return NotFound();
            }

            _context.Sms.Remove(sms);
            await _context.SaveChangesAsync();

            return sms;
        }

        private bool SmsExists(int id)
        {
            return _context.Sms.Any(e => e.Smsid == id);
        }
    }
}
