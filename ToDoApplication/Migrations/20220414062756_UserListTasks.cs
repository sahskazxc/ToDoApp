using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApplication.Migrations
{
    public partial class UserListTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TaskDbs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskDbs_UserId",
                table: "TaskDbs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDbs_Users_UserId",
                table: "TaskDbs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskDbs_Users_UserId",
                table: "TaskDbs");

            migrationBuilder.DropIndex(
                name: "IX_TaskDbs_UserId",
                table: "TaskDbs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskDbs");
        }
    }
}
