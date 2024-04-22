using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlanIt.API.Migrations
{
    /// <inheritdoc />
    public partial class respons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("1047d982-2454-4a1a-a943-2ab8bfda491b"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("2d998909-2423-4960-b2f2-88b4c08ca44a"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("57167d10-36eb-4607-88cb-81ca6410d025"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("795cbecf-5b2d-4aa8-b64c-aacdbd48d7d9"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("b6017065-422b-40ca-ac35-9242a9efb4fa"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("c95231f0-e824-4201-916a-581d05c9c85d"));

            migrationBuilder.AddColumn<bool>(
                name: "Resoponse",
                table: "Responses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Dates",
                columns: new[] { "Id", "Date", "Status" },
                values: new object[,]
                {
                    { new Guid("09582968-b3c0-4ed0-b1a8-3d709e9b0daf"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" },
                    { new Guid("0e79f60f-14e4-4f58-897a-3991c62eb624"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" },
                    { new Guid("66c8a5bc-1aae-415a-b0fb-baf2f65447de"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" },
                    { new Guid("99894490-21cb-4cb7-9c8f-ed1961d06ee7"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" },
                    { new Guid("d8c11296-8157-4bbe-bb1c-33247ff7f41f"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" },
                    { new Guid("e652051a-4dad-4adc-9733-daeeeedbfc12"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("09582968-b3c0-4ed0-b1a8-3d709e9b0daf"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("0e79f60f-14e4-4f58-897a-3991c62eb624"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("66c8a5bc-1aae-415a-b0fb-baf2f65447de"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("99894490-21cb-4cb7-9c8f-ed1961d06ee7"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("d8c11296-8157-4bbe-bb1c-33247ff7f41f"));

            migrationBuilder.DeleteData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: new Guid("e652051a-4dad-4adc-9733-daeeeedbfc12"));

            migrationBuilder.DropColumn(
                name: "Resoponse",
                table: "Responses");

            migrationBuilder.InsertData(
                table: "Dates",
                columns: new[] { "Id", "Date", "Status" },
                values: new object[,]
                {
                    { new Guid("1047d982-2454-4a1a-a943-2ab8bfda491b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" },
                    { new Guid("2d998909-2423-4960-b2f2-88b4c08ca44a"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" },
                    { new Guid("57167d10-36eb-4607-88cb-81ca6410d025"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" },
                    { new Guid("795cbecf-5b2d-4aa8-b64c-aacdbd48d7d9"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" },
                    { new Guid("b6017065-422b-40ca-ac35-9242a9efb4fa"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" },
                    { new Guid("c95231f0-e824-4201-916a-581d05c9c85d"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "active" }
                });
        }
    }
}
