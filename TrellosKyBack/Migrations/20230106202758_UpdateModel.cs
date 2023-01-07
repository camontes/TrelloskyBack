using Microsoft.EntityFrameworkCore.Migrations;

namespace TrellosKyBackAPI.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeTasks_TypeTasks_TypeTaskId",
                table: "TypeTasks");

            migrationBuilder.DropIndex(
                name: "IX_TypeTasks_TypeTaskId",
                table: "TypeTasks");

            migrationBuilder.DropColumn(
                name: "TypeTaskId",
                table: "TypeTasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeTaskId",
                table: "TypeTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeTasks_TypeTaskId",
                table: "TypeTasks",
                column: "TypeTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeTasks_TypeTasks_TypeTaskId",
                table: "TypeTasks",
                column: "TypeTaskId",
                principalTable: "TypeTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
