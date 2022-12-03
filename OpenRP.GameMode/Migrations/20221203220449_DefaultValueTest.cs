using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenRP.GameMode.Migrations
{
    public partial class DefaultValueTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Level",
                table: "Accounts",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)1,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");

            migrationBuilder.AlterColumn<ushort>(
                name: "Experience",
                table: "Accounts",
                type: "smallint unsigned",
                nullable: false,
                defaultValue: (ushort)0,
                oldClrType: typeof(ushort),
                oldType: "smallint unsigned");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Level",
                table: "Accounts",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned",
                oldDefaultValue: (byte)1);

            migrationBuilder.AlterColumn<ushort>(
                name: "Experience",
                table: "Accounts",
                type: "smallint unsigned",
                nullable: false,
                oldClrType: typeof(ushort),
                oldType: "smallint unsigned",
                oldDefaultValue: (ushort)0);
        }
    }
}
