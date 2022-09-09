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
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public async Task<(bool isSuccess, OrdersDTO orders, string errorMessage)> GetOrdersByIdAsync(int id)
        {

            try
            {
                var orderByIdAsync = await dbContext.Orders.FirstOrDefaultAsync(orders => orders.order_id == id);

                if (orderByIdAsync != null)
                {
                    var mappedOrder = mapper.Map<Orders, OrdersDTO>(orderByIdAsync);

                    return(true, mappedOrder, "");
                }

                return(false, null, "Not Found");
            }
            catch (Exception ex)
            {

                logger?.LogError(ex.ToString());

                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, OrdersDTO orders, string errorMessage)> GetOrdersByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool isSuccess, ProductsDTO products, string errorMessage)> GetProductsByIdAsync(int id)
        {
            try
            {
                var productById = await dbContext.Products.FirstOrDefaultAsync(product => product.product_id == id);

                if (productById != null)
                {
                    var mappedProduct = mapper.Map<Products, ProductsDTO>(productById);

                    return (true, mappedProduct, null);
                }

                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, IEnumerable<ProductsDTO> products, string errorMessage)> GetProductsByNameAsync(string name)
        {
            try
            {
                var searchByName = dbContext.Products.Where(n => n.procuct_name.Contains(name));
                var productsByName = await searchByName.ToListAsync();

                if (productsByName != null)
                {
                    var mappedProducts = mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(productsByName);
                    
                    return(true, mappedProducts, "");
                }

                return(false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, ProvidersDTO providers, string errorMessage)> GetProvidersByIdAsync(int id)
        {
            try
            {
                var providerById = await dbContext.Providers.FirstOrDefaultAsync(providers => providers.provider_id == id );

                if (providerById != null)
                {
                    var mappedProvider = mapper.Map<Providers, ProvidersDTO>(providerById);

                    return(true, mappedProvider, "");
                }

                return(false, null, "Not Found");
            }
            catch (Exception ex)
            {
                
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, ProvidersDTO providers, string errorMessage)> GetProvidersByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}