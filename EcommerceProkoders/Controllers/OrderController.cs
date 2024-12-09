using AutoMapper;
using EcommerceProkoders.Core.Contract.Repository;
using EcommerceProkoders.Core.Entities;
using EcommerceProkoders.DTOs.Order;
using EcommerceProkoders.DTOs.Products;
using EcommerceProkoders.Errors;
using EcommerceProkoders.Repository.Migrations;
using EcommerceProkoders.Repository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProkoders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder( CreateUpdateOrderHeader input)
        {
            if (input == null || !input.OrderItems.Any())
                return BadRequest("Invalid order data");

            var orderId = await _orderRepository.AddAsync(_mapper.Map<CreateUpdateOrderHeader, Order>(input));
            var order = await _orderRepository.GetOrderByIdAsync(orderId.Id);
            return Ok(_mapper.Map<Order, OrderDto>(order));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            return Ok(_mapper.Map<Order, OrderDto>(order));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
                return Ok(_mapper.Map<List<Order>, List<OrderDto>>(orders));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] CreateUpdateOrderHeader input)
        {
            var temp = await _orderRepository.GetByIdAsync(id);
            if (temp is null)
                return BadRequest(new ApiResponse(400));
       
           await _orderRepository.UpdateAsync(_mapper.Map(input, temp));


            return Ok(_mapper.Map<Order, OrderDto>(await _orderRepository.GetByIdAsync(id)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
           await _orderRepository.DeleteAsync(id);
           

            return NoContent();
        }
    }
}

