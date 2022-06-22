using AutoMapper;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Models;
using VirtualShop.ProductApi.Repository;

namespace VirtualShop.ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _produtcRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository produtcRepository, IMapper mapper)
        {
            _produtcRepository = produtcRepository;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _produtcRepository.Create(productEntity);
            productDTO.Id = productEntity.Id;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productentity = await _produtcRepository.GetAll();  
            return _mapper.Map<IEnumerable<ProductDTO>>(productentity);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var productEntity = await _produtcRepository.GetById(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task RemoveProduct(int id)
        {
            var produtoEntity = await _produtcRepository.GetById(id);
           await _produtcRepository.Delete(produtoEntity.Id);
        }

        public async Task UpdateProduct(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _produtcRepository.Update(productEntity);
        }
    }
}
