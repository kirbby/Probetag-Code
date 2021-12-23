using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMove.Migrations
{
    public partial class AddMoveMover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Distance",
                table: "MoveMovers",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "MoveMovers");
        }
    }
}
