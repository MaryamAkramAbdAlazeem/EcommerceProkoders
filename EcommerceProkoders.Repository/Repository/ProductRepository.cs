using EcommerceProkoders.Core.Contract.Repository;
using EcommerceProkoders.Core.Entities;
using EcommerceProkoders.DB.Repository;
using EcommerceProkoders.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProkoders.Repository.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly EcommerceContext _context;
        public ProductRepository(EcommerceContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync(string? modelNameFilter)
        {
           return await _context.Products.Where(x=>x.Name == modelNameFilter).ToListAsync();
          
        }
    }
}
