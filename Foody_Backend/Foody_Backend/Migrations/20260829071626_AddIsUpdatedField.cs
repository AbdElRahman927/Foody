using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foody_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddIsUpdatedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "Restaurants");

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "RestaurantsPendingUpdates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "RestaurantsPendingUpdates");

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
