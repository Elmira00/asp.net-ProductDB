using asp.net_task2.Entities;
namespace asp.net_task2.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, Product updatedProduct);
        Task<List<Product>> GetAllAsync();

    }
}
