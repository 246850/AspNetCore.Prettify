using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Prettify.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int a = 10;
            int b = 0;
            int number = a / b;

            return View();
        }
    }
}