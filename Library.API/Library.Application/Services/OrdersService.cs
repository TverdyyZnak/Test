using Library.Domain.Abstractions;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class OrdersService : IOrderService
    {
        private readonly IOrderRepositiry _orderRepositiry;
        public OrdersService(IOrderRepositiry orderRepositiry)
        {
            _orderRepositiry = orderRepositiry;
        }

        public async Task<List<Order>> GetAll() 
        {
            return await _orderRepositiry.GetAll();
        }

        public async Task<List<Order>> GetByUserId(Guid userId) 
        {
            return await _orderRepositiry.GetByUserId(userId);
        }

        public async Task<List<Order>> GetByBookId(Guid bookId)
        {
            return await _orderRepositiry.GetByBookId(bookId);
        }

        public async Task<Guid> CreateOrder(Order order) 
        {
            return await _orderRepositiry.CreateOrder(order);
        }

        public async Task<Guid> DeleteOrder(Guid id)
        {
            return await _orderRepositiry.DeleteOrder(id);
        }
    }
}
