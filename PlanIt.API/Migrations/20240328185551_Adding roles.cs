using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlanIt.API.Migrations
{
    /// <inheritdoc />
    public partial class Addingroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("2f52f798-af9e-4f53-a4cd-ba85238b9182"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("36cfeaa9-fe46-4ff9-a47c-bca818b44d73"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("3d62aa7f-e374-4b8b-9953-12037d21f281"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("4b580c00-f9c6-4a80-99dd-5d34058d10a5"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("79a5405a-4122-474e-85ef-bd4cedcb39ee"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("dc477fd3-6b89-4aa6-9770-7919caeb96e2"));

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
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
            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.InsertData(
                table: "Dates",
                columns: new[] { "Id", "Date", "Status" },
                values: new object[,]
                {
                    { new Guid("2f52f798-af9e-4f53-a4cd-ba85238b9182"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" },
                    { new Guid("36cfeaa9-fe46-4ff9-a47c-bca818b44d73"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" },
                    { new Guid("3d62aa7f-e374-4b8b-9953-12037d21f281"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" },
                    { new Guid("4b580c00-f9c6-4a80-99dd-5d34058d10a5"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" },
                    { new Guid("79a5405a-4122-474e-85ef-bd4cedcb39ee"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" },
                    { new Guid("dc477fd3-6b89-4aa6-9770-7919caeb96e2"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" }
                });
        }
    }
}
