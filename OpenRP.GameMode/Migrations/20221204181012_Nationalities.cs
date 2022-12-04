using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenRP.GameMode.Migrations
{
    public partial class Nationalities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Characters",
                type: "varchar(35)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(35)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Characters",
                type: "varchar(35)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(35)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<byte>(
                name: "CountryOfBirthId",
                table: "Accounts",
                type: "tinyint unsigned",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Nationality",
                columns: new[] { "Id", "Name" },
                values: new object[] { (byte)1, "Native of San Andreas" });

            migrationBuilder.InsertData(
                table: "Nationality",
                columns: new[] { "Id", "Name" },
                values: new object[] { (byte)2, "Russian" });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CountryOfBirthId",
                table: "Accounts",
                column: "CountryOfBirthId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Nationality_CountryOfBirthId",
                table: "Accounts",
                column: "CountryOfBirthId",
                principalTable: "Nationality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Nationality_CountryOfBirthId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "Nationality");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CountryOfBirthId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CountryOfBirthId",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Characters",
                type: "varchar(35)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(35)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Characters",
                type: "varchar(35)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(35)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
