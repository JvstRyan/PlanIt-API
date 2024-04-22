using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanIt.API.Migrations
{
    /// <inheritdoc />
    public partial class modelupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateAnswers_Dates_DateId",
                table: "DateAnswers");

            migrationBuilder.DropIndex(
                name: "IX_DateAnswers_DateId",
                table: "DateAnswers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
