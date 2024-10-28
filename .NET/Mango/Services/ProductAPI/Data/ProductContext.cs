using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    Name = "First Product",
                    CategoryName = "Test",
                    Description = "Test",
                    ImageLocalPath = null,
                    ImageUrl = null,
                    Price = 9999
                });
        }
    }
}
