using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace FoodTracker.Data.Persistence.Migrations;

/// <inheritdoc />
public partial class UpdateMealTracking : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "EatenProducts");

        migrationBuilder.CreateTable(
            name: "TrackedMeals",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<int>(type: "int", nullable: false),
                Quantity = table.Column<int>(type: "int", nullable: false),
                UnitId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                ProductId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                ProductId = table.Column<int>(type: "int", nullable: false),
                MeasurementUnitId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TrackedMeals", x => x.Id);
                table.ForeignKey(
                    name: "FK_TrackedMeals_MeasurementUnits_UnitId",
                    column: x => x.UnitId,
                    principalTable: "MeasurementUnits",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_TrackedMeals_Products_ProductId1",
                    column: x => x.ProductId1,
                    principalTable: "Products",
                    principalColumn: "ProductId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_TrackedMeals_ProductId1",
            table: "TrackedMeals",
            column: "ProductId1");

        migrationBuilder.CreateIndex(
            name: "IX_TrackedMeals_UnitId",
            table: "TrackedMeals",
            column: "UnitId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "TrackedMeals");

        migrationBuilder.CreateTable(
            name: "EatenProducts",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                UnitId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                Quantity = table.Column<int>(type: "int", nullable: false),
                UserId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EatenProducts", x => x.Id);
                table.ForeignKey(
                    name: "FK_EatenProducts_MeasurementUnits_UnitId",
                    column: x => x.UnitId,
                    principalTable: "MeasurementUnits",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EatenProducts_Products_ProductId",
                    column: x => x.ProductId,
                    principalTable: "Products",
                    principalColumn: "ProductId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_EatenProducts_ProductId",
            table: "EatenProducts",
            column: "ProductId");

        migrationBuilder.CreateIndex(
            name: "IX_EatenProducts_UnitId",
            table: "EatenProducts",
            column: "UnitId");
    }
}