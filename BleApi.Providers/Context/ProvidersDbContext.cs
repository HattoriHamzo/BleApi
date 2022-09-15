using Microsoft.EntityFrameworkCore;
using BleApi.Providers.Model;

namespace BleApi.Providers.Context
{
    public class ProvidersDbContext : DbContext
    {
        public DbSet<Model.Providers> Providers { get; set; }
        public ProvidersDbContext(DbContextOptions<ProvidersDbContext> options) : base (options)
        {
            //Empty Constructor
        }
    }
}