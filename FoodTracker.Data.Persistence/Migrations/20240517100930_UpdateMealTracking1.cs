using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTracker.Data.Persistence.Migrations;

/// <inheritdoc />
public partial class UpdateMealTracking1 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_TrackedMeals_MeasurementUnits_UnitId",
            table: "TrackedMeals");

        migrationBuilder.DropForeignKey(
            name: "FK_TrackedMeals_Products_ProductId1",
            table: "TrackedMeals");

        migrationBuilder.DropIndex(
            name: "IX_TrackedMeals_ProductId1",
            table: "TrackedMeals");

        migrationBuilder.DropIndex(
            name: "IX_TrackedMeals_UnitId",
            table: "TrackedMeals");

        migrationBuilder.DropColumn(
            name: "ProductId1",
            table: "TrackedMeals");

        migrationBuilder.DropColumn(
            name: "UnitId",
            table: "TrackedMeals");

        migrationBuilder.AlterColumn<string>(
            name: "ProductId",
            table: "TrackedMeals",
            type: "nvarchar(450)",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<string>(
            name: "MeasurementUnitId",
            table: "TrackedMeals",
            type: "nvarchar(450)",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.CreateIndex(
            name: "IX_TrackedMeals_MeasurementUnitId",
            table: "TrackedMeals",
            column: "MeasurementUnitId");

        migrationBuilder.CreateIndex(
            name: "IX_TrackedMeals_ProductId",
            table: "TrackedMeals",
            column: "ProductId");

        migrationBuilder.AddForeignKey(
            name: "FK_TrackedMeals_MeasurementUnits_MeasurementUnitId",
            table: "TrackedMeals",
            column: "MeasurementUnitId",
            principalTable: "MeasurementUnits",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_TrackedMeals_Products_ProductId",
            table: "TrackedMeals",
            column: "ProductId",
            principalTable: "Products",
            principalColumn: "ProductId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_TrackedMeals_MeasurementUnits_MeasurementUnitId",
            table: "TrackedMeals");

        migrationBuilder.DropForeignKey(
            name: "FK_TrackedMeals_Products_ProductId",
            table: "TrackedMeals");

        migrationBuilder.DropIndex(
            name: "IX_TrackedMeals_MeasurementUnitId",
            table: "TrackedMeals");

        migrationBuilder.DropIndex(
            name: "IX_TrackedMeals_ProductId",
            table: "TrackedMeals");

        migrationBuilder.AlterColumn<int>(
            name: "ProductId",
            table: "TrackedMeals",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(string),
            oldType: "nvarchar(450)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "MeasurementUnitId",
            table: "TrackedMeals",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(string),
            oldType: "nvarchar(450)",
            oldNullable: true);

        migrationBuilder.AddColumn<string>(
            name: "ProductId1",
            table: "TrackedMeals",
            type: "nvarchar(450)",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "UnitId",
            table: "TrackedMeals",
            type: "nvarchar(450)",
            nullable: false,
            defaultValue: "");

        migrationBuilder.CreateIndex(
            name: "IX_TrackedMeals_ProductId1",
            table: "TrackedMeals",
            column: "ProductId1");

        migrationBuilder.CreateIndex(
            name: "IX_TrackedMeals_UnitId",
            table: "TrackedMeals",
            column: "UnitId");

        migrationBuilder.AddForeignKey(
            name: "FK_TrackedMeals_MeasurementUnits_UnitId",
            table: "TrackedMeals",
            column: "UnitId",
            principalTable: "MeasurementUnits",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_TrackedMeals_Products_ProductId1",
            table: "TrackedMeals",
            column: "ProductId1",
            principalTable: "Products",
            principalColumn: "ProductId",
            onDelete: ReferentialAction.Cascade);
    }
}