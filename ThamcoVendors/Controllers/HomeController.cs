using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThamcoVendors.Service.Interfaces;

namespace ThamcoVendors.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVendorService _vendorService;

        public HomeController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
