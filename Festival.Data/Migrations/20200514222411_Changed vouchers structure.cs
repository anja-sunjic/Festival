using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Festival.Data.Migrations
{
    public partial class Changedvouchersstructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Ticket_TicketID",
                table: "Voucher");

            migrationBuilder.DropIndex(
                name: "IX_Voucher_TicketID",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "TicketID",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "SaleDate",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "VoucherTypeID",
                table: "Voucher");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Voucher",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Voucher",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRedeemedVouchers",
                table: "Voucher",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VoucherCode",
                table: "Voucher",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TicketVoucherID",
                table: "Ticket",
                column: "TicketVoucherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Voucher_TicketVoucherID",
                table: "Ticket",
                column: "TicketVoucherID",
                principalTable: "Voucher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Voucher_TicketVoucherID",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_TicketVoucherID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "NumberOfRedeemedVouchers",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "VoucherCode",
                table: "Voucher");

            migrationBuilder.AddColumn<int>(
                name: "TicketID",
                table: "Voucher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SaleDate",
                table: "Voucher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Voucher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VoucherTypeID",
                table: "Voucher",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_TicketID",
                table: "Voucher",
                column: "TicketID",
                unique: true,
                filter: "[TicketID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Ticket_TicketID",
                table: "Voucher",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
