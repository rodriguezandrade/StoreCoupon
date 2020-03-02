using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class rebuilddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesStore_Stores_StoreId",
                table: "CategoriesStore");

            migrationBuilder.DropIndex(
                name: "IX_CategoriesStore_StoreId",
                table: "CategoriesStore");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "CategoriesStore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "CategoriesStore",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesStore_StoreId",
                table: "CategoriesStore",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesStore_Stores_StoreId",
                table: "CategoriesStore",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
