using AppForPryaniky.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace AppForPryaniky.Models.Repositories
{
    public class OrderRepository
    {
        private ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> Get()
        {
            return _context.Orders.Include(x => x.OrderProducts);
        }

        public Order? Get(int id)
        {
            return _context.Orders.Include(x => x.OrderProducts).FirstOrDefault(x => x.Id == id);
        }

        public Order Create(int[] ids)
        {
            Order item = new Order();

            item.CreatedAt = DateTime.Now;

            item.OrderProducts.AddRange(_context.Products.Where(x => ids.Contains(x.Id)).Select(x => new OrderProduct() { ProductId = x.Id}));

            _context.Orders.Add(item);
            _context.SaveChanges();

            return item;
        }

        public Order Delete(int id)
        {
            Order? item = Get(id);

            if (item != null)
            {
                _context.Orders.Remove(item);
                _context.SaveChanges();
            }

            return item;
        }
    }
}
