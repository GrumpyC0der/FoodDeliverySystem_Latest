using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDeliverySystem.Server.Migrations
{
    public partial class qad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Foods_FoodID",
                table: "OrderItems");

            migrationBuilder.AlterColumn<int>(
                name: "FoodID",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Foods_FoodID",
                table: "OrderItems",
                column: "FoodID",
                principalTable: "Foods",
                principalColumn: "FoodID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Foods_FoodID",
                table: "OrderItems");

            migrationBuilder.AlterColumn<int>(
                name: "FoodID",
                table: "OrderItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Foods_FoodID",
                table: "OrderItems",
                column: "FoodID",
                principalTable: "Foods",
                principalColumn: "FoodID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
