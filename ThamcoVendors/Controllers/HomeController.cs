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


        public async Task<IActionResult> Index()
        {
            ////var a = _vendorService.GetAll();
            ////var b = _vendorService.GetDodgyDealers();
            //////var b = _vendorService.GetProductsFromBazzasBazaar(null, null, null, null).Result;
            ////var c = await _vendorService.GetAllProducts();
            //DTO.Order order = new DTO.Order()
            //{
            //    AccountName = "dfgdfg",
            //    CardNumber = "dfgdfgdfg",
            //    ProductID = 1,
            //    Quantity = 1,
            //    Vendor = "bazzasbazaar"

            //};

            ////_vendorService.OrderUndercutters(order);
            //var a = await _vendorService.OrderFromBazzasBazaar(order);

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
