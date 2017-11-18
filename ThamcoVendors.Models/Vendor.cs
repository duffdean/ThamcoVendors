using System;
using System.ComponentModel.DataAnnotations;

namespace ThamcoVendors.Models
{
    public class Vendor
    {
        public Vendor() { }

        public string Name { get; set; }
        public string HostAddress { get; set; }
        public string RetrievalMethod { get; set; }
        public bool Active { get; set; }
    }
}
