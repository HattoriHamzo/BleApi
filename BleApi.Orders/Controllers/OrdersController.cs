using BleApi.Orders.Interfaces;
using BleApi.Orders.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BleApi.Orders.Controllers
{
    [ApiController]
    [Route("api/ble")]
    public class BleController : ControllerBase
    {
        private readonly IOrdersService ordersService;

        public BleController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var allOrders = await ordersService.GetAllOrdersAsync();

            if (allOrders.isSuccess)
            {
                return Ok(allOrders.orders);
            }

            return NotFound();
        }

        [HttpGet("orders/searchID/{id}")]
        public async Task<IActionResult> GetOrdersByIdAsync(int id)
        {
            var orderById = await ordersService.GetOrdersByIdAsync(id);

            if(orderById.isSuccess)
            {
                return Ok(orderById.orders);
            }

            return NotFound();
        }

        [HttpGet("orders/searchName/{name}")]
        public async Task<IActionResult> GetOrdersByNameAsync(string name)
        {
            var ordersByName = await ordersService.GetOrdersByNameAsync(name);

            if(ordersByName.isSuccess)
            {
                return Ok(ordersByName.orders);
            }

            return NotFound();
        }

        [HttpPost("order/create")]
        public async Task<IActionResult> CreateOrderAsync(OrdersDTO order)
        {
            var createProvider = await ordersService.CreateOrderAsync(order);

            if (createProvider.isSuccess)
            {
                return Ok(createProvider.statusMessage);
            }

            return BadRequest();
        }

        /*[HttpGet("orders/date/{date}")]
        public async Task<IActionResult> GetOrdersByDateAsync(string date)
        {
            var ordersByDate = await ordersService.GetOrdersByDateAsync(date);

            if(ordersByDate.isSuccess)
            {
                return Ok(ordersByDate.orders);
            }

            return NotFound();
        }*/
    }
}