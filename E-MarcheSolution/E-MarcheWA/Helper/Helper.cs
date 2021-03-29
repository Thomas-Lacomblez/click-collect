using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace E_MarcheWA.Helper
{
   
        public class MarcheAPI
        {
            public HttpClient Initial()
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44396/");
                return client;
            }
        }
    
}
