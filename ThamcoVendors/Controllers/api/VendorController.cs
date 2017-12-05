using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThamcoVendors.Service.Interfaces;
using ThamcoVendors.DTO;
using System.Net.Http;
using System.Net;

namespace ThamcoVendors.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Vendor")]
    public class VendorController : Controller
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        // GET: api/User
        [HttpGet("GetAllProducts")]
        //[Authorize(Policy = "ThamcoUser")]
        public async Task<List<OrderProcessProducts>> GetAllProducts(string Vendor)
        {
            //var users = _vendorService.GetProductsByVendor(Vendor);

            List<OrderProcessProducts> prods;
            switch (Vendor.ToLower())
            {
                case "undercutters":
                    return await _vendorService.GetUndercutters();
                case "bazzasbazaar":
                    return await _vendorService.GetDodgyDealers();                    
                case "dodgydealers":
                    return await _vendorService.GetDodgyDealers();
                default:
                    break;
            }

            return null;
        }

        // GET: api/User
        [HttpPost("Order")]
        //[Authorize(Policy = "ThamcoUser")]
        public async Task<HttpResponseMessage> Order(DTO.Order Order)
        {
            //var users = _vendorService.GetProductsByVendor(Vendor);

            List<OrderProcessProducts> prods;
            switch (Order.Vendor.ToLower())
            {
                case "undercutters":
                    return await _vendorService.OrderUndercutters(Order);
                case "bazzasbazaar":
                    return await _vendorService.OrderUndercutters(Order);
                case "dodgydealers":
                    return await _vendorService.OrderUndercutters(Order);
                default:
                    break;
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Invalid Vendor name provided", System.Text.Encoding.UTF8, "application/json") };
        }
    }
}