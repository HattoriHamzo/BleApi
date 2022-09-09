using BleApi.Dtos;

namespace BleApi.Interfaces
{
    public interface IBleService
    {

        /*--- GET METHODS ---*/
        Task<(bool isSuccess, IEnumerable<ProductsDTO> products, string errorMessage)>GetAllProductsAsync();
        Task<(bool isSuccess, IEnumerable<ProvidersDTO> providers, string errorMessage)>GetAllProvidersAsync();
        Task<(bool isSuccess, IEnumerable<OrdersDTO> orders, string errorMessage)>GetAllOrdersAsync();

        Task<(bool isSuccess, ProductsDTO products, string errorMessage)>GetProductsByIdAsync(int id);
        Task<(bool isSuccess, ProvidersDTO providers, string errorMessage)>GetProvidersByIdAsync(int id);
        Task<(bool isSuccess, OrdersDTO orders, string errorMessage)>GetOrdersByIdAsync(int id);

        Task<(bool isSuccess, IEnumerable<ProductsDTO> products, string errorMessage)>GetProductsByNameAsync(string name);
        Task<(bool isSuccess, ProvidersDTO providers, string errorMessage)>GetProvidersByNameAsync(string name);
        Task<(bool isSuccess, OrdersDTO orders, string errorMessage)>GetOrdersByNameAsync(string name);
        Task<(bool isSuccess, OrdersDTO orders, string errorMessage)>GetOrdersByDateAsync(DateOnly date);

    }
}