using Microsoft.EntityFrameworkCore.Migrations;

namespace SlijterijSjonnieLoper.Data.Migrations
{
    public partial class testClass2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FavoriteDrink",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoriteDrink",
                table: "AspNetUsers");
        }
    }
}
