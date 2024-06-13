namespace AppForPryaniky.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
