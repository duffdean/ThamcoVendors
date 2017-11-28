using AutoMapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using ThamcoVendors.DTO.Vendors;

namespace ThamcoVendors.Service.Helpers
{
    public static class Mappers
    {
        public static DTO.Vendor Map(Models.Vendor Vendor)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Models.Vendor, DTO.Vendor>();
            });

            IMapper iMapper = config.CreateMapper();

            return iMapper.Map<Models.Vendor, DTO.Vendor>(Vendor);
        }

        public static DTO.OrderProcessProducts MapProduct(Product Prpduct)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, DTO.OrderProcessProducts>();
            });

            IMapper iMapper = config.CreateMapper();

            return iMapper.Map<Product, DTO.OrderProcessProducts>(Prpduct);
        }

        public static DTO.Vendors.Product MapFromApi(JObject json)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<JObject, DTO.Vendors.Product>();
            });

            IMapper iMapper = config.CreateMapper();

            return iMapper.Map<JObject, DTO.Vendors.Product>(json);
        }

        public static DTO.Vendors.Product MapFromBazzas(BazzasBazaarService.Product Vendor)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BazzasBazaarService.Product, DTO.Vendors.Product>();
            });

            IMapper iMapper = config.CreateMapper();

            return iMapper.Map<BazzasBazaarService.Product, DTO.Vendors.Product>(Vendor);
        }
    }
}
