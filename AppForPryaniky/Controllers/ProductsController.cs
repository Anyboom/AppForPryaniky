using AppForPryaniky.Models;
using AppForPryaniky.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppForPryaniky.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductRepository _context;

        public ProductsController(ProductRepository context)
        {
            _context = context;
        }

        [HttpGet("All")]
        public JsonResult All()
        {
            IEnumerable<Product> products = _context.Get();

            return Json(products);
        }

        [HttpPost("Create")]
        public JsonResult Create(Product product)
        {
            _context.Create(product);

            return Json(product);
        }

        [HttpDelete("Delete/{id:int}")]
        public JsonResult Delete(int id)
        {
            Product product = _context.Delete(id);

            return Json(product);
        }
    }
}
