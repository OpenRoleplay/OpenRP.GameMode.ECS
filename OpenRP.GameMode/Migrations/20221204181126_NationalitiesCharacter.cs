using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenRP.GameMode.Migrations
{
    public partial class NationalitiesCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Nationalities_CountryOfBirthId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CountryOfBirthId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CountryOfBirthId",
                table: "Accounts");

            migrationBuilder.AddColumn<byte>(
                name: "CountryOfBirthId",
                table: "Characters",
                type: "tinyint unsigned",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CountryOfBirthId",
                table: "Characters",
                column: "CountryOfBirthId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Nationalities_CountryOfBirthId",
                table: "Characters",
                column: "CountryOfBirthId",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Nationalities_CountryOfBirthId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CountryOfBirthId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CountryOfBirthId",
                table: "Characters");

            migrationBuilder.AddColumn<byte>(
                name: "CountryOfBirthId",
                table: "Accounts",
                type: "tinyint unsigned",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CountryOfBirthId",
                table: "Accounts",
                column: "CountryOfBirthId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Nationalities_CountryOfBirthId",
                table: "Accounts",
                column: "CountryOfBirthId",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
