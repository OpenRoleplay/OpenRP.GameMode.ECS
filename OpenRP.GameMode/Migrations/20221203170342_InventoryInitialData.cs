using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenRP.GameMode.Migrations
{
    public partial class InventoryInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxWeightInGrams",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "MaxWeight",
                table: "Inventories",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "MaxWeight", "Name" },
                values: new object[] { 1ul, null, "World Inventory" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1ul);

            migrationBuilder.DropColumn(
                name: "MaxWeight",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "MaxWeightInGrams",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
