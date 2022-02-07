using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDeliverySystem.Server.Migrations
{
    public partial class swwws : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodStores_FoodStoresID",
                table: "Foods");

            migrationBuilder.AlterColumn<int>(
                name: "FoodStoresID",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodStores_FoodStoresID",
                table: "Foods",
                column: "FoodStoresID",
                principalTable: "FoodStores",
                principalColumn: "FoodStoresID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodStores_FoodStoresID",
                table: "Foods");

            migrationBuilder.AlterColumn<int>(
                name: "FoodStoresID",
                table: "Foods",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodStores_FoodStoresID",
                table: "Foods",
                column: "FoodStoresID",
                principalTable: "FoodStores",
                principalColumn: "FoodStoresID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
