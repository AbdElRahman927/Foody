using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foody_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRestaurantFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PendingFacebook",
                table: "RestaurantsPendingUpdates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PendingInstagram",
                table: "RestaurantsPendingUpdates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PendingMenuUrl",
                table: "RestaurantsPendingUpdates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PendingOpeningHours",
                table: "RestaurantsPendingUpdates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PendingPhone",
                table: "RestaurantsPendingUpdates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PendingWebsite",
                table: "RestaurantsPendingUpdates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuUrl",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpeningHours",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PendingFacebook",
                table: "RestaurantsPendingUpdates");

            migrationBuilder.DropColumn(
                name: "PendingInstagram",
                table: "RestaurantsPendingUpdates");

            migrationBuilder.DropColumn(
                name: "PendingMenuUrl",
                table: "RestaurantsPendingUpdates");

            migrationBuilder.DropColumn(
                name: "PendingOpeningHours",
                table: "RestaurantsPendingUpdates");

            migrationBuilder.DropColumn(
                name: "PendingPhone",
                table: "RestaurantsPendingUpdates");

            migrationBuilder.DropColumn(
                name: "PendingWebsite",
                table: "RestaurantsPendingUpdates");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "MenuUrl",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "OpeningHours",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Restaurants");
        }
    }
}
