using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMove.Migrations
{
    public partial class ChangeSportIdTypeToLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_Sports_SportId1",
                table: "Moves");

            migrationBuilder.DropIndex(
                name: "IX_Moves_SportId1",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "SportId1",
                table: "Moves");

            migrationBuilder.AlterColumn<long>(
                name: "SportId",
                table: "Moves",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_SportId",
                table: "Moves",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_Sports_SportId",
                table: "Moves",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_Sports_SportId",
                table: "Moves");

            migrationBuilder.DropIndex(
                name: "IX_Moves_SportId",
                table: "Moves");

            migrationBuilder.AlterColumn<int>(
                name: "SportId",
                table: "Moves",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "SportId1",
                table: "Moves",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Moves_SportId1",
                table: "Moves",
                column: "SportId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_Sports_SportId1",
                table: "Moves",
                column: "SportId1",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
