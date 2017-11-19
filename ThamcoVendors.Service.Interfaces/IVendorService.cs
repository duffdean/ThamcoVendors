using System;
using System.Collections.Generic;
using System.Text;

namespace ThamcoVendors.Service.Interfaces
{
    public interface IVendorService
    {
        IEnumerable<DTO.Vendor> GetAll();
        DTO.Vendor Get(int ID);

    }
}
