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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly EcommerceContext _context;

        public OrderRepository(EcommerceContext context) : base(context)
        {
            _context = context;
        }

       

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ToListAsync();

        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders.Include(o => o.OrderItems).ThenInclude(x=>x.Product).FirstOrDefaultAsync(x => x.Id == orderId);
        }

      
    }
}
