using Microsoft.EntityFrameworkCore.Migrations;

namespace Codwer.Intern.Persistence.Migrations
{
    public partial class AddFKinBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoverID",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDCover",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDLanguage",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDPartnerPrice",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageID",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartnerPriceID",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CoverID",
                table: "Books",
                column: "CoverID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LanguageID",
                table: "Books",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PartnerPriceID",
                table: "Books",
                column: "PartnerPriceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Covers_CoverID",
                table: "Books",
                column: "CoverID",
                principalTable: "Covers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Languages_LanguageID",
                table: "Books",
                column: "LanguageID",
                principalTable: "Languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_PartnerPrices_PartnerPriceID",
                table: "Books",
                column: "PartnerPriceID",
                principalTable: "PartnerPrices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Covers_CoverID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Languages_LanguageID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_PartnerPrices_PartnerPriceID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CoverID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_LanguageID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_PartnerPriceID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CoverID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IDCover",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IDLanguage",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IDPartnerPrice",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LanguageID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PartnerPriceID",
                table: "Books");
        }
    }
}
