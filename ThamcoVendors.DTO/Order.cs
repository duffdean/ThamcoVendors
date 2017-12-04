using System;
using System.Collections.Generic;
using System.Text;

namespace ThamcoVendors.DTO
{
    public class Order
    {
        public string Vendor { get; set; }
        public string AccountName { get; set; }
        public string CardNumber { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
