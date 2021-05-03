using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoWebApi.Migrations
{
    public partial class mgt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Priority",
                table: "TodoGroup",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Priority",
                table: "Todo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "TodoGroup");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Todo");
        }
    }
}
