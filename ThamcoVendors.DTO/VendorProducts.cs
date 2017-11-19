using System;
using System.Collections.Generic;
using System.Text;

namespace ThamcoVendors.DTO
{
    public class VendorProducts
    {
        public string Name { get; set; }
        public List<DTO.Vendors.Product> Products { get; set; }
    }
}
