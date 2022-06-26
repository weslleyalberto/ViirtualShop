using VirtualShop.Web.Models;

namespace VirtualShop.Web.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProduct();
        Task<ProductViewModel> FindProductById(int id);
        Task<ProductViewModel> CreateProduct(ProductViewModel productVM); 
        Task<ProductViewModel> UpdateProduct(ProductViewModel productVM);
        Task<bool> DeleteProductById(int id);
    }
}
