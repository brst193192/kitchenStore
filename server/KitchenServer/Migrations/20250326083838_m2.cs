using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REPOSITORY.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address_BuildNumber = table.Column<int>(type: "int", nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_HouseNumber = table.Column<int>(type: "int", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountInStock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTbl_CategoryTbl_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdForCartTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsSelect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdForCartTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdForCartTbl_ProductTbl_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdForOrderTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdForOrderTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdForOrderTbl_OrderTbl_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdForOrderTbl_ProductTbl_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdForCartTbl_ProductId",
                table: "ProdForCartTbl",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdForOrderTbl_OrderId",
                table: "ProdForOrderTbl",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdForOrderTbl_ProductId",
                table: "ProdForOrderTbl",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTbl_CategoryId",
                table: "ProductTbl",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdForCartTbl");

            migrationBuilder.DropTable(
                name: "ProdForOrderTbl");

            migrationBuilder.DropTable(
                name: "UserTbl");

            migrationBuilder.DropTable(
                name: "OrderTbl");

            migrationBuilder.DropTable(
                name: "ProductTbl");

            migrationBuilder.DropTable(
                name: "CategoryTbl");
        }
    }
}
