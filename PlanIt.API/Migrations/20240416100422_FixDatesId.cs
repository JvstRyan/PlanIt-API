using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanIt.API.Migrations
{
    /// <inheritdoc />
    public partial class FixDatesId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateAnswers_Dates_DatesId",
                table: "DateAnswers");

            migrationBuilder.DropIndex(
                name: "IX_DateAnswers_DatesId",
                table: "DateAnswers");

            migrationBuilder.DropColumn(
                name: "DatesId",
                table: "DateAnswers");

            migrationBuilder.CreateIndex(
                name: "IX_DateAnswers_DateId",
                table: "DateAnswers",
                column: "DateId");

            migrationBuilder.AddForeignKey(
                name: "FK_DateAnswers_Dates_DateId",
                table: "DateAnswers",
                column: "DateId",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateAnswers_Dates_DateId",
                table: "DateAnswers");

            migrationBuilder.DropIndex(
                name: "IX_DateAnswers_DateId",
                table: "DateAnswers");

            migrationBuilder.AddColumn<Guid>(
                name: "DatesId",
                table: "DateAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DateAnswers_DatesId",
                table: "DateAnswers",
                column: "DatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DateAnswers_Dates_DatesId",
                table: "DateAnswers",
                column: "DatesId",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
