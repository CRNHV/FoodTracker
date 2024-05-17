using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace FoodTracker.Data.Persistence.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "BaseProducts",
            columns: table => new
            {
                BaseProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BaseProducts", x => x.BaseProductId);
            });

        migrationBuilder.CreateTable(
            name: "ProductInfo",
            columns: table => new
            {
                ProductInfoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Alcohol = table.Column<double>(type: "float", nullable: true),
                Calcium = table.Column<double>(type: "float", nullable: true),
                Ean = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Eiwit = table.Column<double>(type: "float", nullable: true),
                EiwitPlantaardig = table.Column<double>(type: "float", nullable: true),
                Energie = table.Column<double>(type: "float", nullable: true),
                Foliumzuur = table.Column<double>(type: "float", nullable: true),
                Fosfor = table.Column<double>(type: "float", nullable: true),
                Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                IJzer = table.Column<double>(type: "float", nullable: true),
                IsObsolete = table.Column<bool>(type: "bit", nullable: false),
                Jodium = table.Column<double>(type: "float", nullable: true),
                Kalium = table.Column<double>(type: "float", nullable: true),
                Koolhydraten = table.Column<double>(type: "float", nullable: true),
                Magnesium = table.Column<double>(type: "float", nullable: true),
                Natrium = table.Column<double>(type: "float", nullable: true),
                Nicotinezuur = table.Column<double>(type: "float", nullable: true),
                NutritionalValuesBasedOnPreparedProduct = table.Column<bool>(type: "bit", nullable: false),
                ProductGroupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Selenium = table.Column<double>(type: "float", nullable: true),
                Suikers = table.Column<double>(type: "float", nullable: true),
                VerzadigdVet = table.Column<double>(type: "float", nullable: true),
                Vet = table.Column<double>(type: "float", nullable: true),
                Vezels = table.Column<double>(type: "float", nullable: true),
                VitamineA = table.Column<double>(type: "float", nullable: true),
                VitamineB1 = table.Column<double>(type: "float", nullable: true),
                VitamineB12 = table.Column<double>(type: "float", nullable: true),
                VitamineB2 = table.Column<double>(type: "float", nullable: true),
                VitamineB6 = table.Column<double>(type: "float", nullable: true),
                VitamineC = table.Column<double>(type: "float", nullable: true),
                VitamineD = table.Column<double>(type: "float", nullable: true),
                VitamineE = table.Column<double>(type: "float", nullable: true),
                Water = table.Column<double>(type: "float", nullable: true),
                WeightGainFactor = table.Column<double>(type: "float", nullable: true),
                Zink = table.Column<double>(type: "float", nullable: true),
                Zout = table.Column<double>(type: "float", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProductInfo", x => x.ProductInfoId);
            });

        migrationBuilder.CreateTable(
            name: "Products",
            columns: table => new
            {
                ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Ean = table.Column<string>(type: "nvarchar(max)", nullable: true),
                BaseProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                BaseProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                ProductInfoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                BaseProductEntityBaseProductId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.ProductId);
                table.ForeignKey(
                    name: "FK_Products_BaseProducts_BaseProductEntityBaseProductId",
                    column: x => x.BaseProductEntityBaseProductId,
                    principalTable: "BaseProducts",
                    principalColumn: "BaseProductId");
                table.ForeignKey(
                    name: "FK_Products_ProductInfo_ProductInfoId",
                    column: x => x.ProductInfoId,
                    principalTable: "ProductInfo",
                    principalColumn: "ProductInfoId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "MeasurementUnits",
            columns: table => new
            {
                Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                GramsPerUnit = table.Column<double>(type: "float", nullable: true),
                IsTussendoortje = table.Column<bool>(type: "bit", nullable: false),
                CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                ProductEntityProductId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MeasurementUnits", x => x.Id);
                table.ForeignKey(
                    name: "FK_MeasurementUnits_Products_ProductEntityProductId",
                    column: x => x.ProductEntityProductId,
                    principalTable: "Products",
                    principalColumn: "ProductId");
            });

        migrationBuilder.CreateIndex(
            name: "IX_MeasurementUnits_ProductEntityProductId",
            table: "MeasurementUnits",
            column: "ProductEntityProductId");

        migrationBuilder.CreateIndex(
            name: "IX_Products_BaseProductEntityBaseProductId",
            table: "Products",
            column: "BaseProductEntityBaseProductId");

        migrationBuilder.CreateIndex(
            name: "IX_Products_ProductInfoId",
            table: "Products",
            column: "ProductInfoId",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "MeasurementUnits");

        migrationBuilder.DropTable(
            name: "Products");

        migrationBuilder.DropTable(
            name: "BaseProducts");

        migrationBuilder.DropTable(
            name: "ProductInfo");
    }
}