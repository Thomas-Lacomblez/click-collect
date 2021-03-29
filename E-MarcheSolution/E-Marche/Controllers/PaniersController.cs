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
    public class PaniersController : ControllerBase
    {
        private readonly Net5EcommerceDbContext _context;

        public PaniersController(Net5EcommerceDbContext context)
        {
            _context = context;
        }

        // GET: api/Paniers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Panier>>> GetPaniers()
        {
            return await _context.Paniers.ToListAsync();
        }
        public async Task<ActionResult<IEnumerable<Panier>>> GetCommercants([FromQuery] String SearchingString,
                                  String orderby,
                                  [FromQuery] Paging paging)
        {
            var PanierQuery = _context.Paniers.AsQueryable();
            PanierQuery = PanierQuery.Where(x => x.PanierId != null);
            //var client = _context.Clients.Where(u=>u.ClientId!=null);
            PanierQuery = PanierQuery.Skip((paging.PageNumber - 1) * paging.RowCount).
           Take(paging.RowCount);
            return await PanierQuery.ToListAsync();
        }
        // GET: api/Paniers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Panier>> GetPanier(int id)
        {
            var panier = await _context.Paniers.FindAsync(id);

            if (panier == null)
            {
                return NotFound();
            }

            return panier;
        }

        // PUT: api/Paniers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPanier(int id, Panier panier)
        {
            if (id != panier.PanierId)
            {
                return BadRequest();
            }

            _context.Entry(panier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PanierExists(id))
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

        // POST: api/Paniers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Panier>> PostPanier(Panier panier)
        {
            _context.Paniers.Add(panier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPanier", new { id = panier.PanierId }, panier);
        }

        // DELETE: api/Paniers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Panier>> DeletePanier(int id)
        {
            var panier = await _context.Paniers.FindAsync(id);
            if (panier == null)
            {
                return NotFound();
            }

            _context.Paniers.Remove(panier);
            await _context.SaveChangesAsync();

            return panier;
        }

        private bool PanierExists(int id)
        {
            return _context.Paniers.Any(e => e.PanierId == id);
        }

        //ajout début
        //[HttpGet("Countelement")]
        //public int Countelement()
        //{

        //    var paniers = _context.Paniers.Include(p => p.Article).Include(p => p.Commande).Count();
        //    return paniers;
        //}
        //[HttpGet("CounteSomme")]
        //public double? CounteSomme()
        //{

        //    var Total = _context.Paniers.AsEnumerable().Sum(x => x.PrixArticle);

        //    var paniers = _context.Paniers.GroupBy(c => new
        //    {
        //        c.PanierId,
        //        c.Cantite,
        //        c.PrixArticle
        //    })
        //                .Select(g => new
        //                {
        //                    g.Key.PanierId,
        //                    g.Key.Cantite,
        //                    g.Key.PrixArticle,
        //                    Available = g.Count()
        //                });
        //    var pan = paniers.ToList();
        //    double? p = 0;
        //    foreach (var panier in pan)
        //    {
        //        p += panier.prixArticle;
        //    }
        //    var result = (from item in pan select item);
        //    result = result.OrderBy(c => c.prixArticle);
        //    var r = result.Sum(x => x.prixArticle);
        //    return r;



        //}

        //ajout fin
    }
}
