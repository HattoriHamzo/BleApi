using BleApi.Providers.Interfaces;
using BleApi.Providers.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BleApi.Providers.Controllers
{
    [ApiController]
    [Route("api/ble")]
    public class ProvidersController : ControllerBase
    {
        private readonly IProvidersService providersService;

        public ProvidersController(IProvidersService providersService)
        {
            this.providersService = providersService;
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
    }
}