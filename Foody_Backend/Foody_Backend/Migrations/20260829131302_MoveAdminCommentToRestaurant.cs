using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foody_backend.Migrations
{
    /// <inheritdoc />
    public partial class MoveAdminCommentToRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminComment",
                table: "RestaurantsPendingUpdates");

            migrationBuilder.AddColumn<string>(
                name: "AdminComment",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminComment",
                table: "Restaurants");

            migrationBuilder.AddColumn<string>(
                name: "AdminComment",
                table: "RestaurantsPendingUpdates",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
