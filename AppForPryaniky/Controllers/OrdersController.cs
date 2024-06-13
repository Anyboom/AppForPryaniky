using Microsoft.AspNetCore.Mvc;
using AppForPryaniky.Models;
using AppForPryaniky.Models.Repositories;

namespace AppForPryaniky.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly OrderRepository _context;

        public OrdersController(OrderRepository context)
        {
            _context = context;
        }

        [HttpGet("All")]
        public JsonResult All()
        {
            IEnumerable<Order> orders = _context.Get();

            return Json(orders);
        }

        [HttpPost("Create")]
        public JsonResult Create(int[] products)
        {
            Order order = _context.Create(products);

            return Json(order);
        }

        [HttpDelete("Delete/{id:int}")]
        public JsonResult Delete(int id)
        {
            Order product = _context.Delete(id);

            return Json(product);
        }
    }
}
