using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REPOSITORY.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdForOrderTbl_OrderTbl_Order_Id",
                table: "ProdForOrderTbl");

            migrationBuilder.DropIndex(
                name: "IX_ProdForOrderTbl_Order_Id",
                table: "ProdForOrderTbl");

            migrationBuilder.DropColumn(
                name: "Order_Id",
                table: "ProdForOrderTbl");

            migrationBuilder.AddColumn<double>(
                name: "Sum",
                table: "OrderTbl",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_ProdForOrderTbl_OrderId",
                table: "ProdForOrderTbl",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdForOrderTbl_OrderTbl_OrderId",
                table: "ProdForOrderTbl",
                column: "OrderId",
                principalTable: "OrderTbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdForOrderTbl_OrderTbl_OrderId",
                table: "ProdForOrderTbl");

            migrationBuilder.DropIndex(
                name: "IX_ProdForOrderTbl_OrderId",
                table: "ProdForOrderTbl");

            migrationBuilder.DropColumn(
                name: "Sum",
                table: "OrderTbl");

            migrationBuilder.AddColumn<int>(
                name: "Order_Id",
                table: "ProdForOrderTbl",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProdForOrderTbl_Order_Id",
                table: "ProdForOrderTbl",
                column: "Order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdForOrderTbl_OrderTbl_Order_Id",
                table: "ProdForOrderTbl",
                column: "Order_Id",
                principalTable: "OrderTbl",
                principalColumn: "Id");
        }
    }
}
