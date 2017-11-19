using System;
using System.Collections.Generic;
using System.Text;

namespace ThamcoVendors.DTO
{
    public class Vendor
    {
        public string Name { get; set; }
        public string HostAddress { get; set; }
        public string RetrievalMethod { get; set; }
        public bool Active { get; set; }
    }
}
