// <auto-generated />
using System;
using Bangazon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bangazon.Migrations
{
    [DbContext(typeof(BangazonDbContext))]
    [Migration("20230830010342_updated")]
    partial class updated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bangazon.Models.Customer", b =>
            {
                b.Property<int>("CustomerId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomerId"));

                b.Property<string>("Username")
                    .HasColumnType("text");

                b.HasKey("CustomerId");

                b.ToTable("Customers");

                b.HasData(
                    new
                    {
                        CustomerId = 1,
                        Username = "Bob Smith"
                    },
                    new
                    {
                        CustomerId = 2,
                        Username = "Jane Doe"
                    });
            });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
            {
                b.Property<int>("OrderId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                b.Property<int>("CustomerId")
                    .HasColumnType("integer");

                b.Property<int>("PaymentTypeId")
                    .HasColumnType("integer");

                b.Property<int>("SellerId")
                    .HasColumnType("integer");

                b.HasKey("OrderId");

                b.HasIndex("CustomerId");

                b.HasIndex("PaymentTypeId");

                b.HasIndex("SellerId");

                b.ToTable("Orders");

                b.HasData(
                    new
                    {
                        OrderId = 1,
                        CustomerId = 1,
                        PaymentTypeId = 1,
                        SellerId = 1
                    },
                    new
                    {
                        OrderId = 2,
                        CustomerId = 2,
                        PaymentTypeId = 2,
                        SellerId = 2
                    });
            });

            modelBuilder.Entity("Bangazon.Models.Order_Product", b =>
            {
                b.Property<int>("ProductId")
                    .HasColumnType("integer");

                b.Property<int>("OrderId")
                    .HasColumnType("integer");

                b.Property<int>("Id")
                    .HasColumnType("integer");

                b.HasKey("ProductId", "OrderId");

                b.HasIndex("OrderId");

                b.ToTable("Ordered_Products");

                b.HasData(
                    new
                    {
                        ProductId = 1,
                        OrderId = 1,
                        Id = 1
                    },
                    new
                    {
                        ProductId = 2,
                        OrderId = 2,
                        Id = 2
                    },
                    new
                    {
                        ProductId = 3,
                        OrderId = 2,
                        Id = 3
                    });
            });

            modelBuilder.Entity("Bangazon.Models.PaymentType", b =>
            {
                b.Property<int>("PaymentTypeId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PaymentTypeId"));

                b.Property<int>("CustomerId")
                    .HasColumnType("integer");

                b.Property<string>("Details")
                    .HasColumnType("text");

                b.Property<string>("Type")
                    .HasColumnType("text");

                b.HasKey("PaymentTypeId");

                b.HasIndex("CustomerId");

                b.ToTable("PaymentTypes");

                b.HasData(
                    new
                    {
                        PaymentTypeId = 1,
                        CustomerId = 1,
                        Details = "This is a credit card",
                        Type = "Credit Card"
                    },
                    new
                    {
                        PaymentTypeId = 2,
                        CustomerId = 2,
                        Details = "This is PayPal",
                        Type = "PayPal"
                    });
            });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
            {
                b.Property<int>("ProductId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                b.Property<int?>("CustomerId")
                    .HasColumnType("integer");

                b.Property<string>("Description")
                    .HasColumnType("text");

                b.Property<int?>("OrderId")
                    .HasColumnType("integer");

                b.Property<decimal>("PricePerUnit")
                    .HasColumnType("numeric");

                b.Property<int?>("ProductCategoryId")
                    .HasColumnType("integer");

                b.Property<int>("QuantityAvailable")
                    .HasColumnType("integer");

                b.Property<int>("SellerId")
                    .HasColumnType("integer");

                b.Property<string>("Title")
                    .HasColumnType("text");

                b.HasKey("ProductId");

                b.HasIndex("CustomerId");

                b.HasIndex("OrderId");

                b.HasIndex("ProductCategoryId");

                b.HasIndex("SellerId");

                b.ToTable("Products");

                b.HasData(
                    new
                    {
                        ProductId = 1,
                        Description = "A really great read!",
                        PricePerUnit = 14.99m,
                        QuantityAvailable = 10,
                        SellerId = 1,
                        Title = "How to Scam People"
                    },
                    new
                    {
                        ProductId = 2,
                        Description = "Soccer ball made for legends only",
                        PricePerUnit = 29.99m,
                        QuantityAvailable = 20,
                        SellerId = 1,
                        Title = "Soccer Ball"
                    },
                    new
                    {
                        ProductId = 3,
                        Description = "Make your phone calls more A-peeling",
                        PricePerUnit = 9.99m,
                        QuantityAvailable = 30,
                        SellerId = 2,
                        Title = "Banana Phone"
                    });
            });

            modelBuilder.Entity("Bangazon.Models.ProductCategory", b =>
            {
                b.Property<int>("ProductCategoryId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductCategoryId"));

                b.Property<string>("Name")
                    .HasColumnType("text");

                b.HasKey("ProductCategoryId");

                b.ToTable("ProductCategories");

                b.HasData(
                    new
                    {
                        ProductCategoryId = 1,
                        Name = "Books"
                    },
                    new
                    {
                        ProductCategoryId = 2,
                        Name = "Sports"
                    },
                    new
                    {
                        ProductCategoryId = 3,
                        Name = "Other"
                    });
            });

            modelBuilder.Entity("Bangazon.Models.Seller", b =>
            {
                b.Property<int>("SellerId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SellerId"));

                b.Property<string>("StoreName")
                    .HasColumnType("text");

                b.HasKey("SellerId");

                b.ToTable("Sellers");

                b.HasData(
                    new
                    {
                        SellerId = 1,
                        StoreName = "Store 1"
                    },
                    new
                    {
                        SellerId = 2,
                        StoreName = "Store 2"
                    });
            });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
            {
                b.HasOne("Bangazon.Models.Customer", "Customer")
                    .WithMany("OrderHistory")
                    .HasForeignKey("CustomerId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Bangazon.Models.PaymentType", "PaymentType")
                    .WithMany()
                    .HasForeignKey("PaymentTypeId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Bangazon.Models.Seller", "Seller")
                    .WithMany()
                    .HasForeignKey("SellerId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Customer");

                b.Navigation("PaymentType");

                b.Navigation("Seller");
            });

            modelBuilder.Entity("Bangazon.Models.Order_Product", b =>
            {
                b.HasOne("Bangazon.Models.Order", "Order")
                    .WithMany("Ordered_Products")
                    .HasForeignKey("OrderId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Bangazon.Models.Product", "Product")
                    .WithMany("Ordered_Products")
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Order");

                b.Navigation("Product");
            });

            modelBuilder.Entity("Bangazon.Models.PaymentType", b =>
            {
                b.HasOne("Bangazon.Models.Customer", "Customer")
                    .WithMany("PaymentTypes")
                    .HasForeignKey("CustomerId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Customer");
            });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
            {
                b.HasOne("Bangazon.Models.Customer", null)
                    .WithMany("Cart")
                    .HasForeignKey("CustomerId");

                b.HasOne("Bangazon.Models.Order", null)
                    .WithMany("Products")
                    .HasForeignKey("OrderId");

                b.HasOne("Bangazon.Models.ProductCategory", "ProductCategory")
                    .WithMany("Products")
                    .HasForeignKey("ProductCategoryId");

                b.HasOne("Bangazon.Models.Seller", "Seller")
                    .WithMany("Products")
                    .HasForeignKey("SellerId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("ProductCategory");

                b.Navigation("Seller");
            });

            modelBuilder.Entity("Bangazon.Models.Customer", b =>
            {
                b.Navigation("Cart");

                b.Navigation("OrderHistory");

                b.Navigation("PaymentTypes");
            });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
            {
                b.Navigation("Ordered_Products");

                b.Navigation("Products");
            });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
            {
                b.Navigation("Ordered_Products");
            });

            modelBuilder.Entity("Bangazon.Models.ProductCategory", b =>
            {
                b.Navigation("Products");
            });

            modelBuilder.Entity("Bangazon.Models.Seller", b =>
            {
                b.Navigation("Products");
            });
#pragma warning restore 612, 618
        }
    }
}