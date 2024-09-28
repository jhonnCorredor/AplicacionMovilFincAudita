using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class segundaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citys_Countrys_CountryId",
                table: "Citys");

            migrationBuilder.DropForeignKey(
                name: "FK_Departaments_Citys_CityId",
                table: "Departaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Farms_Departaments_DepartamentId",
                table: "Farms");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Departaments_DepartamentId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "DepartamentId",
                table: "Persons",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_DepartamentId",
                table: "Persons",
                newName: "IX_Persons_CityId");

            migrationBuilder.RenameColumn(
                name: "DepartamentId",
                table: "Farms",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Farms_DepartamentId",
                table: "Farms",
                newName: "IX_Farms_CityId");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Departaments",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Departaments_CityId",
                table: "Departaments",
                newName: "IX_Departaments_CountryId");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Citys",
                newName: "DepartamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Citys_CountryId",
                table: "Citys",
                newName: "IX_Citys_DepartamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citys_Departaments_DepartamentId",
                table: "Citys",
                column: "DepartamentId",
                principalTable: "Departaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departaments_Countrys_CountryId",
                table: "Departaments",
                column: "CountryId",
                principalTable: "Countrys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_Citys_CityId",
                table: "Farms",
                column: "CityId",
                principalTable: "Citys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Citys_CityId",
                table: "Persons",
                column: "CityId",
                principalTable: "Citys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citys_Departaments_DepartamentId",
                table: "Citys");

            migrationBuilder.DropForeignKey(
                name: "FK_Departaments_Countrys_CountryId",
                table: "Departaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Farms_Citys_CityId",
                table: "Farms");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Citys_CityId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Persons",
                newName: "DepartamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_CityId",
                table: "Persons",
                newName: "IX_Persons_DepartamentId");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Farms",
                newName: "DepartamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Farms_CityId",
                table: "Farms",
                newName: "IX_Farms_DepartamentId");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Departaments",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Departaments_CountryId",
                table: "Departaments",
                newName: "IX_Departaments_CityId");

            migrationBuilder.RenameColumn(
                name: "DepartamentId",
                table: "Citys",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Citys_DepartamentId",
                table: "Citys",
                newName: "IX_Citys_CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citys_Countrys_CountryId",
                table: "Citys",
                column: "CountryId",
                principalTable: "Countrys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departaments_Citys_CityId",
                table: "Departaments",
                column: "CityId",
                principalTable: "Citys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_Departaments_DepartamentId",
                table: "Farms",
                column: "DepartamentId",
                principalTable: "Departaments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Departaments_DepartamentId",
                table: "Persons",
                column: "DepartamentId",
                principalTable: "Departaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
