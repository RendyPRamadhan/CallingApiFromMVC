using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CallingApiFromMVC.Controllers
{
    public class InvoicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
