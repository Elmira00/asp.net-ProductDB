using asp.net_task2.Entities;

namespace asp.net_task2.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllByKeyAsync(string key = "");
        Task AddAsync(Product product);
        Task DeleteAsync(int id);
    }
}
