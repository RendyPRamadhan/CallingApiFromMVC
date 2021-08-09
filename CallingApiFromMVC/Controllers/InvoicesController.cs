using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CallingApiFromMVC.Models;
using CallingApiFromMVC.Helper;
using Newtonsoft.Json;
using System.Net.Http;

namespace CallingApiFromMVC.Controllers
{
    public class InvoicesController : Controller
    {
        InvoiceAPI _api = new InvoiceAPI();
        public static List<Currency> Currencys = new List<Currency>();

        MyViewModel vwmodel = new MyViewModel();
        /*
        private readonly IBookRepository _bookRepository = null;
        private readonly ILanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InvoicesController()*/
        public async Task<IActionResult> Index()
        {
            HttpClient client = _api.Initial();

            HttpResponseMessage res_uom = await client.GetAsync("api/UOMs");
            if (res_uom.IsSuccessStatusCode)
            {
                var results_uom = res_uom.Content.ReadAsStringAsync().Result;
                vwmodel.UOMs = JsonConvert.DeserializeObject<List<UOM>>(results_uom);
            }

            HttpResponseMessage res_curr = await client.GetAsync("api/Currencys");
            if (res_curr.IsSuccessStatusCode)
            {
                var results = res_curr.Content.ReadAsStringAsync().Result;
                vwmodel.Currencys = JsonConvert.DeserializeObject<List<Currency>>(results);
            }

            


            return View(vwmodel);
        }
        /*
        public IActionResult Index()
        {
            return View();
        }*/
        public IActionResult test()
        {
            return View();
        }
    }
}
