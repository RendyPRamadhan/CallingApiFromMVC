using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CallingApiFromMVC.Models;
using CallingApiFromMVC.Helper;
using Newtonsoft.Json;
using System.Net.Http;

namespace CallingApiFromMVC.Controllers
{
    public class HomeController : Controller
    {
        InvoiceAPI _api = new InvoiceAPI();

        public async Task<IActionResult> Index()
        {
            List<Invoice> Invoices = new List<Invoice>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Invoices");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                Invoices = JsonConvert.DeserializeObject<List<Invoice>>(results);
            }
            return View(Invoices);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
