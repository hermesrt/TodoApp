using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoWebApi.Migrations
{
    public partial class init0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoGroup_User_UserId",
                table: "TodoGroup");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "TodoGroup",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GroupId",
                table: "Todo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Todo",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoGroup_User_UserId",
                table: "TodoGroup",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoGroup_User_UserId",
                table: "TodoGroup");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Todo");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "TodoGroup",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoGroup_User_UserId",
                table: "TodoGroup",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
