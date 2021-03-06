﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ThamcoVendors.DTO.Vendors
{
    public class Undercutters
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Ean { get; set; }
        public bool ExpectedRestock { get; set; }
        public int Id { get; set; }
        public bool InStock { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
