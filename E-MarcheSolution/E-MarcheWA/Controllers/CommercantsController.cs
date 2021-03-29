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
    public class CommercantsController : Controller
    {
        MarcheAPI _api = new MarcheAPI();
        private readonly ILogger<CommercantsController> _logger;

        //public CommercantsController(ILogger<CommercantsController> logger)
        //{
        //    _logger = logger;
        //}
        public CommercantsController()
        {
            
        }
        public async Task<IActionResult> Index()
        {
            List<CommercantData> commercants = new List<CommercantData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/commercants");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                commercants = JsonConvert.DeserializeObject<List<CommercantData>>(result);
            }
            return View(commercants);
        }

        public ActionResult Connexion_commercant()
        {
         
                return View();

        }

        [HttpPost]
        public async Task<ActionResult<CommercantData>> Connexion_commercant(CommercantData commercants)
        {
            HttpClient client = _api.Initial();

            //HttpPost
            HttpResponseMessage postTask = await client.GetAsync("api/commercants/LoginClient");
            if (postTask.IsSuccessStatusCode)
            {
                return View("Connexion_client", commercants);
            }
            else
            {
                //return RedirectToAction("ListArticleUtilisateur", "Articles");
                return RedirectToAction("ListMarche", "Categories");
            }

            
        }


        public async Task<IActionResult> Details(int id)
        {
            var commercants = new CommercantData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/commercants/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                commercants = JsonConvert.DeserializeObject<CommercantData>(result);
            }
            return View(commercants);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var commercants = new CommercantData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/commercants/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                commercants = JsonConvert.DeserializeObject<CommercantData>(result);
            }
            return View(commercants);
        }
        [HttpPost]
        public async Task<CommercantData> Edit(CommercantData commercants)
        {
            HttpClient client = _api.Initial();

            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/commercants/{commercants.CommercantId}", commercants);
            response.EnsureSuccessStatusCode();

            commercants = await response.Content.ReadAsAsync<CommercantData>();
            return commercants;
        }

        public ActionResult Inscription_commercant()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inscription_commercant(CommercantData commercants)
        {
            HttpClient client = _api.Initial();

            //HttpPost
            var postTask = client.PostAsJsonAsync<CommercantData>("api/commercants", commercants);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            //ViewBag.categorieId = new SelectList(db.Categories, "categorieId", "Nom", categories.CategorieId);
            //ViewBag.smsid = new SelectList(db.Sms, "smsid", "smsid", categories.Smsid);
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var commercants = new CommercantData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/commercants/{id}");
            return RedirectToAction("Index");
        }


    }
}