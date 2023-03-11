using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_Cheats_App.Migrations.GameCheatsDb
{
    public partial class AddCheatDescr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CheatDescription",
                table: "Cheats",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheatDescription",
                table: "Cheats");
        }
    }
}
