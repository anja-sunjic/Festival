using Microsoft.EntityFrameworkCore.Migrations;

namespace Festival.Data.Migrations
{
    public partial class RemovedbadrelationshipPurchasePurchaseVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Purchase_PurchaseID",
                table: "Voucher");

            migrationBuilder.DropIndex(
                name: "IX_Voucher_PurchaseID",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "PurchaseID",
                table: "Voucher");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PurchaseVoucherID",
                table: "Purchase",
                column: "PurchaseVoucherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Voucher_PurchaseVoucherID",
                table: "Purchase",
                column: "PurchaseVoucherID",
                principalTable: "Voucher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Voucher_PurchaseVoucherID",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_PurchaseVoucherID",
                table: "Purchase");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseID",
                table: "Voucher",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_PurchaseID",
                table: "Voucher",
                column: "PurchaseID",
                unique: true,
                filter: "[PurchaseID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Purchase_PurchaseID",
                table: "Voucher",
                column: "PurchaseID",
                principalTable: "Purchase",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
