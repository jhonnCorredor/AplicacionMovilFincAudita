using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class TerceraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FertilizationSupplies");

            migrationBuilder.DropTable(
                name: "FumigationSupplies");

            migrationBuilder.DropTable(
                name: "LotFertilizations");

            migrationBuilder.DropTable(
                name: "LotFumigations");

            migrationBuilder.DropTable(
                name: "Fertilizations");

            migrationBuilder.DropTable(
                name: "Fumigations");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Views",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Views",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Views",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Users",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "UserRoles",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "UserRoles",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "UserRoles",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Supplies",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Supplies",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Supplies",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "RoleViews",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "RoleViews",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "RoleViews",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Roles",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Roles",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Roles",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "ReviewTechnicals",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "ReviewTechnicals",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "ReviewTechnicals",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Qualifications",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Qualifications",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Qualifications",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Persons",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Persons",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Persons",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Modulos",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Modulos",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Modulos",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Lots",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Lots",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Lots",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Farms",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Farms",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Farms",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Evidences",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Evidences",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Evidences",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Departaments",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Departaments",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Departaments",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Crops",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Crops",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Crops",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Countrys",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Countrys",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Countrys",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Citys",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Citys",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Citys",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Checklists",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Checklists",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Checklists",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "AssessmentCriterias",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "AssessmentCriterias",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "AssessmentCriterias",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "Addres",
                table: "Farms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Dimension",
                table: "Farms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTreatment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeTreatment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityMix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LotTreatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LotId = table.Column<int>(type: "int", nullable: false),
                    TreatmentId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotTreatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotTreatments_Lots_LotId",
                        column: x => x.LotId,
                        principalTable: "Lots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotTreatments_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuppliesId = table.Column<int>(type: "int", nullable: false),
                    TreatmentId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentSupplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentSupplies_Supplies_SuppliesId",
                        column: x => x.SuppliesId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentSupplies_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_UserId",
                table: "Alerts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LotTreatments_LotId",
                table: "LotTreatments",
                column: "LotId");

            migrationBuilder.CreateIndex(
                name: "IX_LotTreatments_TreatmentId",
                table: "LotTreatments",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentSupplies_SuppliesId",
                table: "TreatmentSupplies",
                column: "SuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentSupplies_TreatmentId",
                table: "TreatmentSupplies",
                column: "TreatmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "LotTreatments");

            migrationBuilder.DropTable(
                name: "TreatmentSupplies");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropColumn(
                name: "Addres",
                table: "Farms");

            migrationBuilder.DropColumn(
                name: "Dimension",
                table: "Farms");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Views",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Views",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Views",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Users",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Users",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "UserRoles",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "UserRoles",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "UserRoles",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Supplies",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Supplies",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Supplies",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "RoleViews",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "RoleViews",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "RoleViews",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Roles",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Roles",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Roles",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ReviewTechnicals",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ReviewTechnicals",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ReviewTechnicals",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Qualifications",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Qualifications",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Qualifications",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Persons",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Persons",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Persons",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Modulos",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Modulos",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Modulos",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Lots",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Lots",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Lots",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Farms",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Farms",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Farms",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Evidences",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Evidences",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Evidences",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Departaments",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Departaments",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Departaments",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Crops",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Crops",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Crops",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Countrys",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Countrys",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Countrys",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Citys",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Citys",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Citys",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Checklists",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Checklists",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Checklists",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "AssessmentCriterias",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "AssessmentCriterias",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "AssessmentCriterias",
                newName: "Created_at");

            migrationBuilder.CreateTable(
                name: "Fertilizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFertilization = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuantityMix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    TypeFertilization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fertilizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fumigations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFumigation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuantityMix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fumigations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FertilizationSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FertilizationId = table.Column<int>(type: "int", nullable: false),
                    SuppliesId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Dose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizationSupplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FertilizationSupplies_Fertilizations_FertilizationId",
                        column: x => x.FertilizationId,
                        principalTable: "Fertilizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FertilizationSupplies_Supplies_SuppliesId",
                        column: x => x.SuppliesId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LotFertilizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FertilizationId = table.Column<int>(type: "int", nullable: false),
                    LotId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotFertilizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotFertilizations_Fertilizations_FertilizationId",
                        column: x => x.FertilizationId,
                        principalTable: "Fertilizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotFertilizations_Lots_LotId",
                        column: x => x.LotId,
                        principalTable: "Lots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FumigationSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FumigationId = table.Column<int>(type: "int", nullable: false),
                    SuppliesId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Dose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FumigationSupplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FumigationSupplies_Fumigations_FumigationId",
                        column: x => x.FumigationId,
                        principalTable: "Fumigations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FumigationSupplies_Supplies_SuppliesId",
                        column: x => x.SuppliesId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LotFumigations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FumigationId = table.Column<int>(type: "int", nullable: false),
                    LotId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotFumigations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotFumigations_Fumigations_FumigationId",
                        column: x => x.FumigationId,
                        principalTable: "Fumigations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotFumigations_Lots_LotId",
                        column: x => x.LotId,
                        principalTable: "Lots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FertilizationSupplies_FertilizationId",
                table: "FertilizationSupplies",
                column: "FertilizationId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizationSupplies_SuppliesId",
                table: "FertilizationSupplies",
                column: "SuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_FumigationSupplies_FumigationId",
                table: "FumigationSupplies",
                column: "FumigationId");

            migrationBuilder.CreateIndex(
                name: "IX_FumigationSupplies_SuppliesId",
                table: "FumigationSupplies",
                column: "SuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_LotFertilizations_FertilizationId",
                table: "LotFertilizations",
                column: "FertilizationId");

            migrationBuilder.CreateIndex(
                name: "IX_LotFertilizations_LotId",
                table: "LotFertilizations",
                column: "LotId");

            migrationBuilder.CreateIndex(
                name: "IX_LotFumigations_FumigationId",
                table: "LotFumigations",
                column: "FumigationId");

            migrationBuilder.CreateIndex(
                name: "IX_LotFumigations_LotId",
                table: "LotFumigations",
                column: "LotId");
        }
    }
}
