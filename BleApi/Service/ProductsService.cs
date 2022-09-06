using BleApi.Dtos;
using BleApi.Interfaces;
using BleApi.Context;
using BleApi.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BleApi.Service
{
    class ProductsService : IBleService
    {
        private readonly BleDbContext dbContext;
        private readonly ILogger<ProductsService> logger;
        private readonly IMapper mapper;

        public ProductsService(BleDbContext dbContext, ILogger<ProductsService> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<(bool isSuccess, IEnumerable<OrdersDTO> orders, string errorMessage)> GetAllOrdersAsync()
        {
            try
            {
                var allOrders = await dbContext.Orders.ToListAsync();

                if (allOrders != null && allOrders.Any())
                {
                    var ordersMapped = mapper.Map<IEnumerable<BleApi.Model.Orders>, IEnumerable<OrdersDTO>>(allOrders);
                    return (true, ordersMapped, "");
                }

                return(false, null, "You don't have any orders at the moment, orders not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return(false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, IEnumerable<ProductsDTO> products, string errorMessage)> GetAllProductsAsync()
        {
            try
            {
                var allProducts = await dbContext.Products.ToListAsync();

                if (allProducts != null && allProducts.Any())
                {
                    var mappedProducts = mapper.Map<IEnumerable<BleApi.Model.Products>, IEnumerable<ProductsDTO>>(allProducts);

                    return (true, mappedProducts, "");
                }
                return (false, null, "You don't have any products at the moment, products not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, IEnumerable<ProvidersDTO> providers, string errorMessage)> GetAllProvidersAsync()
        {
            try
            {
                var allProviders = await dbContext.Providers.ToListAsync();

                if (allProviders != null && allProviders.Any())
                {
                    var mappedProviders = mapper.Map<IEnumerable<BleApi.Model.Providers>, IEnumerable<ProvidersDTO>>(allProviders);

                    return (true, mappedProviders, "");
                }
                return (false, null, "You don't have any providers at the moment, providers not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, OrdersDTO orders, string errorMessage)> GetOrdersByDateAsync(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool isSuccess, OrdersDTO orders, string errorMessage)> GetOrdersByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool isSuccess, OrdersDTO orders, string errorMessage)> GetOrdersByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool isSuccess, ProductsDTO products, string errorMessage)> GetProductsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool isSuccess, ProductsDTO products, string errorMessage)> GetProductsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool isSuccess, ProvidersDTO providers, string errorMessage)> GetProvidersByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool isSuccess, ProvidersDTO providers, string errorMessage)> GetProvidersByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}