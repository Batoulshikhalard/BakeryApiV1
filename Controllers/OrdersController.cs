using BakeryApi.Data;
using BakeryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakeryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly BakeryContext _context;

        public OrdersController(BakeryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(int? orderNumber, string orderDate)
        {
            var query = _context.Orders.AsQueryable();

            if (orderNumber.HasValue)
            {
                query = query.Where(o => o.OrderId == orderNumber.Value);
            }

            if (!string.IsNullOrEmpty(orderDate))
            {
                var date = DateTime.Parse(orderDate);
                query = query.Where(o => o.OrderDate.Date == date.Date);
            }

            return Ok(await query.ToListAsync());
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }
    }
}
