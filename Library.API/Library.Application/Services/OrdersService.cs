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
        private readonly IUnitOfWork _unitOfWork;
        public OrdersService(IOrderRepositiry orderRepositiry, IUnitOfWork unitOfWork)
        {
            _orderRepositiry = orderRepositiry;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Order>> GetAll() 
        {
            return await _unitOfWork.OrderRepositiry.GetAll();
        }

        public async Task<List<Order>> GetByUserId(Guid userId) 
        {
            return await _unitOfWork.OrderRepositiry.GetByUserId(userId);
        }

        public async Task<List<Order>> GetByBookId(Guid bookId)
        {
            return await _unitOfWork.OrderRepositiry.GetByBookId(bookId);
        }

        public async Task<Guid> CreateOrder(Order order) 
        {
            var orderId = await _unitOfWork.OrderRepositiry.CreateOrder(order);
            await _unitOfWork.SaveChangesAsync();
            return orderId;
        }

        public async Task<Guid> DeleteOrder(Guid id)
        {
            return await _unitOfWork.OrderRepositiry.DeleteOrder(id);
        }
    }
}
