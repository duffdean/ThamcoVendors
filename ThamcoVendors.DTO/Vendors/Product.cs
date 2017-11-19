using System;
using System.Collections.Generic;
using System.Text;

namespace ThamcoVendors.DTO.Vendors
{
    public class Product
    {
        public long BrandId { get; set; }     
        public string BrandName { get; set; }     
        public long CategoryId { get; set; }     
        public string CategoryName { get; set; }     
        public string Description { get; set; }     
        public string Ean { get; set; }     
        public object ExpectedRestock { get; set; }     
        public long Id { get; set; }     
        public bool InStock { get; set; }     
        public string Name { get; set; }     
        public double Price { get; set; }
    }
}
