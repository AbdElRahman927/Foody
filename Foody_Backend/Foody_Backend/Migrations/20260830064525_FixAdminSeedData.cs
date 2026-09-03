using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foody_backend.Migrations
{
    /// <inheritdoc />
    public partial class FixAdminSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "CreatedAt", "DateOfBirth", "Email", "FavoriteCuisine", "FullName", "Gender", "IsEmailVerified", "PasswordHash", "Phone", "ProfileImageUrl", "Role", "UpdatedAt" },
                values: new object[] { 927, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "admin@foody.com", null, "Admin", "Male", false, "$2a$11$hAAnZa0quSX5yJ7oPpLAS.oRWz1G61bxcpjkcGA6Eg08c6oe8KVse", null, null, "Admin", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 927);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "CreatedAt", "DateOfBirth", "Email", "FavoriteCuisine", "FullName", "Gender", "IsEmailVerified", "PasswordHash", "Phone", "ProfileImageUrl", "Role", "UpdatedAt" },
                values: new object[] { 1, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "admin@foody.com", null, "Admin", "Male", false, "$2a$11$QarULkEpPD8tqlgd2xkCUOa.eohMIau5tvGt20m9zSgpZAjcqyKLm", null, null, "Admin", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });
        }
    }
}
