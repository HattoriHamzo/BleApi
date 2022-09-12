using BleApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BleApi.Controllers
{
    [ApiController]
    [Route("api/ble")]
    public class BleController : ControllerBase
    {
        private readonly IBleService bleService;

        public BleController(IBleService bleService)
        {
            this.bleService = bleService;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var allProducts = await bleService.GetAllProductsAsync();

            if (allProducts.isSuccess)
            {
                return Ok(allProducts.products);
            }

            return NotFound();
        }

        [HttpGet("providers")]
        public async Task<IActionResult> GetAllProvidersAsync()
        {
            var allProviders = await bleService.GetAllProvidersAsync();

            if(allProviders.isSuccess)
            {
                return Ok(allProviders.providers);
            }

            return NotFound();
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var allOrders = await bleService.GetAllOrdersAsync();

            if (allOrders.isSuccess)
            {
                return Ok(allOrders.orders);
            }

            return NotFound();
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProductsByIdAsync(int id)
        {
            var productById = await bleService.GetProductsByIdAsync(id);

            if (productById.isSuccess)
            {
                return Ok(productById.products);
            }

            return NotFound();
        }

        [HttpGet("providers/{id}")]
        public async Task<IActionResult> GetProvidersByIdAsync(int id)
        {
            var providerById = await bleService.GetProvidersByIdAsync(id);

            if (providerById.isSuccess)
            {
                return Ok(providerById.providers);
            }

            return NotFound();
        }

        [HttpGet("orders/{id}")]
        public async Task<IActionResult> GetOrdersByIdAsync(int id)
        {
            var orderById = await bleService.GetOrdersByIdAsync(id);

            if(orderById.isSuccess)
            {
                return Ok(orderById.orders);
            }

            return NotFound();
        }

        [HttpGet("products/name/{name}")]
        public async Task<IActionResult> GetProductsByNameAsync(string name)
        {
            var productsByname = await bleService.GetProductsByNameAsync(name);

            if (productsByname.isSuccess)
            {
                return Ok(productsByname.products);
            }

            return NotFound();
        }

        [HttpGet("providers/name/{name}")]
        public async Task<IActionResult> GetProvidersByNameAsync(string name)
        {
            var providersByName = await bleService.GetProvidersByNameAsync(name);

            if(providersByName.isSuccess)
            {
                return Ok(providersByName.providers);
            }

            return NotFound();
        }

        [HttpGet("orders/name/{name}")]
        public async Task<IActionResult> GetOrdersByNameAsync(string name)
        {
            var ordersByName = await bleService.GetOrdersByNameAsync(name);

            if(ordersByName.isSuccess)
            {
                return Ok(ordersByName.orders);
            }

            return NotFound();
        }

        /*[HttpGet("orders/date/{date}")]
        public async Task<IActionResult> GetOrdersByDateAsync(string date)
        {
            var ordersByDate = await bleService.GetOrdersByDateAsync(date);

            if(ordersByDate.isSuccess)
            {
                return Ok(ordersByDate.orders);
            }

            return NotFound();
        }*/
    }
}