using Microsoft.EntityFrameworkCore.Migrations;

namespace TrellosKyBackAPI.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeTasks_TypeTasks_TypeTaskId",
                        column: x => x.TypeTaskId,
                        principalTable: "TypeTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_TypeTasks_TypeTaskId",
                        column: x => x.TypeTaskId,
                        principalTable: "TypeTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TypeTaskId",
                table: "Tasks",
                column: "TypeTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeTasks_TypeTaskId",
                table: "TypeTasks",
                column: "TypeTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TypeTasks");
        }
    }
}
