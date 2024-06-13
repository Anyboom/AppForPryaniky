using Microsoft.EntityFrameworkCore;

namespace AppForPryaniky.Models.Contexts
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(pc => new { pc.OrderId, pc.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(p => p.Product)
                .WithMany(pc => pc.OrderProducts)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(p => p.Order)
                .WithMany(pc => pc.OrderProducts)
                .HasForeignKey(c => c.OrderId);
        }
    }
}
