using asp.net_task2.Entities;
using Microsoft.EntityFrameworkCore;

namespace asp.net_task2.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
