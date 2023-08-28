using Bangazon.Models;
using Microsoft.EntityFrameworkCore;

namespace Bangazon
{
    public class BangazonDbContext : DbContext
    {
        public DbSet<Seller>? Sellers { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<PaymentType>? PaymentTypes { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<ProductCategory>? ProductCategories { get; set; }


        public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed data for customer
            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer { CustomerId = 1, Username = "Bob Smith"},
                new Customer { CustomerId = 2, Username = "Jane Doe"}
            });
            // seed data for product
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product { ProductId = 1, ProductCategoryId = 1, Title = "How to Scam People", Description = "A really great read!", QuantityAvailable = 10, PricePerUnit = 14.99m, SellerId = 1},
                new Product { ProductId = 2, ProductCategoryId = 2, Title = "Soccer Ball", Description = "Soccer ball made for legends only", QuantityAvailable = 20, PricePerUnit = 29.99m, SellerId = 1},
                new Product { ProductId = 3, ProductCategoryId = 3, Title = "Banana Phone", Description = "Make your phone calls more A-peeling", QuantityAvailable = 30, PricePerUnit = 9.99m, SellerId = 2}
            });
            // seed data for seller
            modelBuilder.Entity<Seller>().HasData(new Seller[]
            {
                new Seller { SellerId = 1, StoreName = "Store 1"},
                new Seller { SellerId = 2, StoreName = "Store 2"}
            });
            // seed data for payment types
            modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
            {
                new PaymentType { PaymentTypeId = 1, Type = "Credit Card", CustomerId = 1},
                new PaymentType { PaymentTypeId = 2, Type = "PayPal", CustomerId= 2}
            });
            // seed data for orders
            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                new Order { OrderId = 1, CustomerId = 1, SellerId = 1, PaymentTypeId = 1},
                new Order { OrderId = 2, CustomerId = 2, SellerId = 2, PaymentTypeId = 2}
            });
            // seed data for product categories
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory[]
            {
                new ProductCategory { ProductCategoryId = 1, Name = "Books"},
                new ProductCategory { ProductCategoryId = 2, Name = "Sports"},
                new ProductCategory { ProductCategoryId = 3, Name = "Other"}
            });

        }
    }
}