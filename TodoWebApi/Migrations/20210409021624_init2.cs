using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoWebApi.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskGroup_TaskGroupId",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskGroup",
                table: "TaskGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "TaskGroup",
                newName: "TodoGroup");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Todo");

            migrationBuilder.RenameIndex(
                name: "IX_Task_TaskGroupId",
                table: "Todo",
                newName: "IX_Todo_TaskGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoGroup",
                table: "TodoGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todo",
                table: "Todo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_TodoGroup_TaskGroupId",
                table: "Todo",
                column: "TaskGroupId",
                principalTable: "TodoGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_TodoGroup_TaskGroupId",
                table: "Todo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoGroup",
                table: "TodoGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todo",
                table: "Todo");

            migrationBuilder.RenameTable(
                name: "TodoGroup",
                newName: "TaskGroup");

            migrationBuilder.RenameTable(
                name: "Todo",
                newName: "Task");

            migrationBuilder.RenameIndex(
                name: "IX_Todo_TaskGroupId",
                table: "Task",
                newName: "IX_Task_TaskGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskGroup",
                table: "TaskGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskGroup_TaskGroupId",
                table: "Task",
                column: "TaskGroupId",
                principalTable: "TaskGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
