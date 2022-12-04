using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenRP.GameMode.Migrations
{
    public partial class NationalitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Nationality_CountryOfBirthId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nationality",
                table: "Nationality");

            migrationBuilder.RenameTable(
                name: "Nationality",
                newName: "Nationalities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nationalities",
                table: "Nationalities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Nationalities_CountryOfBirthId",
                table: "Accounts",
                column: "CountryOfBirthId",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Nationalities_CountryOfBirthId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nationalities",
                table: "Nationalities");

            migrationBuilder.RenameTable(
                name: "Nationalities",
                newName: "Nationality");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nationality",
                table: "Nationality",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Nationality_CountryOfBirthId",
                table: "Accounts",
                column: "CountryOfBirthId",
                principalTable: "Nationality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
