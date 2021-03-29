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
    public class CategoriesController : Controller
    {
        MarcheAPI _api = new MarcheAPI();
        private readonly ILogger<CategoriesController> _logger;

        //public CategoriesController(ILogger<CategoriesController> logger)
        //{
        //    _logger = logger;
        //}
        public CategoriesController()
        {
            
        }
        public async Task<IActionResult> Index()
        {
            List<CategorieData> categories = new List<CategorieData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/categories");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                categories = JsonConvert.DeserializeObject<List<CategorieData>>(result);
            }
            return View(categories);
        }

        public async Task<IActionResult> ListMarche()
        {
            List<CategorieData> categories = new List<CategorieData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/categories");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                categories = JsonConvert.DeserializeObject<List<CategorieData>>(result);
            }
            return View(categories.ToList());
        }

        public async Task<IActionResult> MarchePage(int id)
        {
            
            ArticlesController atcCont = new ArticlesController();
            await atcCont.ListArticle();
            return  RedirectToAction("ListArticle", "Articles");
          
        }


        public async Task<IActionResult> Details(int id)
        {
            var categories = new CategorieData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/categories/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                categories = JsonConvert.DeserializeObject<CategorieData>(result);
            }
            return View(categories);
        }




        public async Task<IActionResult> Edit(int id)
        {
            var categories = new CategorieData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/categories/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                categories = JsonConvert.DeserializeObject<CategorieData>(result);
            }
            return View(categories);
        }
        [HttpPost]
        public async Task<CategorieData> Edit(CategorieData categories)
        {
            HttpClient client = _api.Initial();

            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/categories/{categories.CategorieId}", categories);
            response.EnsureSuccessStatusCode();

            categories = await response.Content.ReadAsAsync<CategorieData>();
            return categories;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategorieData categories)
        {
            HttpClient client = _api.Initial();

            //HttpPost
            var postTask = client.PostAsJsonAsync<CategorieData>("api/categories", categories);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ListMarche");
            }
            //ViewBag.categorieId = new SelectList(db.Categories, "categorieId", "Nom", categories.CategorieId);
            //ViewBag.smsid = new SelectList(db.Sms, "smsid", "smsid", categories.Smsid);
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var categories = new CategorieData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/categories/{id}");
            return RedirectToAction("ListMarche");
        }


    }
}