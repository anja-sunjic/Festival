using Microsoft.EntityFrameworkCore.Migrations;

namespace Festival.Data.Migrations
{
    public partial class Addedimagetosponsor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendee_UserAccount_UserAccountID",
                table: "Attendee");

            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Performer_PerformerID",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Stage_StageID",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_Performer_Image_ImageID",
                table: "Performer");

            migrationBuilder.DropForeignKey(
                name: "FK_Performer_Manager_ManagerID",
                table: "Performer");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Attendee_AttendeeID",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopItem_Purchase_PurchaseID",
                table: "ShopItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Sponsor_Image_ImageID",
                table: "Sponsor");

            migrationBuilder.DropForeignKey(
                name: "FK_Stage_Sponsor_SponsorID",
                table: "Stage");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Attendee_AttendeeID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketType_TicketTypeID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferReservation_Attendee_AttendeeID",
                table: "TransferReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferReservation_TransferService_TransferServiceID",
                table: "TransferReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Purchase_PurchaseID",
                table: "Voucher");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Ticket_TicketID",
                table: "Voucher");

            migrationBuilder.DropIndex(
                name: "IX_Sponsor_ImageID",
                table: "Sponsor");

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "Sponsor");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Sponsor",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendee_UserAccount_UserAccountID",
                table: "Attendee",
                column: "UserAccountID",
                principalTable: "UserAccount",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Performer_PerformerID",
                table: "Performance",
                column: "PerformerID",
                principalTable: "Performer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Stage_StageID",
                table: "Performance",
                column: "StageID",
                principalTable: "Stage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Performer_Image_ImageID",
                table: "Performer",
                column: "ImageID",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Performer_Manager_ManagerID",
                table: "Performer",
                column: "ManagerID",
                principalTable: "Manager",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Attendee_AttendeeID",
                table: "Purchase",
                column: "AttendeeID",
                principalTable: "Attendee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItem_Purchase_PurchaseID",
                table: "ShopItem",
                column: "PurchaseID",
                principalTable: "Purchase",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stage_Sponsor_SponsorID",
                table: "Stage",
                column: "SponsorID",
                principalTable: "Sponsor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Attendee_AttendeeID",
                table: "Ticket",
                column: "AttendeeID",
                principalTable: "Attendee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketType_TicketTypeID",
                table: "Ticket",
                column: "TicketTypeID",
                principalTable: "TicketType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferReservation_Attendee_AttendeeID",
                table: "TransferReservation",
                column: "AttendeeID",
                principalTable: "Attendee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferReservation_TransferService_TransferServiceID",
                table: "TransferReservation",
                column: "TransferServiceID",
                principalTable: "TransferService",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Purchase_PurchaseID",
                table: "Voucher",
                column: "PurchaseID",
                principalTable: "Purchase",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Ticket_TicketID",
                table: "Voucher",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendee_UserAccount_UserAccountID",
                table: "Attendee");

            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Performer_PerformerID",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Stage_StageID",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_Performer_Image_ImageID",
                table: "Performer");

            migrationBuilder.DropForeignKey(
                name: "FK_Performer_Manager_ManagerID",
                table: "Performer");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Attendee_AttendeeID",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopItem_Purchase_PurchaseID",
                table: "ShopItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Stage_Sponsor_SponsorID",
                table: "Stage");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Attendee_AttendeeID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketType_TicketTypeID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferReservation_Attendee_AttendeeID",
                table: "TransferReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferReservation_TransferService_TransferServiceID",
                table: "TransferReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Purchase_PurchaseID",
                table: "Voucher");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Ticket_TicketID",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Sponsor");

            migrationBuilder.AddColumn<int>(
                name: "ImageID",
                table: "Sponsor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sponsor_ImageID",
                table: "Sponsor",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendee_UserAccount_UserAccountID",
                table: "Attendee",
                column: "UserAccountID",
                principalTable: "UserAccount",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Performer_PerformerID",
                table: "Performance",
                column: "PerformerID",
                principalTable: "Performer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Stage_StageID",
                table: "Performance",
                column: "StageID",
                principalTable: "Stage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Performer_Image_ImageID",
                table: "Performer",
                column: "ImageID",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Performer_Manager_ManagerID",
                table: "Performer",
                column: "ManagerID",
                principalTable: "Manager",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Attendee_AttendeeID",
                table: "Purchase",
                column: "AttendeeID",
                principalTable: "Attendee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItem_Purchase_PurchaseID",
                table: "ShopItem",
                column: "PurchaseID",
                principalTable: "Purchase",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsor_Image_ImageID",
                table: "Sponsor",
                column: "ImageID",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stage_Sponsor_SponsorID",
                table: "Stage",
                column: "SponsorID",
                principalTable: "Sponsor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Attendee_AttendeeID",
                table: "Ticket",
                column: "AttendeeID",
                principalTable: "Attendee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketType_TicketTypeID",
                table: "Ticket",
                column: "TicketTypeID",
                principalTable: "TicketType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferReservation_Attendee_AttendeeID",
                table: "TransferReservation",
                column: "AttendeeID",
                principalTable: "Attendee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferReservation_TransferService_TransferServiceID",
                table: "TransferReservation",
                column: "TransferServiceID",
                principalTable: "TransferService",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Purchase_PurchaseID",
                table: "Voucher",
                column: "PurchaseID",
                principalTable: "Purchase",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Ticket_TicketID",
                table: "Voucher",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
