using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductApi.Context;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
           _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Delete(int id)
        {
            var produto = await GetById(id);
            _context.Remove(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public void Dispose()
        {
            _context?.Dispose();    
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
