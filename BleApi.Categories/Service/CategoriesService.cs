using BleApi.Categories.Dtos;
using BleApi.Categories.Interfaces;
using BleApi.Categories.Context;
using BleApi.Categories.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BleApi.Categories.Service
{
    class CategoriesService : ICategoriesService
    {
        private readonly CategoriesDbContext dbContext;
        private readonly ILogger<CategoriesService> logger;
        private readonly IMapper mapper;


        public CategoriesService(CategoriesDbContext dbContext, ILogger<CategoriesService> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<(bool isSuccess, IEnumerable<CategoriesDTO> categories, string errorMessage)> GetAllCategoriesAsync()
        {
            try
            {
                var allCategories = await dbContext.Categories.ToListAsync();

                if (allCategories != null && allCategories.Any())
                {
                    var mappedCategories = mapper.Map<IEnumerable<BleApi.Categories.Model.Categories>, IEnumerable<CategoriesDTO>>(allCategories);
                    
                    return (true, mappedCategories, "");
                }
                return (false, null, "You don't have any categories at the moment, categories not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());  
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, CategoriesDTO categories, string errorMessage)> GetCategoriesByIdAsync(int id)
        {
            try
            {
                var categoriesById = await dbContext.Categories.FirstOrDefaultAsync(category => category.category_id == id);

                if (categoriesById != null)
                {
                    var mappedCategory = mapper.Map<BleApi.Categories.Model.Categories, CategoriesDTO>(categoriesById);

                    return (true, mappedCategory, null);
                }

                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, IEnumerable<CategoriesDTO> categories, string errorMessage)> GetCategoriesByNameAsync(string name)
        {
            try
            {
                var searchByName = dbContext.Categories.Where(categories => categories.category_name.Contains(name));
                var categoriesByName = await searchByName.ToListAsync();

                if (categoriesByName != null)
                {
                    var mappedCategories = mapper.Map<IEnumerable<BleApi.Categories.Model.Categories>, IEnumerable<CategoriesDTO>>(categoriesByName);
                    
                    return(true, mappedCategories, "");
                }

                return(false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, string statusMessage)> CreateCategoryAsync(CategoriesDTO category)
        {
            try
            {
                var searchIfExists = dbContext.Categories.Any(categoriesEntity => categoriesEntity.category_id == category.category_id);

                if (!searchIfExists)
                {  
                    var mappedCategory = mapper.Map<BleApi.Categories.Model.Categories>(category);
                        dbContext.Categories.Add(mappedCategory);
                        await dbContext.SaveChangesAsync();
                    return (true, "Category Created");
                }
                return (false, "Category Not Created");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, ex.Message);
            }
        }
    }
}