using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace FoodTracker.Data.Persistence.Migrations;

/// <inheritdoc />
public partial class AddRegistrationTokens : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "RegistrationTokens",
            columns: table => new
            {
                Token = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RegistrationTokens", x => x.Token);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "RegistrationTokens");
    }
}
