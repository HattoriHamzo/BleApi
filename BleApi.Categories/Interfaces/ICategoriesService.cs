using BleApi.Categories.Dtos;

namespace BleApi.Categories.Interfaces
{
    public interface ICategoriesService 
    { 

        /*--- GET METHODS ---*/
        Task<(bool isSuccess, IEnumerable<CategoriesDTO> categories, string errorMessage)>GetAllCategoriesAsync();
        Task<(bool isSuccess, CategoriesDTO categories, string errorMessage)>GetCategoriesByIdAsync(int id);
        Task<(bool isSuccess, IEnumerable<CategoriesDTO> categories, string errorMessage)>GetCategoriesByNameAsync(string name);

        /*--- POST METHODS ---*/
        Task<(bool isSuccess, string statusMessage)>CreateCategoryAsync(CategoriesDTO category);

    }
}