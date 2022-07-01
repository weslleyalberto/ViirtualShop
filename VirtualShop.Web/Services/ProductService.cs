using System.Text;
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

        public async Task<ProductViewModel> CreateProduct(ProductViewModel productVM)
        {
            var cliente = _httpClientFactory.CreateClient("ProductApi");
            StringContent content = new(JsonSerializer.Serialize(productVM), encoding: Encoding.UTF8, "application/json");
            using (var response = await cliente.PostAsync(apiEndpoint,content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiReponse = await response.Content.ReadAsStreamAsync();
                    _productViewModel = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiReponse, _optionsJson);
                }
                else
                {
                    return null;
                }
            }
            return _productViewModel;
        }

        public async Task<bool> DeleteProductById(int id)
        {
            var cliente = _httpClientFactory.CreateClient("ProductApi");
            using (var response = await cliente.DeleteAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<ProductViewModel> FindProductById(int id)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            using(var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    _productViewModel = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _optionsJson);
                }
                else
                {
                    return null;
                }
            }
            return _productViewModel;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProduct()
        {
            var cliente = _httpClientFactory.CreateClient("ProductApi");
            using(var response = await cliente.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiReponse = await response.Content.ReadAsStreamAsync();
                    _productsVM = await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(apiReponse, _optionsJson);
                }
                else
                {
                    return null;
                }
            }
            return _productsVM;
        }

        public async Task<ProductViewModel> UpdateProduct(ProductViewModel productVM)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            ProductViewModel productUpdated = new();
            using (var response = await client.PutAsJsonAsync(apiEndpoint, productVM))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productUpdated = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _optionsJson);
                }
                else
                {
                    return null;
                }
            }
            return productUpdated;
        }
    }
}
