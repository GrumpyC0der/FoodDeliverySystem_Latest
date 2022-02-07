using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDeliverySystem.Server.Migrations
{
    public partial class wscdc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FoodStoresName",
                table: "FoodStores",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodStoresName",
                table: "FoodStores");
        }
    }
}
