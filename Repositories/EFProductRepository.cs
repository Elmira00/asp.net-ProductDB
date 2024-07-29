using asp.net_task2.Data;
using asp.net_task2.Entities;
using Microsoft.EntityFrameworkCore;

namespace asp.net_task2.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public EFProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync(string key)
        {
            return await _context.Products.Where(i => i.Id.ToString() == key).ToListAsync();
        }

    }
}
