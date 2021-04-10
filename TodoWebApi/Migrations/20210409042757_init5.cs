using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoWebApi.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "TodoGroup",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Todo",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Password = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoGroup_UserId",
                table: "TodoGroup",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Todo_UserId",
                table: "Todo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_User_UserId",
                table: "Todo",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoGroup_User_UserId",
                table: "TodoGroup",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_User_UserId",
                table: "Todo");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoGroup_User_UserId",
                table: "TodoGroup");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_TodoGroup_UserId",
                table: "TodoGroup");

            migrationBuilder.DropIndex(
                name: "IX_Todo_UserId",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TodoGroup");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Todo");
        }
    }
}
