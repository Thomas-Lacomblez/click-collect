using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Marche.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using E_Marche.Models.Request;

namespace E_Marche.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly Net5EcommerceDbContext _context;

        public ClientsController(Net5EcommerceDbContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients([FromQuery] String SearchingString,
                                            String orderby,
                                            [FromQuery] Paging paging)
        {
            var ClientQuery = _context.Clients.AsQueryable();
            ClientQuery = ClientQuery.Where(x => x.ClientId != null);
            //var client = _context.Clients.Where(u=>u.ClientId!=null);
            ClientQuery = ClientQuery.Skip((paging.PageNumber - 1) * paging.RowCount).
           Take(paging.RowCount);
            return await ClientQuery.ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.ClientId)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetClient", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return client;
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }

        //login méthode
        // POST: api/Clients
        [HttpPost("LoginClient")]
        public async Task<ActionResult<Client>> LoginCient([FromBody]Client client)
        {
            var user = await _context.Clients.Where(u => u.LoginUser == client.LoginUser
                                              && u.MdpUser == client.MdpUser).FirstOrDefaultAsync();
            //user.MdpUser = null;
            if (user == null)
            {
                //user.LoginErrorMessage = "Nom d'utilisateur ou mot de passe incorrecte";
                return NotFound();
            }
            return user;
        }
    }
}
