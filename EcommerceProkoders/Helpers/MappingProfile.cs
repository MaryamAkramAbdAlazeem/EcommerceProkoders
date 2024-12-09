using EcommerceProkoders.Core.Entities;
using EcommerceProkoders.DTOs.Products;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using EcommerceProkoders.DTOs.Order;
namespace EcommerceProkoders.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Product, ProductDto>();
            CreateMap<CreateUpdateProductDto, Product>();

            CreateMap<Order, OrderDto>();
            CreateMap<CreateUpdateOrderHeader, Order>();

            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<CreateUpdateOrderItem, OrderItem>();
        }
    }
}
