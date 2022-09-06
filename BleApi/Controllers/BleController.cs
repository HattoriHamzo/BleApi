using BleApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BleController : ControllerBase
    {
        private readonly IBleService bleService;

        public BleController(IBleService bleService)
        {
            this.bleService = bleService;
        }

        [HttpGet]
        [ActionName("GetAllProducts")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var allProducts = await bleService.GetAllProductsAsync();

            if (allProducts.isSuccess)
            {
                return Ok(allProducts.products);
            }

            return NotFound();
        }

        [HttpGet]
        [ActionName("GetAllProviders")]
        public async Task<IActionResult> GetAllProvidersAsync()
        {
            var allProviders = await bleService.GetAllProvidersAsync();

            if(allProviders.isSuccess)
            {
                return Ok(allProviders.providers);
            }

            return NotFound();
        }

        [HttpGet]
        [ActionName("GetAllOrders")]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var allOrders = await bleService.GetAllOrdersAsync();

            if (allOrders.isSuccess)
            {
                return Ok(allOrders.orders);
            }

            return NotFound();
        }
    }
}