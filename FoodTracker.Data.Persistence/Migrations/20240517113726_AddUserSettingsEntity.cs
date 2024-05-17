using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace FoodTracker.Data.Persistence.Migrations;

/// <inheritdoc />
public partial class AddUserSettingsEntity : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
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
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "UserSettings");
    }
}