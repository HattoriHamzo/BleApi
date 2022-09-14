using BleApi.Dtos;
using BleApi.Interfaces;
using BleApi.Context;
using BleApi.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BleApi.Service
{
    class ProductsService : IProductsService
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

        public async Task<(bool isSuccess, string statusMessage)> CreateProductAsync(ProductsDTO product)
        {
            try
            {
                var searchIfExists = dbContext.Products.Any(productsEntity => productsEntity.product_id == product.product_id);

                if (!searchIfExists)
                {  
                    var mappedProduct = mapper.Map<Products>(product);
                        dbContext.Products.Add(mappedProduct);
                        await dbContext.SaveChangesAsync();
                    return (true, "Product Created");
                }
                return (false, "Product Not Created");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, ex.Message);
            }
        }
    }
}