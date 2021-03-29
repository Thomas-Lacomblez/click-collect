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
    public class ClientsController : Controller
    {
        MarcheAPI _api = new MarcheAPI();
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(ILogger<ClientsController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            List<ClientData> clients = new List<ClientData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/clients");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                clients = JsonConvert.DeserializeObject<List<ClientData>>(result);
            }
            return View(clients);
        }

        public ActionResult Connexion_client()
        {
         
                return View();

        }

        [HttpPost]
        public async Task<ActionResult<ClientData>> Connexion_client(ClientData clients)
        {
            HttpClient client = _api.Initial();

            //HttpPost
            HttpResponseMessage postTask = await client.GetAsync("api/clients/LoginClient");
            if (postTask.IsSuccessStatusCode)
            {
                return View("Connexion_client", clients);
            }
            else
            {
                //return RedirectToAction("ListArticleUtilisateur", "Articles");
                return RedirectToAction("ListMarche", "Categories");
            }

            
        }


        //public async Task<IActionResult> Details(int id)
        //{
        //    var clients = new ClientData();
        //    HttpClient client = _api.Initial();
        //    HttpResponseMessage res = await client.GetAsync($"api/clients/{id}");
        //    if (res.IsSuccessStatusCode)
        //    {
        //        var result = res.Content.ReadAsStringAsync().Result;
        //        clients = JsonConvert.DeserializeObject<ClientData>(result);
        //    }
        //    return View(clients);
        //}

        public async Task<IActionResult> Details(int id)
        {
            var clients = new ClientData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/clients/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                clients = JsonConvert.DeserializeObject<ClientData>(result);
            }
            return View(clients);
        }




        public async Task<IActionResult> Edit(int id)
        {
            var clients = new ClientData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/clients/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                clients = JsonConvert.DeserializeObject<ClientData>(result);
            }
            return View(clients);
        }
        
        [HttpPost]
        public async Task<ClientData> Edit(ClientData clients)
        {
            HttpClient client = _api.Initial();

            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/clients/{clients.ClientId}", clients);
            response.EnsureSuccessStatusCode();

            clients = await response.Content.ReadAsAsync<ClientData>();
            return clients;
        }

        public ActionResult Inscription_client()
        {
            //CategoriesController cat = new CategoriesController();
            //cat.Index();
            //ViewBag.categorieId = new SelectList(db.Categories, "categorieId", "Nom", clients.CategorieId);
            //ViewBag.smsid = new SelectList(db.Sms, "smsid", "smsid", clients.Smsid);
            return View();
        }

        [HttpPost]
        public IActionResult Inscription_client(ClientData clients)
        {
            HttpClient client = _api.Initial();

            //HttpPost
            var postTask = client.PostAsJsonAsync<ClientData>("api/clients", clients);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var clients = new ClientData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/clients/{id}");
            return RedirectToAction("Index");
        }


    }
}