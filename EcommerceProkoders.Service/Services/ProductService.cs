using EcommerceProkoders.Core.Contract.Repository;
using EcommerceProkoders.Core.Contract.Service;
using EcommerceProkoders.Core.Entities;

namespace EcommerceProkoders.Service.Services
{
    public class ProductService : IProductService
    {
       
        public IProductRepository _productRepository{ get; set; }

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        
        }

        public async Task<Product> AddProductAsync(Product product)
        {
          await _productRepository.AddAsync(product);

         return await  GetProductDetailsAsync(product.Id);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<Product?> GetProductDetailsAsync(int id)
        {
         return  await _productRepository.GetByIdAsync(id);
        }

        

        public async Task UpdateProductAsync(Product product)
        {

           await _productRepository.UpdateAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int page, int pageSize)
        {
           return await _productRepository.GetAllAsync(page, pageSize);
        }

        public async Task<List<Product>> GetProductsAsync(string? modelNameFilter)
        {
           return await _productRepository.GetProductsAsync(modelNameFilter);
        }
    }
}
