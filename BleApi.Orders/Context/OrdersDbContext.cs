using Microsoft.EntityFrameworkCore;
using BleApi.Orders.Model;

namespace BleApi.Orders.Context
{
        public class OrdersDbContext : DbContext
    {
        public DbSet<Model.Orders> Orders { get; set; }
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base (options)
        {
            //Empty Constructor
        }
    }
}