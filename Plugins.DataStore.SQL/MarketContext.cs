using CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace Plugins.DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions opt) : base(opt)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MyTransaction> MyTransactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(p => p.CategoryID);

            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryID = 1, Name = "Beverage", Description = "Beverage" },
                new Category() { CategoryID = 2, Name = "Bakery", Description = "Bakery" },
                new Category() { CategoryID = 3, Name = "Meat", Description = "Meat" },
                new Category() { CategoryID = 4, Name = "Dessert", Description = "Dessert" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, CategoryID = 1, Name = "Ice Tea", Quantity = 100, Price = 1.99 },
                new Product { ProductID = 2, CategoryID = 1, Name = "Canada Dry", Quantity = 200, Price = 1.99 },
                new Product { ProductID = 3, CategoryID = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50 },
                new Product { ProductID = 4, CategoryID = 2, Name = "White Bread", Quantity = 300, Price = 1.50 }
                );
        }
    }
}
