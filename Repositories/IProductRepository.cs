using asp.net_task2.Entities;
namespace asp.net_task2.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<List<Product>> GetAllAsync(string key);
    }
}
