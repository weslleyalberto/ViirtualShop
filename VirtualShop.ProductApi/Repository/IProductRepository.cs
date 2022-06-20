using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Repository
{
    public interface IProductRepository : IDisposable
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);  
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(int id);
    }
}
