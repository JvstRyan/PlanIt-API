using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanIt.API.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateAnswers_Responses_ResponseId",
                table: "DateAnswers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResponseId",
                table: "DateAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_DateAnswers_Responses_ResponseId",
                table: "DateAnswers",
                column: "ResponseId",
                principalTable: "Responses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateAnswers_Dates_DateId",
                table: "DateAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_DateAnswers_Responses_ResponseId",
                table: "DateAnswers");

            migrationBuilder.DropIndex(
                name: "IX_DateAnswers_DateId",
                table: "DateAnswers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResponseId",
                table: "DateAnswers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_DateAnswers_Responses_ResponseId",
                table: "DateAnswers",
                column: "ResponseId",
                principalTable: "Responses",
                principalColumn: "Id");
        }
    }
}
