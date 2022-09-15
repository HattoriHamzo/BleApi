using BleApi.Products.Dtos;

namespace BleApi.Products.Interfaces
{
    public interface IProductsService 
    { 

        /*--- GET METHODS ---*/
        Task<(bool isSuccess, IEnumerable<ProductsDTO> products, string errorMessage)>GetAllProductsAsync();
        Task<(bool isSuccess, ProductsDTO products, string errorMessage)>GetProductsByIdAsync(int id);
        Task<(bool isSuccess, IEnumerable<ProductsDTO> products, string errorMessage)>GetProductsByNameAsync(string name);

        /*--- POST METHODS ---*/
        Task<(bool isSuccess, string statusMessage)>CreateProductAsync(ProductsDTO product);

    }
}