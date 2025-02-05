using Library.DataAccess.Entites;
using Library.Domain.Abstractions;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepositiry
    {
        private readonly LibraryDbContext _context;

        public OrderRepository(LibraryDbContext libraryDbContext)
        {
            _context = libraryDbContext;
        }

        public async Task<List<Order>> GetAll() 
        {
            var orderEntities = await _context.Order.AsNoTracking().ToListAsync();

            var orders = orderEntities.Select(o => Order.CreateOrder(o.Id, o.UserId, o.BookId).order).ToList();
            return orders;
        }

        public async Task<List<Order>> GetByUserId(Guid userId) 
        {
            var orderEntities = await _context.Order.AsNoTracking().ToListAsync();
            var orders = orderEntities.Select(o => Order.CreateOrder(o.Id, o.UserId, o.BookId).order).Where(o => o.UserId == userId).ToList();
            return orders;
        }
            
        public async Task<List<Order>> GetByBookId(Guid bookId)
        {
            var orderEntities = await _context.Order.AsNoTracking().ToListAsync();
            var orders = orderEntities.Select(o => Order.CreateOrder(o.Id, o.UserId, o.BookId).order).Where(o => o.BookId == bookId).ToList();
            return orders;
        }


        public async Task<Guid> CreateOrder(Order order) 
        {
            var newOrder = new OrderEntity
            {
                Id = order.Id,
                UserId = order.UserId,
                BookId = order.BookId
            };

            await _context.AddAsync(newOrder);

            return newOrder.Id;
        }

        public async Task<Guid> DeleteOrder(Guid id) 
        {
            await _context.Order.Where(o => o.Id == id).ExecuteDeleteAsync();
            return id;
        }
    }
}
