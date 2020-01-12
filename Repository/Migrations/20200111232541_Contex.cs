using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Contex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouponBooks_Products_ProductId1",
                table: "CouponBooks");

            migrationBuilder.DropIndex(
                name: "IX_CouponBooks_ProductId1",
                table: "CouponBooks");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "CouponBooks");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_CouponBooks_ProductId",
                table: "CouponBooks",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CouponBooks_Products_ProductId",
                table: "CouponBooks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouponBooks_Products_ProductId",
                table: "CouponBooks");

            migrationBuilder.DropIndex(
                name: "IX_CouponBooks_ProductId",
                table: "CouponBooks");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "CouponBooks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CouponBooks_ProductId1",
                table: "CouponBooks",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CouponBooks_Products_ProductId1",
                table: "CouponBooks",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
