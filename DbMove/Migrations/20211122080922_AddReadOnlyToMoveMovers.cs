using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMove.Migrations
{
    public partial class AddReadOnlyToMoveMovers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReadOnly",
                table: "MoveMovers",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadOnly",
                table: "MoveMovers");
        }
    }
}
