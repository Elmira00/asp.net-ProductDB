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
        public async Task DeleteAsync(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task UpdateAsync(int id, Product updatedProduct)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Discount = updatedProduct.Discount;
            product.Price = updatedProduct.Price;
            product.ImagePath = updatedProduct.ImagePath;

            _context.Entry(product).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
