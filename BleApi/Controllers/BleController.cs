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

        [HttpGet("/products")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var allProducts = await bleService.GetAllProductsAsync();

            if (allProducts.isSuccess)
            {
                return Ok(allProducts.products);
            }

            return NotFound();
        }

        [HttpGet("/providers")]
        public async Task<IActionResult> GetAllProvidersAsync()
        {
            var allProviders = await bleService.GetAllProvidersAsync();

            if(allProviders.isSuccess)
            {
                return Ok(allProviders.providers);
            }

            return NotFound();
        }

        [HttpGet("/orders")]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var allOrders = await bleService.GetAllOrdersAsync();

            if (allOrders.isSuccess)
            {
                return Ok(allOrders.orders);
            }

            return NotFound();
        }

        [HttpGet("/products/{id}")]
        public async Task<IActionResult> GetProductsByIdAsync(int id)
        {
            var productById = await bleService.GetProductsByIdAsync(id);

            if (productById.isSuccess)
            {
                return Ok(productById.products);
            }

            return NotFound();
        }
    }
}