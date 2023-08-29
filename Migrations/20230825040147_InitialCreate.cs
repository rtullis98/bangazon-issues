using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bangazon.Migrations
{
	public partial class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Customers",
				columns: table => new
				{
					CustomerId = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Username = table.Column<string>(type: "text", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Customers", x => x.CustomerId);
				});

			migrationBuilder.CreateTable(
				name: "ProductCategories",
				columns: table => new
				{
					ProductCategoryId = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Name = table.Column<string>(type: "text", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ProductCategories", x => x.ProductCategoryId);
				});

			migrationBuilder.CreateTable(
				name: "Sellers",
				columns: table => new
				{
					SellerId = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					StoreName = table.Column<string>(type: "text", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Sellers", x => x.SellerId);
				});

			migrationBuilder.CreateTable(
				name: "PaymentTypes",
				columns: table => new
				{
					PaymentTypeId = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Type = table.Column<string>(type: "text", nullable: true),
					Details = table.Column<string>(type: "text", nullable: true),
					CustomerId = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PaymentTypes", x => x.PaymentTypeId);
					table.ForeignKey(
						name: "FK_PaymentTypes_Customers_CustomerId",
						column: x => x.CustomerId,
						principalTable: "Customers",
						principalColumn: "CustomerId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Orders",
				columns: table => new
				{
					OrderId = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					SellerId = table.Column<int>(type: "integer", nullable: false),
					CustomerId = table.Column<int>(type: "integer", nullable: false),
					PaymentTypeId = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Orders", x => x.OrderId);
					table.ForeignKey(
						name: "FK_Orders_Customers_CustomerId",
						column: x => x.CustomerId,
						principalTable: "Customers",
						principalColumn: "CustomerId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Orders_PaymentTypes_PaymentTypeId",
						column: x => x.PaymentTypeId,
						principalTable: "PaymentTypes",
						principalColumn: "PaymentTypeId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Orders_Sellers_SellerId",
						column: x => x.SellerId,
						principalTable: "Sellers",
						principalColumn: "SellerId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Products",
				columns: table => new
				{
					ProductId = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Title = table.Column<string>(type: "text", nullable: true),
					Description = table.Column<string>(type: "text", nullable: true),
					QuantityAvailable = table.Column<int>(type: "integer", nullable: false),
					PricePerUnit = table.Column<decimal>(type: "numeric", nullable: false),
					SellerId = table.Column<int>(type: "integer", nullable: false),
					ProductCategoryId = table.Column<int>(type: "integer", nullable: false),
					CustomerId = table.Column<int>(type: "integer", nullable: true),
					OrderId = table.Column<int>(type: "integer", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Products", x => x.ProductId);
					table.ForeignKey(
						name: "FK_Products_Customers_CustomerId",
						column: x => x.CustomerId,
						principalTable: "Customers",
						principalColumn: "CustomerId");
					table.ForeignKey(
						name: "FK_Products_Orders_OrderId",
						column: x => x.OrderId,
						principalTable: "Orders",
						principalColumn: "OrderId");
					table.ForeignKey(
						name: "FK_Products_ProductCategories_ProductCategoryId",
						column: x => x.ProductCategoryId,
						principalTable: "ProductCategories",
						principalColumn: "ProductCategoryId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Products_Sellers_SellerId",
						column: x => x.SellerId,
						principalTable: "Sellers",
						principalColumn: "SellerId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "Customers",
				columns: new[] { "CustomerId", "Username" },
				values: new object[,]
				{
					{ 1, "Bob Smith" },
					{ 2, "Jane Doe" }
				});

			migrationBuilder.InsertData(
				table: "ProductCategories",
				columns: new[] { "ProductCategoryId", "Name" },
				values: new object[,]
				{
					{ 1, "Books" },
					{ 2, "Sports" },
					{ 3, "Other" }
				});

			migrationBuilder.InsertData(
				table: "Sellers",
				columns: new[] { "SellerId", "StoreName" },
				values: new object[,]
				{
					{ 1, "Store 1" },
					{ 2, "Store 2" }
				});

			migrationBuilder.InsertData(
				table: "PaymentTypes",
				columns: new[] { "PaymentTypeId", "CustomerId", "Details", "Type" },
				values: new object[,]
				{
					{ 1, 1, null, "Credit Card" },
					{ 2, 2, null, "PayPal" }
				});

			migrationBuilder.InsertData(
				table: "Products",
				columns: new[] { "ProductId", "CustomerId", "Description", "OrderId", "PricePerUnit", "ProductCategoryId", "QuantityAvailable", "SellerId", "Title" },
				values: new object[,]
				{
					{ 1, null, "A really great read!", null, 14.99m, 1, 10, 1, "How to Scam People" },
					{ 2, null, "Soccer ball made for legends only", null, 29.99m, 2, 20, 1, "Soccer Ball" },
					{ 3, null, "Make your phone calls more A-peeling", null, 9.99m, 3, 30, 2, "Banana Phone" }
				});

			migrationBuilder.InsertData(
				table: "Orders",
				columns: new[] { "OrderId", "CustomerId", "PaymentTypeId", "SellerId" },
				values: new object[,]
				{
					{ 1, 1, 1, 1 },
					{ 2, 2, 2, 2 }
				});

			migrationBuilder.CreateIndex(
				name: "IX_Orders_CustomerId",
				table: "Orders",
				column: "CustomerId");

			migrationBuilder.CreateIndex(
				name: "IX_Orders_PaymentTypeId",
				table: "Orders",
				column: "PaymentTypeId");

			migrationBuilder.CreateIndex(
				name: "IX_Orders_SellerId",
				table: "Orders",
				column: "SellerId");

			migrationBuilder.CreateIndex(
				name: "IX_PaymentTypes_CustomerId",
				table: "PaymentTypes",
				column: "CustomerId");

			migrationBuilder.CreateIndex(
				name: "IX_Products_CustomerId",
				table: "Products",
				column: "CustomerId");

			migrationBuilder.CreateIndex(
				name: "IX_Products_OrderId",
				table: "Products",
				column: "OrderId");

			migrationBuilder.CreateIndex(
				name: "IX_Products_ProductCategoryId",
				table: "Products",
				column: "ProductCategoryId");

			migrationBuilder.CreateIndex(
				name: "IX_Products_SellerId",
				table: "Products",
				column: "SellerId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Products");

			migrationBuilder.DropTable(
				name: "Orders");

			migrationBuilder.DropTable(
				name: "ProductCategories");

			migrationBuilder.DropTable(
				name: "PaymentTypes");

			migrationBuilder.DropTable(
				name: "Sellers");

			migrationBuilder.DropTable(
				name: "Customers");
		}
	}
}