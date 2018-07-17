using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLib.Migrations
{
    public partial class Migration01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Age", "Name" },
                values: new object[] { 1, 18, "Sam" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Age", "Name" },
                values: new object[] { 2, 19, "Kevin" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Age", "Name" },
                values: new object[] { 3, 20, "John" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);
        }
    }
}
