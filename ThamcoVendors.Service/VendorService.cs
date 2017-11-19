using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThamcoVendors.Repository.Interfaces;
using ThamcoVendors.Service.Interfaces;
using ThamcoVendors.DTO.Vendors;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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

        public async Task<List<DTO.OrderProcessProducts>> GetUndercutters()
        {
            List<DTO.OrderProcessProducts> products = new List<DTO.OrderProcessProducts>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://undercutters.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/product");

                if (response.IsSuccessStatusCode)
                {
                    List<Product> obj = new List<Product>();

                    string result = await response.Content.ReadAsStringAsync();
                    //object json = JsonConvert.DeserializeObject(details.Result);

                    obj = JsonConvert.DeserializeObject<List<Product>>(result);

                    foreach (var prod in obj)
                    {
                        products.Add(new DTO.OrderProcessProducts()
                        {
                            Id = prod.Id,
                            Description = prod.Description,
                            Ean = prod.Ean,
                            ExpectedRestock = prod.ExpectedRestock,
                            InStock = prod.InStock,
                            Name = prod.Name,
                            Price = prod.Price,
                            Brand = new DTO.Brand()
                            {
                                ID = prod.BrandId,
                                Name = prod.BrandName
                            },
                            Category = new DTO.Category()
                            {
                                ID = prod.CategoryId,
                                Name = prod.CategoryName
                            }
                        });
                    }
                }
                else
                {

                }
            }

            return products;
        }

        public async Task<List<DTO.OrderProcessProducts>> GetDodgyDealers()
        {
            List<DTO.OrderProcessProducts> products = new List<DTO.OrderProcessProducts>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://dodgydealers.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/product");

                if (response.IsSuccessStatusCode)
                {
                    List<Product> obj = new List<Product>();

                    string result = await response.Content.ReadAsStringAsync();
                    //object json = JsonConvert.DeserializeObject(details.Result);

                    obj = JsonConvert.DeserializeObject<List<Product>>(result);

                    foreach (var prod in obj)
                    {
                        products.Add(new DTO.OrderProcessProducts()
                        {
                            Id = prod.Id,
                            Description = prod.Description,
                            Ean = prod.Ean,
                            ExpectedRestock = prod.ExpectedRestock,
                            InStock = prod.InStock,
                            Name = prod.Name,
                            Price = prod.Price,
                            Brand = new DTO.Brand()
                            {
                                ID = prod.BrandId,
                                Name = prod.BrandName
                            },
                            Category = new DTO.Category()
                            {
                                ID = prod.CategoryId,
                                Name = prod.CategoryName
                            }
                        });
                    }
                }
                else
                {

                }
            }

            return products;
        }

        public async Task<List<DTO.OrderProcessProducts>> GetBazzasBazzar()
        {
            List<DTO.OrderProcessProducts> products = new List<DTO.OrderProcessProducts>();
            var obj = await GetProductsFromBazzasBazaar(null, null, null, null);

            foreach (var prod in obj)
            {
                products.Add(new DTO.OrderProcessProducts()
                {
                    Id = prod.Id,
                    Description = prod.Description,
                    Ean = prod.Ean,
                    ExpectedRestock = prod.ExpectedRestock,
                    InStock = prod.InStock,
                    Name = prod.Name,
                    Price = prod.Price,
                    Brand = new DTO.Brand()
                    {
                        ID = prod.BrandId,
                        Name = prod.BrandName
                    },
                    Category = new DTO.Category()
                    {
                        ID = prod.CategoryId,
                        Name = prod.CategoryName
                    }
                });
            }

            return products;
        }

        public async Task<List<DTO.VendorProducts>> GetAllProducts()
        {
            List<DTO.VendorProducts> vendorProducts = new List<DTO.VendorProducts>();

            var a = GetProductsFromBazzasBazaar(null, null, null, null);

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:56851/");

            //// Add an Accept header for JSON format.
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));

            //HttpResponseMessage response = client.GetAsync("api/User").Result;

            //if (response.IsSuccessStatusCode)
            //{
            //    var users = response.Content.ReadAsStringAsync &
            //    lt; IEnumerable & lt; Users & gt; &gt; ().Result;
            //    usergrid.ItemsSource = users;

            //}
            //else
            //{
            //    MessageBox.Show("Error Code" +
            //    response.StatusCode + " : Message - " + response.ReasonPhrase);
            //}

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://undercutters.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/product");

                if (response.IsSuccessStatusCode)
                {
                    List<Product> obj = new List<Product>();

                    string result = await response.Content.ReadAsStringAsync();
                    //object json = JsonConvert.DeserializeObject(details.Result);

                    obj = JsonConvert.DeserializeObject<List<Product>>(result);

                    vendorProducts.Add(new DTO.VendorProducts()
                    {
                        Name = "BazaasBazaar",
                        Products = obj
                    });                 
                }
                else
                {

                }
            }

            return vendorProducts;
        }

        private static DTO.Vendor Map(Models.Vendor Vendor)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Models.Vendor, DTO.Vendor>();
            });

            IMapper iMapper = config.CreateMapper();

            return iMapper.Map<Models.Vendor, DTO.Vendor>(Vendor);
        }

        private static DTO.Vendors.Product MapFromApi(JObject json)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<JObject, DTO.Vendors.Product>();
            });

            IMapper iMapper = config.CreateMapper();

            return iMapper.Map<JObject, DTO.Vendors.Product>(json);
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