using BleApi.Dtos;
using BleApi.Interfaces;
using BleApi.Context;
using BleApi.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BleApi.Service
{
    class OrdersService : IOrdersService
    {
        private readonly BleDbContext dbContext;
        private readonly ILogger<ProductsService> logger;
        private readonly IMapper mapper;


        public OrdersService(BleDbContext dbContext, ILogger<ProductsService> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<(bool isSuccess, IEnumerable<OrdersDTO> orders, string errorMessage)> GetAllOrdersAsync()
        {
            try
            {
                var allOrders = await dbContext.Orders.ToListAsync();

                if (allOrders != null && allOrders.Any())
                {
                    var ordersMapped = mapper.Map<IEnumerable<BleApi.Model.Orders>, IEnumerable<OrdersDTO>>(allOrders);
                    
                    return (true, ordersMapped, "");
                }

                return(false, null, "You don't have any orders at the moment, orders not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return(false, null, ex.Message);
            }
        }

/*      public async Task<(bool isSuccess, IEnumerable<OrdersDTO> orders, string errorMessage)> GetOrdersByDateAsync(string date)
        {
            try
            {
                var searchOrdersByDate = dbContext.Orders.Where(orders => orders.order_date.ToString().Contains(date));
                var ordersByDate = await searchOrdersByDate.ToListAsync();

                if (ordersByDate != null)
                {
                    var mappedOrders = mapper.Map<IEnumerable<Orders>, IEnumerable<OrdersDTO>>(ordersByDate);

                    return(true, mappedOrders, "");
                }

                return(false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return(false, null, ex.Message);
            }
        } */

        public async Task<(bool isSuccess, OrdersDTO orders, string errorMessage)> GetOrdersByIdAsync(int id)
        {

            try
            {
                var orderByIdAsync = await dbContext.Orders.FirstOrDefaultAsync(orders => orders.order_id == id);

                if (orderByIdAsync != null)
                {
                    var mappedOrder = mapper.Map<Orders, OrdersDTO>(orderByIdAsync);

                    return(true, mappedOrder, "");
                }

                return(false, null, "Not Found");
            }
            catch (Exception ex)
            {

                logger?.LogError(ex.ToString());

                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, IEnumerable<OrdersDTO> orders , string errorMessage)> GetOrdersByNameAsync(string name)
        {
           try
           {
                var searchOrderByName = dbContext.Orders.Where(orders => orders.order_name.Contains(name));
                var orderByName = await searchOrderByName.ToListAsync();

                if (orderByName != null)
                {
                    var mappedOrder = mapper.Map<IEnumerable<Orders>, IEnumerable<OrdersDTO>>(orderByName);
                    return(true, mappedOrder, "");
                }

                return(false, null, "Not Found");
           }
           catch (Exception ex)
           {
            
                logger?.LogError(ex.ToString());
                return(false, null, ex.Message);
            
           }
        }

        public async Task<(bool isSuccess, string statusMessage)> CreateOrderAsync(OrdersDTO order)
        {
            try
            {
                var searchIfExists = dbContext.Orders.Any(ordersEntity => ordersEntity.order_id == order.order_id);

                if (!searchIfExists)
                {
                    var mappedOrders = mapper.Map<Orders>(order);
                        dbContext.Orders.Add(mappedOrders);
                        await dbContext.SaveChangesAsync();
                    return(true, "Order Created"); 
                }

                return(false, "Order Not Created");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return(false, ex.Message);
            }
        }
    }
}