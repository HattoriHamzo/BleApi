using Microsoft.EntityFrameworkCore;
using BleApi.Products.Model;

namespace BleApi.Products.Context
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Model.Products> Products { get; set; }
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base (options)
        {
            //Empty Constructor
        }
    }
}