using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTracker.Data.Persistence.Migrations;

/// <inheritdoc />
public partial class SetProductUnitsManyToMany : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_MeasurementUnits_Products_ProductEntityProductId",
            table: "MeasurementUnits");

        migrationBuilder.DropIndex(
            name: "IX_MeasurementUnits_ProductEntityProductId",
            table: "MeasurementUnits");

        migrationBuilder.DropColumn(
            name: "ProductEntityProductId",
            table: "MeasurementUnits");

        migrationBuilder.CreateTable(
            name: "MeasurementUnitEntityProductEntity",
            columns: table => new
            {
                ProductEntityProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                UnitsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MeasurementUnitEntityProductEntity", x => new { x.ProductEntityProductId, x.UnitsId });
                table.ForeignKey(
                    name: "FK_MeasurementUnitEntityProductEntity_MeasurementUnits_UnitsId",
                    column: x => x.UnitsId,
                    principalTable: "MeasurementUnits",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_MeasurementUnitEntityProductEntity_Products_ProductEntityProductId",
                    column: x => x.ProductEntityProductId,
                    principalTable: "Products",
                    principalColumn: "ProductId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_MeasurementUnitEntityProductEntity_UnitsId",
            table: "MeasurementUnitEntityProductEntity",
            column: "UnitsId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "MeasurementUnitEntityProductEntity");

        migrationBuilder.AddColumn<string>(
            name: "ProductEntityProductId",
            table: "MeasurementUnits",
            type: "nvarchar(450)",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_MeasurementUnits_ProductEntityProductId",
            table: "MeasurementUnits",
            column: "ProductEntityProductId");

        migrationBuilder.AddForeignKey(
            name: "FK_MeasurementUnits_Products_ProductEntityProductId",
            table: "MeasurementUnits",
            column: "ProductEntityProductId",
            principalTable: "Products",
            principalColumn: "ProductId");
    }
}