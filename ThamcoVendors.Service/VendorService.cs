using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ThamcoVendors.Repository.Interfaces;
using ThamcoVendors.Service.Interfaces;

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


        
    }
}