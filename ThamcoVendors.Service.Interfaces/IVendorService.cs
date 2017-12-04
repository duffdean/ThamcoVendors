using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThamcoVendors.Service.Interfaces
{
    public interface IVendorService
    {
        IEnumerable<DTO.Vendor> GetAll();
        DTO.Vendor Get(int ID);
        Task<List<DTO.Vendors.Product>> GetProductsFromBazzasBazaar(int? CategoryId, String CategoryName,
            double? MinPrice, double? MaxPrice);
        Task<List<DTO.VendorProducts>> GetAllProducts();
        Task<List<DTO.OrderProcessProducts>> GetDodgyDealers();
        Task<List<DTO.OrderProcessProducts>> GetUndercutters();
        void OrderUndercutters(DTO.Order Order);
    }
}
