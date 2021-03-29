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
    public class PaniersController : Controller
    {
        MarcheAPI _api = new MarcheAPI();
        private readonly ILogger<PaniersController> _logger;

        //public paniersController(ILogger<paniersController> logger)
        //{
        //    _logger = logger;
        //}
        public PaniersController()
        {
            
        }
        public async Task<IActionResult> Index()
        {
            List<PanierData> paniers = new List<PanierData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/paniers");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                paniers = JsonConvert.DeserializeObject<List<PanierData>>(result);
            }
            return View(paniers);
        }
        public async Task<IActionResult> Panier()
        {
            List<PanierData> paniers = new List<PanierData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/paniers");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                paniers = JsonConvert.DeserializeObject<List<PanierData>>(result);
            }
            return View(paniers);
        }

        public async Task<IActionResult> ListArticle()
        {
            List<PanierData> paniers = new List<PanierData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/paniers/");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                paniers = JsonConvert.DeserializeObject<List<PanierData>>(result);
            }
            return View(paniers.ToList());
        }

        public async Task<IActionResult> Details(int id)
        {
            var paniers = new PanierData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/paniers/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                paniers = JsonConvert.DeserializeObject<PanierData>(result);
            }
            return View(paniers);
        }




        public async Task<IActionResult> Edit(int id)
        {
            var paniers = new PanierData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/paniers/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                paniers = JsonConvert.DeserializeObject<PanierData>(result);
            }
            return View(paniers);
        }
        [HttpPost]
        public async Task<PanierData> Edit(PanierData paniers)
        {
            HttpClient client = _api.Initial();

            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/paniers/{paniers.PanierId}", paniers);
            response.EnsureSuccessStatusCode();

            paniers = await response.Content.ReadAsAsync<PanierData>();
            return paniers;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PanierData paniers)
        {
            HttpClient client = _api.Initial();

            //HttpPost
            var postTask = client.PostAsJsonAsync<PanierData>("api/paniers", paniers);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Panier");
            }
            //ViewBag.categorieId = new SelectList(db.paniers, "categorieId", "Nom", paniers.CategorieId);
            //ViewBag.smsid = new SelectList(db.Sms, "smsid", "smsid", paniers.Smsid);
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var paniers = new PanierData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/paniers/{id}");
            return RedirectToAction("Panier");
        }

        //début ajout
        //public int Countelement()
        //{
            
        //public double? CounteSomme()
        //{

        //}

        //fin ajout 


    }
}