using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
	public partial class updated : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "Ordered_Products",
				columns: new[] { "OrderId", "ProductId", "Id" },
				values: new object[] { 2, 3, 3 });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Ordered_Products",
				keyColumns: new[] { "OrderId", "ProductId" },
				keyValues: new object[] { 2, 3 });
		}
	}
}