using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlanIt.API.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a258f84-c213-4651-b09d-6feb2da3fd63", null, "volunteer", "VOLUNTEER" },
                    { "9431a31c-5b3b-4191-8c04-f19f34ff3c57", null, "guest", "GUEST" },
                    { "accd3ab5-37d6-4999-9618-3f9bea33a00c", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a258f84-c213-4651-b09d-6feb2da3fd63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9431a31c-5b3b-4191-8c04-f19f34ff3c57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "accd3ab5-37d6-4999-9618-3f9bea33a00c");
        }
    }
}
