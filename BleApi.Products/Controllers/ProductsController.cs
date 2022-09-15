using BleApi.Products.Interfaces;
using BleApi.Products.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BleApi.Products.Controllers
{
    [ApiController]
    [Route("api/ble")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
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
    }
}