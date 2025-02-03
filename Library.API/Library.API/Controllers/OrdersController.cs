using Library.API.Contracts;
using Library.Domain.Abstractions;
using Library.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrdersResponce>>> GetAllOrders() 
        {
            var orders = await _orderService.GetAll();
            var responce = orders.Select(o => new OrdersResponce(o.Id, o.UserId, o.BookId));
            return Ok(responce);
        }

        [HttpGet("by-userId/{userId:guid}")]
        public async Task<ActionResult<List<OrdersResponce>>> GetOrderByUserId(Guid userId) 
        {
            var orders = await _orderService.GetByUserId(userId);
            var responce = orders.Select(o => new OrdersResponce(o.Id, userId, o.BookId));
            return Ok(responce);
        }

        [HttpGet("by-bookId/{bookId:guid}")]
        public async Task<ActionResult<List<OrdersResponce>>> GetOrderByBookId(Guid bookId)
        {
            var orders = await _orderService.GetByBookId(bookId);
            var responce = orders.Select(o => new OrdersResponce(o.Id, o.UserId, bookId));
            return Ok(responce);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNewOrder([FromBody] OrdersRequest ordersRequest) 
        {
            var (order, error) = Order.CreateOrder(Guid.NewGuid(), ordersRequest.userId, ordersRequest.bookId);
            if (!string.IsNullOrEmpty(error)) 
            {
                return BadRequest(error);
            }

            await _orderService.CreateOrder(order);

            return Ok(order.Id);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteOrder(Guid id)
        {
            return Ok(await _orderService.DeleteOrder(id));
        }
    }
}
