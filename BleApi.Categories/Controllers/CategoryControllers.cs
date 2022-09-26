using BleApi.Categories.Interfaces;
using BleApi.Categories.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace BleApi.Categories.Controllers
{
    [ApiController]
    [Route("api/ble")]
    public class CategoryControllers : ControllerBase
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRabitMQProducer rabitMQProducer;

        public CategoryControllers(ICategoriesService categoriesService, IRabitMQProducer rabitMQProducer)
        {
            this.categoriesService = categoriesService;
            this.rabitMQProducer = rabitMQProducer;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var allCategories = await categoriesService.GetAllCategoriesAsync();

            if (allCategories.isSuccess)
            {
                rabitMQProducer.ReceiveProductCreatedQueueMessage();
                return Ok(allCategories.categories);
            }

            return NotFound();
        }

        [HttpGet("categories/searchID/{id}")]
        public async Task<IActionResult> GetCategoriesByIdAsync(int id)
        {
            var categoryById = await categoriesService.GetCategoriesByIdAsync(id);

            if (categoryById.isSuccess)
            {
                return Ok(categoryById.categories);
            }

            return NotFound();
        }


        [HttpGet("categories/searchName/{name}")]
        public async Task<IActionResult> GetCategoriesByNameAsync(string name)
        {
            var categoriesByname = await categoriesService.GetCategoriesByNameAsync(name);

            if (categoriesByname.isSuccess)
            {
                return Ok(categoriesByname.categories);
            }

            return NotFound();
        }


        [HttpPost("category/create")]
        public async Task<IActionResult> CreateCategoryAsync(CategoriesDTO product)
        {
            var createCategory = await categoriesService.CreateCategoryAsync(product);

            if (createCategory.isSuccess)
            {
                return Ok(createCategory.statusMessage);
            }

            return BadRequest();
        }
    }
}


