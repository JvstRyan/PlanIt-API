using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlanIt.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Dates_DateId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_DateId",
                table: "Responses");

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

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "DateId",
                table: "Responses");

            migrationBuilder.CreateTable(
                name: "DateAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer = table.Column<bool>(type: "bit", nullable: false),
                    ResponseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateAnswers_Dates_DateId",
                        column: x => x.DateId,
                        principalTable: "Dates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DateAnswers_Responses_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "Responses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateAnswers_DateId",
                table: "DateAnswers",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_DateAnswers_ResponseId",
                table: "DateAnswers",
                column: "ResponseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateAnswers");

            migrationBuilder.AddColumn<bool>(
                name: "Answer",
                table: "Responses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "DateId",
                table: "Responses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a258f84-c213-4651-b09d-6feb2da3fd63", null, "volunteer", "VOLUNTEER" },
                    { "9431a31c-5b3b-4191-8c04-f19f34ff3c57", null, "guest", "GUEST" },
                    { "accd3ab5-37d6-4999-9618-3f9bea33a00c", null, "admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_DateId",
                table: "Responses",
                column: "DateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Dates_DateId",
                table: "Responses",
                column: "DateId",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
