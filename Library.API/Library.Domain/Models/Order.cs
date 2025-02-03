using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class Order
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid BookId { get; }

        private Order(Guid id, Guid userId, Guid bookId) 
        {
            Id = id;
            UserId = userId;
            BookId = bookId;
        }

        public static (Order order, string error) CreateOrder(Guid id, Guid userId, Guid bookId) 
        {
            var error = string.Empty;

            var order = new Order(id, userId, bookId);
            return (order, error);
        }

    }
}
