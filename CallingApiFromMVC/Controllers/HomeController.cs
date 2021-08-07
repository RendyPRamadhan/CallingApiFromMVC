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
        StudentAPI _api = new StudentAPI();

        public async Task<IActionResult> Index()
        {
            List<Invoice> students = new List<Invoice>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Invoices");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<Invoice>>(results);
            }
            return View(students);
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
