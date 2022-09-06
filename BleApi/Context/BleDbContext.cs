using Microsoft.EntityFrameworkCore;
using BleApi.Model;

namespace BleApi.Context
{
    public class BleDbContext : DbContext
    {
        public DbSet<Model.Products> Products { get; set; }
        public DbSet<Model.Providers> Providers { get; set; }
        public DbSet<Model.Orders> Orders { get; set; }
        public BleDbContext(DbContextOptions<BleDbContext> options) : base (options)
        {
            //Empty Constructor
        }
    }
}