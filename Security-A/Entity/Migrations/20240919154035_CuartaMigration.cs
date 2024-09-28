using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class CuartaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewTechnicals_Farms_FarmId",
                table: "ReviewTechnicals");

            migrationBuilder.RenameColumn(
                name: "FarmId",
                table: "ReviewTechnicals",
                newName: "LotId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewTechnicals_FarmId",
                table: "ReviewTechnicals",
                newName: "IX_ReviewTechnicals_LotId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewTechnicals_Lots_LotId",
                table: "ReviewTechnicals",
                column: "LotId",
                principalTable: "Lots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewTechnicals_Lots_LotId",
                table: "ReviewTechnicals");

            migrationBuilder.RenameColumn(
                name: "LotId",
                table: "ReviewTechnicals",
                newName: "FarmId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewTechnicals_LotId",
                table: "ReviewTechnicals",
                newName: "IX_ReviewTechnicals_FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewTechnicals_Farms_FarmId",
                table: "ReviewTechnicals",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
