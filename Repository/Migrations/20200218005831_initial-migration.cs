using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 40, nullable: false),
                    LastName = table.Column<string>(maxLength: 40, nullable: false),
                    Address = table.Column<string>(maxLength: 120, nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    Telephone = table.Column<int>(nullable: false),
                    RFC = table.Column<string>(maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 120, nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 40, nullable: false),
                    LastName = table.Column<string>(maxLength: 40, nullable: false),
                    Address = table.Column<string>(maxLength: 120, nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    Telephone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Description = table.Column<string>(maxLength: 120, nullable: false),
                    IdSubCat = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_IdSubCat",
                        column: x => x.IdSubCat,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Status = table.Column<string>(nullable: false),
                    IdProduct = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    FiscalName = table.Column<string>(maxLength: 120, nullable: false),
                    Address = table.Column<string>(maxLength: 120, nullable: false),
                    Telephone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    RFC = table.Column<string>(maxLength: 12, nullable: false),
                    SubCategoryId = table.Column<Guid>(nullable: false),
                    IdOwner = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Owners_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stores_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CouponBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false),
                    IdCoupon = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouponBooks_Coupons_IdCoupon",
                        column: x => x.IdCoupon,
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponBooks_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryStores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    IdStore = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategoryStores_Stores_IdStore",
                        column: x => x.IdStore,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores_SubCategoryStores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    IdStore = table.Column<Guid>(nullable: false),
                    IdSubCategoryStore = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores_SubCategoryStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_SubCategoryStores_Stores_IdStore",
                        column: x => x.IdStore,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Stores_SubCategoryStores_SubCategoryStores_IdSubCategoryStore",
                        column: x => x.IdSubCategoryStore,
                        principalTable: "SubCategoryStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory_Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    IdSubCategoryStore = table.Column<Guid>(nullable: false),
                    IdProduct = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Products_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SubCategory_Products_SubCategoryStores_IdSubCategoryStore",
                        column: x => x.IdSubCategoryStore,
                        principalTable: "SubCategoryStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CouponBooks_IdCoupon",
                table: "CouponBooks",
                column: "IdCoupon");

            migrationBuilder.CreateIndex(
                name: "IX_CouponBooks_IdUser",
                table: "CouponBooks",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_IdProduct",
                table: "Coupons",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_IdOwner",
                table: "Stores",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_SubCategoryId",
                table: "Stores",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_SubCategoryStores_IdStore",
                table: "Stores_SubCategoryStores",
                column: "IdStore");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_SubCategoryStores_IdSubCategoryStore",
                table: "Stores_SubCategoryStores",
                column: "IdSubCategoryStore");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_IdSubCat",
                table: "SubCategories",
                column: "IdSubCat");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_Products_IdProduct",
                table: "SubCategory_Products",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_Products_IdSubCategoryStore",
                table: "SubCategory_Products",
                column: "IdSubCategoryStore");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryStores_IdStore",
                table: "SubCategoryStores",
                column: "IdStore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouponBooks");

            migrationBuilder.DropTable(
                name: "Stores_SubCategoryStores");

            migrationBuilder.DropTable(
                name: "SubCategory_Products");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SubCategoryStores");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
