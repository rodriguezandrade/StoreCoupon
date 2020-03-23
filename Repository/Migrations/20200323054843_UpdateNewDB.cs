using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class UpdateNewDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriesStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesStore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "General_Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_General_Categories", x => x.Id);
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
                    Name = table.Column<string>(maxLength: 30, nullable: false)
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
                        name: "FK_SubCategories_General_Categories_IdSubCat",
                        column: x => x.IdSubCat,
                        principalTable: "General_Categories",
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
                name: "Stores_Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdStore = table.Column<Guid>(nullable: false),
                    IdCategoryStore = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Categories_CategoriesStore_IdCategoryStore",
                        column: x => x.IdCategoryStore,
                        principalTable: "CategoriesStore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stores_Categories_Stores_IdStore",
                        column: x => x.IdStore,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 220, nullable: false),
                    Price = table.Column<int>(nullable: false),
                    IdProduct = table.Column<Guid>(nullable: false),
                    IdStoreCategory = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Stores_Categories_IdStoreCategory",
                        column: x => x.IdStoreCategory,
                        principalTable: "Stores_Categories",
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
                    Discount = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    IdProductDtl = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_ProductDetails_IdProductDtl",
                        column: x => x.IdProductDtl,
                        principalTable: "ProductDetails",
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

            migrationBuilder.CreateIndex(
                name: "IX_CouponBooks_IdCoupon",
                table: "CouponBooks",
                column: "IdCoupon");

            migrationBuilder.CreateIndex(
                name: "IX_CouponBooks_IdUser",
                table: "CouponBooks",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_IdProductDtl",
                table: "Coupons",
                column: "IdProductDtl");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_IdProduct",
                table: "ProductDetails",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_IdStoreCategory",
                table: "ProductDetails",
                column: "IdStoreCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_IdOwner",
                table: "Stores",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_SubCategoryId",
                table: "Stores",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Categories_IdCategoryStore",
                table: "Stores_Categories",
                column: "IdCategoryStore");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Categories_IdStore",
                table: "Stores_Categories",
                column: "IdStore");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_IdSubCat",
                table: "SubCategories",
                column: "IdSubCat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouponBooks");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores_Categories");

            migrationBuilder.DropTable(
                name: "CategoriesStore");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "General_Categories");
        }
    }
}
