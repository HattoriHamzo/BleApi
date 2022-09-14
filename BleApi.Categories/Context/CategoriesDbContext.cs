using Microsoft.EntityFrameworkCore;


namespace BleApi.Categories.Context
{
    public class CategoriesDbContext : DbContext
    {
        public DbSet<Model.Categories> Categories { get; set; }
        public CategoriesDbContext(DbContextOptions<CategoriesDbContext> options) : base (options)
        {
            //Empty Constructor
        }
    }
}