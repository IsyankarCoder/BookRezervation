using Microsoft.EntityFrameworkCore.Migrations;

namespace BookRezervation.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Country_Penalty_PenaltyId",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_PenaltyId",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "PenaltyId",
                table: "Country");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amout",
                table: "Penalty",
                type: "decimal(6,2)",
                precision: 6,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_CountryId",
                table: "Penalty",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Penalty_Country_CountryId",
                table: "Penalty",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Penalty_Country_CountryId",
                table: "Penalty");

            migrationBuilder.DropIndex(
                name: "IX_Penalty_CountryId",
                table: "Penalty");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amout",
                table: "Penalty",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldPrecision: 6,
                oldScale: 2);

            migrationBuilder.AddColumn<short>(
                name: "PenaltyId",
                table: "Country",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_Country_PenaltyId",
                table: "Country",
                column: "PenaltyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Country_Penalty_PenaltyId",
                table: "Country",
                column: "PenaltyId",
                principalTable: "Penalty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
