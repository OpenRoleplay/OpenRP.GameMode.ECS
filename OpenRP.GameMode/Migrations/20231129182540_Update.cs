using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenRP.GameMode.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Skin",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 26);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Skin",
                table: "Characters");
        }
    }
}
