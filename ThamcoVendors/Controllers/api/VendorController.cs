using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThamcoVendors.Service.Interfaces;
using ThamcoVendors.DTO;

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
    }
}