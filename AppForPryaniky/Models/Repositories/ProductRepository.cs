using AppForPryaniky.Models.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AppForPryaniky.Models.Repositories
{
    public class ProductRepository
    {
        private ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Get()
        {
            return _context.Products.Include(x => x.OrderProducts);
        }

        public Product? Get(int id)
        {
            return _context.Products.Include(x => x.OrderProducts).FirstOrDefault(x => x.Id == id);
        }

        public void Create(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public Product Delete(int id)
        {
            Product? item = Get(id);

            if (item != null)
            {
                _context.Products.Remove(item);

                _context.SaveChanges();
            }

            return item;
        }
    }
}
