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
            name: "AspNetRoles",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUsers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            });

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
            name: "MeasurementUnits",
            columns: table => new
            {
                Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                GramsPerUnit = table.Column<double>(type: "float", nullable: true),
                IsTussendoortje = table.Column<bool>(type: "bit", nullable: false),
                CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MeasurementUnits", x => x.Id);
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
            name: "UserSettings",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<int>(type: "int", nullable: false),
                EnergyGoal = table.Column<double>(type: "float", nullable: false),
                ProteinGoal = table.Column<double>(type: "float", nullable: false),
                FatGoal = table.Column<double>(type: "float", nullable: false),
                CarbGoal = table.Column<double>(type: "float", nullable: false),
                CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserSettings", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "AspNetRoleClaims",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                RoleId = table.Column<int>(type: "int", nullable: false),
                ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                table.ForeignKey(
                    name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "AspNetRoles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserClaims",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<int>(type: "int", nullable: false),
                ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                table.ForeignKey(
                    name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserLogins",
            columns: table => new
            {
                LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UserId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                table.ForeignKey(
                    name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserRoles",
            columns: table => new
            {
                UserId = table.Column<int>(type: "int", nullable: false),
                RoleId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                table.ForeignKey(
                    name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "AspNetRoles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserTokens",
            columns: table => new
            {
                UserId = table.Column<int>(type: "int", nullable: false),
                LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                table.ForeignKey(
                    name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
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

        migrationBuilder.CreateTable(
            name: "TrackedMeals",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<int>(type: "int", nullable: false),
                Quantity = table.Column<int>(type: "int", nullable: false),
                CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                MeasurementUnitId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TrackedMeals", x => x.Id);
                table.ForeignKey(
                    name: "FK_TrackedMeals_MeasurementUnits_MeasurementUnitId",
                    column: x => x.MeasurementUnitId,
                    principalTable: "MeasurementUnits",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_TrackedMeals_Products_ProductId",
                    column: x => x.ProductId,
                    principalTable: "Products",
                    principalColumn: "ProductId");
            });

        migrationBuilder.CreateIndex(
            name: "IX_AspNetRoleClaims_RoleId",
            table: "AspNetRoleClaims",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "RoleNameIndex",
            table: "AspNetRoles",
            column: "NormalizedName",
            unique: true,
            filter: "[NormalizedName] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_AspNetUserClaims_UserId",
            table: "AspNetUserClaims",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_AspNetUserLogins_UserId",
            table: "AspNetUserLogins",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_AspNetUserRoles_RoleId",
            table: "AspNetUserRoles",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "EmailIndex",
            table: "AspNetUsers",
            column: "NormalizedEmail");

        migrationBuilder.CreateIndex(
            name: "UserNameIndex",
            table: "AspNetUsers",
            column: "NormalizedUserName",
            unique: true,
            filter: "[NormalizedUserName] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_MeasurementUnitEntityProductEntity_UnitsId",
            table: "MeasurementUnitEntityProductEntity",
            column: "UnitsId");

        migrationBuilder.CreateIndex(
            name: "IX_Products_BaseProductEntityBaseProductId",
            table: "Products",
            column: "BaseProductEntityBaseProductId");

        migrationBuilder.CreateIndex(
            name: "IX_Products_ProductInfoId",
            table: "Products",
            column: "ProductInfoId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_TrackedMeals_MeasurementUnitId",
            table: "TrackedMeals",
            column: "MeasurementUnitId");

        migrationBuilder.CreateIndex(
            name: "IX_TrackedMeals_ProductId",
            table: "TrackedMeals",
            column: "ProductId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "AspNetRoleClaims");

        migrationBuilder.DropTable(
            name: "AspNetUserClaims");

        migrationBuilder.DropTable(
            name: "AspNetUserLogins");

        migrationBuilder.DropTable(
            name: "AspNetUserRoles");

        migrationBuilder.DropTable(
            name: "AspNetUserTokens");

        migrationBuilder.DropTable(
            name: "MeasurementUnitEntityProductEntity");

        migrationBuilder.DropTable(
            name: "TrackedMeals");

        migrationBuilder.DropTable(
            name: "UserSettings");

        migrationBuilder.DropTable(
            name: "AspNetRoles");

        migrationBuilder.DropTable(
            name: "AspNetUsers");

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
