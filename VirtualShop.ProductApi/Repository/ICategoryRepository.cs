using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Repository
{
    public interface ICategoryRepository : IDisposable
    {
        Task<IEnumerable<Category>> GetAll();
        Task<IEnumerable<Category>> GetCategoriesProducts();
        Task<Category> GetById(int id);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(int id);  
    }
}
