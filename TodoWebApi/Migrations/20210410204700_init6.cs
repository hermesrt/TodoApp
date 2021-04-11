using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoWebApi.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_TodoGroup_TaskGroupId",
                table: "Todo");

            migrationBuilder.DropIndex(
                name: "IX_Todo_TaskGroupId",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "TaskGroupId",
                table: "Todo");

            migrationBuilder.AddColumn<long>(
                name: "TodoGroupId",
                table: "Todo",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Todo_TodoGroupId",
                table: "Todo",
                column: "TodoGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_TodoGroup_TodoGroupId",
                table: "Todo",
                column: "TodoGroupId",
                principalTable: "TodoGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_TodoGroup_TodoGroupId",
                table: "Todo");

            migrationBuilder.DropIndex(
                name: "IX_Todo_TodoGroupId",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "TodoGroupId",
                table: "Todo");

            migrationBuilder.AddColumn<long>(
                name: "TaskGroupId",
                table: "Todo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Todo_TaskGroupId",
                table: "Todo",
                column: "TaskGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_TodoGroup_TaskGroupId",
                table: "Todo",
                column: "TaskGroupId",
                principalTable: "TodoGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
