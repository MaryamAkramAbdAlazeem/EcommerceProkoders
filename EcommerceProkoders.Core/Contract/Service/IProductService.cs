using EcommerceProkoders.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProkoders.Core.Contract.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync(int page, int pageSize);
        Task<List<Product>> GetProductsAsync(string? modelNameFilter);
        Task<Product?> GetProductDetailsAsync(int id);
        Task<Product> AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
