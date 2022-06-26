using System.Text.Json;
using VirtualShop.Web.Models;

namespace VirtualShop.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string apiEndpoint = "/api/product/";
        private readonly JsonSerializerOptions _optionsJson;
        private ProductViewModel _productViewModel;
        private IEnumerable<ProductViewModel> _productsVM;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _optionsJson = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public Task<ProductViewModel> CreateProduct(ProductViewModel productVM)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> FindProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductViewModel>> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> UpdateProduct(ProductViewModel productVM)
        {
            throw new NotImplementedException();
        }
    }
}
