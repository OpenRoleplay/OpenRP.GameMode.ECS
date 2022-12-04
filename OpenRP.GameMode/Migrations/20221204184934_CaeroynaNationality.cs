using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenRP.GameMode.Migrations
{
    public partial class CaeroynaNationality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "Id", "Name" },
                values: new object[] { (byte)114, "Native of Caeroyna" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: (byte)114);
        }
    }
}
