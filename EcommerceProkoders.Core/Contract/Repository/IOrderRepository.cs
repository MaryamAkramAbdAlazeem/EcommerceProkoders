using EcommerceProkoders.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProkoders.Core.Contract.Repository
{
    public interface IOrderRepository: IGenericRepository<Order>
    {

        Task<Order> GetOrderByIdAsync(int orderId);
        Task<List<Order>> GetAllOrdersAsync();
     
       
    }
}
