using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using E_MarcheWA.Helper;
using E_MarcheWA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace E_MarcheWA.Controllers
{
    public class ArticlesController : Controller
    {
        MarcheAPI _api = new MarcheAPI();
        PaniersController p = new PaniersController();
        private readonly ILogger<ArticlesController> _logger;

        //public articlesController(ILogger<articlesController> logger)
        //{
        //    _logger = logger;
        //}
        public ArticlesController()
        {
            
        }
        public async Task<IActionResult> Index()
        {
            List<ArticleData> articles = new List<ArticleData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/articles");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                articles = JsonConvert.DeserializeObject<List<ArticleData>>(result);
            }
            return View(articles);
        }

          
        public async Task<IActionResult> ListArticle()
        {
            List<ArticleData> articles = new List<ArticleData>();
            HttpClient client = _api.Initial();
            //HttpResponseMessage res = await client.GetAsync($"api/articles/{id}");
            HttpResponseMessage res = await client.GetAsync($"api/articles");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                articles = JsonConvert.DeserializeObject<List<ArticleData>>(result);
            }
            return View(articles);
        }

        public async Task<IActionResult> Details(int id)
        {
            var articles = new ArticleData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/articles/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                articles = JsonConvert.DeserializeObject<ArticleData>(result);
            }
            return View(articles);
        }




        public async Task<IActionResult> Edit(int id)
        {
            var articles = new ArticleData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/articles/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                articles = JsonConvert.DeserializeObject<ArticleData>(result);
            }
            return View(articles);
        }
        [HttpPost]
        public async Task<ArticleData> Edit(ArticleData articles)
        {
            HttpClient client = _api.Initial();

            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/articles/{articles.ArticleId}", articles);
            response.EnsureSuccessStatusCode();

            articles = await response.Content.ReadAsAsync<ArticleData>();
            return articles;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ArticleData articles)
        {
            HttpClient client = _api.Initial();

            //HttpPost
            var postTask = client.PostAsJsonAsync<ArticleData>("api/articles", articles);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ListArticle");
            }
            //ViewBag.categorieId = new SelectList(db.Categories, "categorieId", "Nom", categories.CategorieId);
            //ViewBag.smsid = new SelectList(db.Sms, "smsid", "smsid", categories.Smsid);
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var articles = new ArticleData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/articles/{id}");
            return RedirectToAction("ListArticle");
        }
        //public ActionResult AjoutPanier()
        //{
        //    return View();
        //}
        public async Task<IActionResult> AjoutPanier(int? id)
        {
            //List<ArticleData> articles = new List<ArticleData>();
            ArticleData articles = new ArticleData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/articles/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                articles = JsonConvert.DeserializeObject<ArticleData>(result);
            }
            //foreach (var art in articles)
            //{
                if (articles.ArticleId==id) {
                    PanierData pd = new PanierData
                    {

                        Photo = articles.Photo,
                        Cantite = articles.Cantite,
                        PrixArticle = articles.Prix,
                        ArticleId = articles.ArticleId
                    };
                    p.Create(pd);
                }
            //}
            
            //return View(articles);
            
            return RedirectToAction("Panier", "Paniers");
        }

    }
}