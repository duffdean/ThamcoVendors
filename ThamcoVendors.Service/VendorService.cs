using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThamcoVendors.Repository.Interfaces;
using ThamcoVendors.Service.Interfaces;
using ThamcoVendors.DTO.Vendors;

namespace ThamcoVendors.Service
{
    public class VendorService : IVendorService
    {
        private readonly IRepository<Models.Vendor> _VendorRepository;

        public VendorService(IRepository<Models.Vendor> VendorRepository)
        {
            _VendorRepository = VendorRepository;
        }

        public IEnumerable<DTO.Vendor> GetAll()
        {
            var Vendor = _VendorRepository.GetAll();

            return Vendor.Select(Map);
        }

        public DTO.Vendor Get(int id)
        {
            var Vendor = _VendorRepository.Get(id);

            return Vendor == null ? null : Map(Vendor);
        }
        

        private static DTO.Vendor Map(Models.Vendor Vendor)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Models.Vendor, DTO.Vendor>();
            });

            IMapper iMapper = config.CreateMapper();

            return iMapper.Map<Models.Vendor, DTO.Vendor>(Vendor);
        }

        private static DTO.Vendors.Product MapFromBazzas(BazzasBazaarService.Product Vendor)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BazzasBazaarService.Product, DTO.Vendors.Product>();
            });

            IMapper iMapper = config.CreateMapper();

            return iMapper.Map<BazzasBazaarService.Product, DTO.Vendors.Product>(Vendor);
        }

        public async Task<List<DTO.Vendors.Product>> GetProductsFromBazzasBazaar(int? CategoryId, String CategoryName, double? MinPrice, double? MaxPrice)
        {
            BazzasBazaarService.StoreClient svc = new BazzasBazaarService.StoreClient();
            List<BazzasBazaarService.Product> svcProducts = await svc.GetFilteredProductsAsync(CategoryId, CategoryName, MinPrice, MaxPrice);
            //List<DTO.Vendors.BazzasBazaar> products = new List<DTO.Vendors.BazzasBazaar>();
            List<DTO.Vendors.Product> products = new List<DTO.Vendors.Product>();

            foreach (BazzasBazaarService.Product prod in svcProducts)
            {
                products.Add(MapFromBazzas(prod));
            }

            return products;
        }
    }
}