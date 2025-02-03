using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstractions
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll();
        Task<List<Order>> GetByUserId(Guid userId);
        Task<List<Order>> GetByBookId(Guid bookId);
        Task<Guid> CreateOrder(Order order);
        Task<Guid> DeleteOrder(Guid orderId);
    }
}
