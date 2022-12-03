using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenRP.GameMode.Migrations
{
    public partial class RemoveSaltAndChangePasswordType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Accounts",
                type: "char(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(128)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Accounts",
                type: "char(128)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(60)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Accounts",
                type: "char(10)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
