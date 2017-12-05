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
using ThamcoVendors.Service.Helpers;
using System.Text;
using System.Net;
using System.IO;

namespace ThamcoVendors.Service
{
    public class VendorService : IVendorService
    {
        private readonly IRepository<Models.Vendor> _VendorRepository;
        private int maxRetryAttempts = 10;
        private TimeSpan pauseBetweenFailures = TimeSpan.FromSeconds(1);

        public VendorService(IRepository<Models.Vendor> VendorRepository)
        {
            _VendorRepository = VendorRepository;
        }

        public IEnumerable<DTO.Vendor> GetAll()
        {
            var Vendor = _VendorRepository.GetAll();

            return Vendor.Select(Mappers.Map);
        }

        public DTO.Vendor Get(int id)
        {
            var Vendor = _VendorRepository.Get(id);

            return Vendor == null ? null : Mappers.Map(Vendor);
        }

        public async Task<List<DTO.OrderProcessProducts>> GetUndercutters()
        {
            List<DTO.OrderProcessProducts> products = new List<DTO.OrderProcessProducts>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Vendors.Undercutters);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/product");

                if (response.IsSuccessStatusCode)
                {
                    List<Product> obj = new List<Product>();

                    string result = await response.Content.ReadAsStringAsync();

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
                client.BaseAddress = new Uri(Vendors.DodgyDealers);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                
                await RetryHelper.RetryOnExceptionAsync<HttpRequestException>
                    (maxRetryAttempts, pauseBetweenFailures, async () => {
                        response = await client.GetAsync("api/product");
                        response.EnsureSuccessStatusCode();
                    });

                if (response.IsSuccessStatusCode)
                {
                    List<Product> returnData = new List<Product>();

                    string result = await response.Content.ReadAsStringAsync();

                    returnData = JsonConvert.DeserializeObject<List<Product>>(result);

                    foreach (Product prod in returnData)
                    {
                        products.Add(Mappers.MapProduct(prod));
                    }
                }
            }

            return products;
        }

        public async Task<List<DTO.OrderProcessProducts>> GetBazzasBazar()
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
        
        public async Task<HttpResponseMessage> OrderUndercutters(DTO.Order Order)
        {
            List<DTO.OrderProcessProducts> products = new List<DTO.OrderProcessProducts>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = new HttpResponseMessage();
                string returnData;
                
                #pragma warning disable CS0618 // Type or member is obsolete
                var json = await JsonConvert.SerializeObjectAsync(Order);
                #pragma warning restore CS0618 // Type or member is obsolete

                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(Vendors.Undercutters);
                StringContent content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                await RetryHelper.RetryOnExceptionAsync<HttpRequestException>
                   (maxRetryAttempts, pauseBetweenFailures, async () => {
                       response = await httpClient.PostAsync("api/Order", content);
                       response.EnsureSuccessStatusCode();
                   });

                returnData = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(returnData, System.Text.Encoding.UTF8, "application/json") };
                }

                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(returnData, System.Text.Encoding.UTF8, "application/json") };
            }
        }

        public async Task<HttpResponseMessage> OrderDodgyDealers(DTO.Order Order)
        {
            List<DTO.OrderProcessProducts> products = new List<DTO.OrderProcessProducts>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = new HttpResponseMessage();
                string returnData;

                #pragma warning disable CS0618 // Type or member is obsolete
                var json = await JsonConvert.SerializeObjectAsync(Order);
                #pragma warning restore CS0618 // Type or member is obsolete

                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(Vendors.DodgyDealers);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                await RetryHelper.RetryOnExceptionAsync<HttpRequestException>
                   (maxRetryAttempts, pauseBetweenFailures, async () => {
                       response = await httpClient.PostAsync("api/Order", content);
                       response.EnsureSuccessStatusCode();
                   });

                returnData = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(returnData, System.Text.Encoding.UTF8, "application/json") };
                }

                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(returnData, System.Text.Encoding.UTF8, "application/json") };
            }
        }

        public async Task<HttpResponseMessage> OrderBazzasBazar(DTO.Order Order)
        {
            var obj = await OrderFromBazzasBazaar(Order);
            return null;
        }
        
        public async Task<List<DTO.VendorProducts>> GetAllProducts()
        {
            List<DTO.VendorProducts> vendorProducts = new List<DTO.VendorProducts>();

            var a = GetProductsFromBazzasBazaar(null, null, null, null);

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

        public async Task<List<DTO.Vendors.Product>> GetProductsFromBazzasBazaar(int? CategoryId, String CategoryName, double? MinPrice, double? MaxPrice)
        {
            BazzasBazaarService.StoreClient svc = new BazzasBazaarService.StoreClient();
            List<BazzasBazaarService.Product> svcProducts = await svc.GetFilteredProductsAsync(CategoryId, CategoryName, MinPrice, MaxPrice);
            List<DTO.Vendors.Product> products = new List<DTO.Vendors.Product>();

            foreach (BazzasBazaarService.Product prod in svcProducts)
            {
                products.Add(Mappers.MapFromBazzas(prod));
            }

            return products;
        }

        public async Task<HttpResponseMessage> OrderFromBazzasBazaar(DTO.Order Order)
        {
            BazzasBazaarService.StoreClient svc = new BazzasBazaarService.StoreClient();

            BazzasBazaarService.Order order = await svc.CreateOrderAsync(Order.AccountName, Order.CardNumber, Order.ProductID, Order.Quantity);

            #pragma warning disable CS0618 // Type or member is obsolete
            var returnOrder = await JsonConvert.SerializeObjectAsync(order);
            #pragma warning restore CS0618 // Type or member is obsolete

            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(returnOrder, System.Text.Encoding.UTF8, "application/json") };
        }
    }
}