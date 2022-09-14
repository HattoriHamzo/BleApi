using BleApi.Interfaces;
using BleApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BleApi.Controllers
{
    [ApiController]
    [Route("api/ble")]
    public class BleController : ControllerBase
    {
        private readonly IProductsService productsService;
        private readonly IProvidersService providersService;
        private readonly IOrdersService ordersService;

        public BleController(IProductsService productsService, IProvidersService providersService, IOrdersService ordersService)
        {
            this.productsService = productsService;
            this.providersService = providersService;
            this.ordersService = ordersService;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var allProducts = await productsService.GetAllProductsAsync();

            if (allProducts.isSuccess)
            {
                return Ok(allProducts.products);
            }

            return NotFound();
        }

        [HttpGet("providers")]
        public async Task<IActionResult> GetAllProvidersAsync()
        {
            var allProviders = await providersService.GetAllProvidersAsync();

            if(allProviders.isSuccess)
            {
                return Ok(allProviders.providers);
            }

            return NotFound();
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var allOrders = await ordersService.GetAllOrdersAsync();

            if (allOrders.isSuccess)
            {
                return Ok(allOrders.orders);
            }

            return NotFound();
        }

        [HttpGet("products/searchID/{id}")]
        public async Task<IActionResult> GetProductsByIdAsync(int id)
        {
            var productById = await productsService.GetProductsByIdAsync(id);

            if (productById.isSuccess)
            {
                return Ok(productById.products);
            }

            return NotFound();
        }

        [HttpGet("providers/searchID/{id}")]
        public async Task<IActionResult> GetProvidersByIdAsync(int id)
        {
            var providerById = await providersService.GetProvidersByIdAsync(id);

            if (providerById.isSuccess)
            {
                return Ok(providerById.providers);
            }

            return NotFound();
        }

        [HttpGet("orders/searchID/{id}")]
        public async Task<IActionResult> GetOrdersByIdAsync(int id)
        {
            var orderById = await ordersService.GetOrdersByIdAsync(id);

            if(orderById.isSuccess)
            {
                return Ok(orderById.orders);
            }

            return NotFound();
        }

        [HttpGet("products/searchName/{name}")]
        public async Task<IActionResult> GetProductsByNameAsync(string name)
        {
            var productsByname = await productsService.GetProductsByNameAsync(name);

            if (productsByname.isSuccess)
            {
                return Ok(productsByname.products);
            }

            return NotFound();
        }

        [HttpGet("providers/searchName/{name}")]
        public async Task<IActionResult> GetProvidersByNameAsync(string name)
        {
            var providersByName = await providersService.GetProvidersByNameAsync(name);

            if(providersByName.isSuccess)
            {
                return Ok(providersByName.providers);
            }

            return NotFound();
        }

        [HttpGet("orders/searchName/{name}")]
        public async Task<IActionResult> GetOrdersByNameAsync(string name)
        {
            var ordersByName = await ordersService.GetOrdersByNameAsync(name);

            if(ordersByName.isSuccess)
            {
                return Ok(ordersByName.orders);
            }

            return NotFound();
        }

        [HttpPost("product/create")]
        public async Task<IActionResult> CreateProductAsync(ProductsDTO product)
        {
            var createProduct = await productsService.CreateProductAsync(product);

            if (createProduct.isSuccess)
            {
                return Ok(createProduct.statusMessage);
            }

            return BadRequest();
        }

        [HttpPost("provider/create")]
        public async Task<IActionResult> CreateProviderAsync(ProvidersDTO provider)
        {
            var createProvider = await providersService.CreateProviderAsync(provider);

            if (createProvider.isSuccess)
            {
                return Ok(createProvider.statusMessage);
            }

            return BadRequest();
        }

        [HttpPost("order/create")]
        public async Task<IActionResult> CreateOrderAsync(OrdersDTO order)
        {
            var createProvider = await ordersService.CreateOrderAsync(order);

            if (createProvider.isSuccess)
            {
                return Ok(createProvider.statusMessage);
            }

            return BadRequest();
        }

        /*[HttpGet("orders/date/{date}")]
        public async Task<IActionResult> GetOrdersByDateAsync(string date)
        {
            var ordersByDate = await ordersService.GetOrdersByDateAsync(date);

            if(ordersByDate.isSuccess)
            {
                return Ok(ordersByDate.orders);
            }

            return NotFound();
        }*/
    }
}