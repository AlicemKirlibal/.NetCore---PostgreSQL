using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using testapitsoft.Core.Data.Entity;
using testapitsoft.Core.Data.Repository;
using testapitsoft.Core.Dtos;
using testapitsoft.Core.Service;

namespace testapitsoft.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> AddAsync(OrderDto entity)
        {
            var addedOrder = await _orderRepository.AddAsync(new Order
            {
                //CustomerId = entity.CustomerId,
                CustomerUsername = entity.CustomerUsername,
                OrderCode = entity.OrderCode,
                OrderId = entity.OrderId,
                OrderTotalPrice = entity.OrderTotalPrice
            });
            var response = new OrderDto
            {
                CustomerId = addedOrder.CustomerId,
                OrderTotalPrice = addedOrder.OrderTotalPrice,
                CustomerUsername = addedOrder.CustomerUsername,
                OrderCode = addedOrder.OrderCode,
                OrderId = addedOrder.OrderId
            };

            return response;
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();

            var response = orders.Select(i => new OrderDto
            {
                CustomerId = i.CustomerId,
                CustomerUsername = i.CustomerUsername,
                OrderCode = i.OrderCode,
                OrderId = i.OrderId,
                OrderTotalPrice = i.OrderTotalPrice
            }).ToList();

            return response;
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(i => i.CustomerId == id);

            var response = new OrderDto
            {
                //CustomerId = order.CustomerId,
                OrderCode = order.OrderCode,
                CustomerUsername = order.CustomerUsername,
                OrderId = order.OrderId,
                OrderTotalPrice = order.OrderTotalPrice
            };
            return response;

        }

        public async Task<OrderDto> UpdateAsync(OrderDto orderDto)
        {
            var orders = await _orderRepository.UpdateAsync(new Order
            {
                CustomerId = orderDto.CustomerId,
                CustomerUsername = orderDto.CustomerUsername,
                OrderCode = orderDto.OrderCode,
                OrderId = orderDto.OrderId,
                OrderTotalPrice = orderDto.OrderTotalPrice
            });

            var response = new OrderDto
            {
                CustomerUsername = orders.CustomerUsername,
                CustomerId = orders.CustomerId,
                OrderTotalPrice = orders.OrderTotalPrice,
                OrderCode = orders.OrderCode,
                OrderId = orders.OrderId
            };
            return response;
        }

        public async Task DeleteAsync(OrderDto orderDto)
        {
            await _orderRepository.DeleteAsync(
                new Order
            {
                 CustomerId=orderDto.CustomerId,
                 CustomerUsername=orderDto.CustomerUsername,
                 OrderCode=orderDto.OrderCode,
                 OrderId=orderDto.OrderId,
                 OrderTotalPrice=orderDto.OrderTotalPrice
            });
        }



    }
}
