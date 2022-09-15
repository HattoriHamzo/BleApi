using BleApi.Orders.Dtos;

namespace BleApi.Orders.Interfaces
{
    public interface IOrdersService
    {

        /*--- GET METHODS ---*/
        Task<(bool isSuccess, IEnumerable<OrdersDTO> orders, string errorMessage)>GetAllOrdersAsync();
        Task<(bool isSuccess, OrdersDTO orders, string errorMessage)>GetOrdersByIdAsync(int id);
        Task<(bool isSuccess, IEnumerable<OrdersDTO> orders, string errorMessage)>GetOrdersByNameAsync(string name);
        //Task<(bool isSuccess, IEnumerable<OrdersDTO> orders, string errorMessage)>GetOrdersByDateAsync(string date);

        /*--- POST METHODS ---*/
        Task<(bool isSuccess, string statusMessage)>CreateOrderAsync(OrdersDTO order);
    }
}