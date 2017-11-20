﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     //
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BazzasBazaarService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Category", Namespace="http://schemas.datacontract.org/2004/07/BazzasBazaar.Service")]
    public partial class Category : object
    {
        
        private int AvailableProductCountField;
        
        private string DescriptionField;
        
        private int IdField;
        
        private string NameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AvailableProductCount
        {
            get
            {
                return this.AvailableProductCountField;
            }
            set
            {
                this.AvailableProductCountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="http://schemas.datacontract.org/2004/07/BazzasBazaar.Service")]
    public partial class Product : object
    {
        
        private int CategoryIdField;
        
        private string CategoryNameField;
        
        private string DescriptionField;
        
        private string EanField;
        
        private System.Nullable<System.DateTime> ExpectedRestockField;
        
        private int IdField;
        
        private bool InStockField;
        
        private string NameField;
        
        private double PriceForOneField;
        
        private double PriceForTenField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CategoryId
        {
            get
            {
                return this.CategoryIdField;
            }
            set
            {
                this.CategoryIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CategoryName
        {
            get
            {
                return this.CategoryNameField;
            }
            set
            {
                this.CategoryNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Ean
        {
            get
            {
                return this.EanField;
            }
            set
            {
                this.EanField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> ExpectedRestock
        {
            get
            {
                return this.ExpectedRestockField;
            }
            set
            {
                this.ExpectedRestockField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool InStock
        {
            get
            {
                return this.InStockField;
            }
            set
            {
                this.InStockField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PriceForOne
        {
            get
            {
                return this.PriceForOneField;
            }
            set
            {
                this.PriceForOneField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PriceForTen
        {
            get
            {
                return this.PriceForTenField;
            }
            set
            {
                this.PriceForTenField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Order", Namespace="http://schemas.datacontract.org/2004/07/BazzasBazaar.Service")]
    public partial class Order : object
    {
        
        private string AccountNameField;
        
        private string CardNumberField;
        
        private int IdField;
        
        private string ProductEanField;
        
        private int ProductIdField;
        
        private string ProductNameField;
        
        private int QuantityField;
        
        private double TotalPriceField;
        
        private System.DateTime WhenField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AccountName
        {
            get
            {
                return this.AccountNameField;
            }
            set
            {
                this.AccountNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CardNumber
        {
            get
            {
                return this.CardNumberField;
            }
            set
            {
                this.CardNumberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductEan
        {
            get
            {
                return this.ProductEanField;
            }
            set
            {
                this.ProductEanField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductId
        {
            get
            {
                return this.ProductIdField;
            }
            set
            {
                this.ProductIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductName
        {
            get
            {
                return this.ProductNameField;
            }
            set
            {
                this.ProductNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Quantity
        {
            get
            {
                return this.QuantityField;
            }
            set
            {
                this.QuantityField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double TotalPrice
        {
            get
            {
                return this.TotalPriceField;
            }
            set
            {
                this.TotalPriceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime When
        {
            get
            {
                return this.WhenField;
            }
            set
            {
                this.WhenField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BazzasBazaarService.IStore")]
    public interface IStore
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStore/GetAllCategories", ReplyAction="http://tempuri.org/IStore/GetAllCategoriesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<BazzasBazaarService.Category>> GetAllCategoriesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStore/GetCategoryById", ReplyAction="http://tempuri.org/IStore/GetCategoryByIdResponse")]
        System.Threading.Tasks.Task<BazzasBazaarService.Category> GetCategoryByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStore/GetFilteredProducts", ReplyAction="http://tempuri.org/IStore/GetFilteredProductsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<BazzasBazaarService.Product>> GetFilteredProductsAsync(System.Nullable<int> categoryId, string categoryName, System.Nullable<double> minPrice, System.Nullable<double> maxPrice);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStore/GetProductById", ReplyAction="http://tempuri.org/IStore/GetProductByIdResponse")]
        System.Threading.Tasks.Task<BazzasBazaarService.Product> GetProductByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStore/GetOrderById", ReplyAction="http://tempuri.org/IStore/GetOrderByIdResponse")]
        System.Threading.Tasks.Task<BazzasBazaarService.Order> GetOrderByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStore/CreateOrder", ReplyAction="http://tempuri.org/IStore/CreateOrderResponse")]
        System.Threading.Tasks.Task<BazzasBazaarService.Order> CreateOrderAsync(string accountName, string cardNumber, int productId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStore/CancelOrderById", ReplyAction="http://tempuri.org/IStore/CancelOrderByIdResponse")]
        System.Threading.Tasks.Task<bool> CancelOrderByIdAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    public interface IStoreChannel : BazzasBazaarService.IStore, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    public partial class StoreClient : System.ServiceModel.ClientBase<BazzasBazaarService.IStore>, BazzasBazaarService.IStore
    {
        
    /// <summary>
    /// Implement this partial method to configure the service endpoint.
    /// </summary>
    /// <param name="serviceEndpoint">The endpoint to configure</param>
    /// <param name="clientCredentials">The client credentials</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public StoreClient() : 
                base(StoreClient.GetDefaultBinding(), StoreClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IStore.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public StoreClient(EndpointConfiguration endpointConfiguration) : 
                base(StoreClient.GetBindingForEndpoint(endpointConfiguration), StoreClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public StoreClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(StoreClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public StoreClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(StoreClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public StoreClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<BazzasBazaarService.Category>> GetAllCategoriesAsync()
        {
            return base.Channel.GetAllCategoriesAsync();
        }
        
        public System.Threading.Tasks.Task<BazzasBazaarService.Category> GetCategoryByIdAsync(int id)
        {
            return base.Channel.GetCategoryByIdAsync(id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<BazzasBazaarService.Product>> GetFilteredProductsAsync(System.Nullable<int> categoryId, string categoryName, System.Nullable<double> minPrice, System.Nullable<double> maxPrice)
        {
            return base.Channel.GetFilteredProductsAsync(categoryId, categoryName, minPrice, maxPrice);
        }
        
        public System.Threading.Tasks.Task<BazzasBazaarService.Product> GetProductByIdAsync(int id)
        {
            return base.Channel.GetProductByIdAsync(id);
        }
        
        public System.Threading.Tasks.Task<BazzasBazaarService.Order> GetOrderByIdAsync(int id)
        {
            return base.Channel.GetOrderByIdAsync(id);
        }
        
        public System.Threading.Tasks.Task<BazzasBazaarService.Order> CreateOrderAsync(string accountName, string cardNumber, int productId, int quantity)
        {
            return base.Channel.CreateOrderAsync(accountName, cardNumber, productId, quantity);
        }
        
        public System.Threading.Tasks.Task<bool> CancelOrderByIdAsync(int id)
        {
            return base.Channel.CancelOrderByIdAsync(id);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IStore))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IStore))
            {
                return new System.ServiceModel.EndpointAddress("http://bazzasbazaar.azurewebsites.net/Store.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return StoreClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IStore);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return StoreClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IStore);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IStore,
        }
    }
}