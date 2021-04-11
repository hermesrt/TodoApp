using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoWebApi.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Todo_GroupId",
                table: "Todo",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_TodoGroup_GroupId",
                table: "Todo",
                column: "GroupId",
                principalTable: "TodoGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_TodoGroup_GroupId",
                table: "Todo");

            migrationBuilder.DropIndex(
                name: "IX_Todo_GroupId",
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
    }
}
