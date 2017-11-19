using System;
using System.Collections.Generic;
using System.Text;

namespace ThamcoVendors.DTO
{
    public class OrderProcessProducts
    {
        public long Id { get; set; }
        public string Ean { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool InStock { get; set; }
        public object ExpectedRestock { get; set; }
    }
}
