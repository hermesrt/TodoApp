using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoWebApi.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Names",
                table: "TodoGroup",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TodoGroup",
                newName: "Names");
        }
    }
}
