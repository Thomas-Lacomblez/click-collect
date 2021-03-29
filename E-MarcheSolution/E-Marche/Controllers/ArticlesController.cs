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
    public class ArticlesController : ControllerBase
    {
        private readonly Net5EcommerceDbContext _context;

        public ArticlesController(Net5EcommerceDbContext context)
        {
            _context = context;
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles([FromQuery] String SearchingString,
                                        String orderby,
                                        [FromQuery] Paging paging)
        {
            var ArticleQuery = _context.Articles.AsQueryable();
            ArticleQuery = ArticleQuery.Where(x => x.ArticleId != null);
            //var client = _context.Clients.Where(u=>u.ClientId!=null);
            ArticleQuery = ArticleQuery.Skip((paging.PageNumber - 1) * paging.RowCount).
           Take(paging.RowCount);
            return await ArticleQuery.ToListAsync();
        }
        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return article;
        }

        [HttpGet("categorieId/{cid}")]
        public async Task<ActionResult<Article>> GetArticleByCategorieId(int cid)
        {
            //Categorie cat = new Categorie();
            this.GetArticles("","",null);
            var article = await _context.Articles.Where(u => u.CategorieId == cid
                                          ).FirstOrDefaultAsync();
            //var article = await _context.Articles.Where(u => u.CategorieId == cid
            //                             ).ToListAsync();
            //var article = await _context.Articles.FindAsync(artc.CategorieId);

            if (article == null)
            {
                return NotFound();
            }

            return article;
        }

        // PUT: api/Articles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(int id, Article article)
        {
            if (id != article.ArticleId)
            {
                return BadRequest();
            }

            _context.Entry(article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
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

        // POST: api/Articles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticle", new { id = article.ArticleId }, article);
        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Article>> DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return article;
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
        [HttpPost("AjoutPanier")]
        public async Task<ActionResult<Article>> AjoutPanier(int? id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return article;
        }
    }
}
