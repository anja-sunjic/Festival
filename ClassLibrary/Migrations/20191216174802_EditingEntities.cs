using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Festival.Data.Migrations
{
    public partial class EditingEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodation_Image_ImageId",
                table: "Accommodation");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendee_UserAccount_accountID",
                table: "Attendee");

            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Performer_performerID",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Stage_stageID",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_Performer_Image_imageId",
                table: "Performer");

            migrationBuilder.DropForeignKey(
                name: "FK_Performer_Manager_managerID",
                table: "Performer");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Attendee_attendeeID",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Sponsor_Image_logoId",
                table: "Sponsor");

            migrationBuilder.DropForeignKey(
                name: "FK_Stage_Sponsor_sponsorID",
                table: "Stage");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Attendee_attendeeID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketType_typeID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferReservation_Attendee_attendeeID",
                table: "TransferReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferReservation_TransferService_transferServiceID",
                table: "TransferReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferService_TransferVehicle_transferVehicleID",
                table: "TransferService");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Purchase_purchaseID",
                table: "Voucher");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Ticket_ticketID",
                table: "Voucher");

            migrationBuilder.DropIndex(
                name: "IX_Voucher_purchaseID",
                table: "Voucher");

            migrationBuilder.DropIndex(
                name: "IX_Voucher_ticketID",
                table: "Voucher");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_typeID",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Sponsor_logoId",
                table: "Sponsor");

            migrationBuilder.DropIndex(
                name: "IX_Attendee_accountID",
                table: "Attendee");

            migrationBuilder.DropColumn(
                name: "datum",
                table: "TransferService");

            migrationBuilder.DropColumn(
                name: "typeID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "logoId",
                table: "Sponsor");

            migrationBuilder.DropColumn(
                name: "imgUrl",
                table: "ShopItem");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "accountID",
                table: "Attendee");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Voucher",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "saleDate",
                table: "Voucher",
                newName: "SaleDate");

            migrationBuilder.RenameColumn(
                name: "ticketID",
                table: "Voucher",
                newName: "TicketID");

            migrationBuilder.RenameColumn(
                name: "purchaseID",
                table: "Voucher",
                newName: "PurchaseID");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "UserAccount",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "UserAccount",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "UserAccount",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "registrationNumber",
                table: "TransferVehicle",
                newName: "RegistrationNumber");

            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "TransferVehicle",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "transferVehicleID",
                table: "TransferService",
                newName: "TransferVehicleID");

            migrationBuilder.RenameColumn(
                name: "numberOfAvailableSeats",
                table: "TransferService",
                newName: "NumberOfAvailableSeats");

            migrationBuilder.RenameIndex(
                name: "IX_TransferService_transferVehicleID",
                table: "TransferService",
                newName: "IX_TransferService_TransferVehicleID");

            migrationBuilder.RenameColumn(
                name: "transferServiceID",
                table: "TransferReservation",
                newName: "TransferServiceID");

            migrationBuilder.RenameColumn(
                name: "attendeeID",
                table: "TransferReservation",
                newName: "AttendeeID");

            migrationBuilder.RenameIndex(
                name: "IX_TransferReservation_transferServiceID",
                table: "TransferReservation",
                newName: "IX_TransferReservation_TransferServiceID");

            migrationBuilder.RenameIndex(
                name: "IX_TransferReservation_attendeeID",
                table: "TransferReservation",
                newName: "IX_TransferReservation_AttendeeID");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "TicketType",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "TicketType",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "attendeeID",
                table: "Ticket",
                newName: "AttendeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_attendeeID",
                table: "Ticket",
                newName: "IX_Ticket_AttendeeID");

            migrationBuilder.RenameColumn(
                name: "sponsorID",
                table: "Stage",
                newName: "SponsorID");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Stage",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "Stage",
                newName: "Capacity");

            migrationBuilder.RenameIndex(
                name: "IX_Stage_sponsorID",
                table: "Stage",
                newName: "IX_Stage_SponsorID");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Sponsor",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "contactPersonName",
                table: "Sponsor",
                newName: "ContactPersonName");

            migrationBuilder.RenameColumn(
                name: "companyName",
                table: "Sponsor",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Sponsor",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "ShopItem",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "ShopItem",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ShopItem",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "ShopItem",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "attendeeID",
                table: "Purchase",
                newName: "AttendeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_attendeeID",
                table: "Purchase",
                newName: "IX_Purchase_AttendeeID");

            migrationBuilder.RenameColumn(
                name: "promoText",
                table: "Performer",
                newName: "PromoText");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Performer",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "managerID",
                table: "Performer",
                newName: "ManagerID");

            migrationBuilder.RenameColumn(
                name: "imageId",
                table: "Performer",
                newName: "ImageID");

            migrationBuilder.RenameColumn(
                name: "fee",
                table: "Performer",
                newName: "Fee");

            migrationBuilder.RenameIndex(
                name: "IX_Performer_managerID",
                table: "Performer",
                newName: "IX_Performer_ManagerID");

            migrationBuilder.RenameIndex(
                name: "IX_Performer_imageId",
                table: "Performer",
                newName: "IX_Performer_ImageID");

            migrationBuilder.RenameColumn(
                name: "start",
                table: "Performance",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "stageID",
                table: "Performance",
                newName: "StageID");

            migrationBuilder.RenameColumn(
                name: "performerID",
                table: "Performance",
                newName: "PerformerID");

            migrationBuilder.RenameIndex(
                name: "IX_Performance_stageID",
                table: "Performance",
                newName: "IX_Performance_StageID");

            migrationBuilder.RenameIndex(
                name: "IX_Performance_performerID",
                table: "Performance",
                newName: "IX_Performance_PerformerID");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Manager",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Manager",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Manager",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Attendee",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Attendee",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Attendee",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Attendee",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Accommodation",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Accommodation",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "distance",
                table: "Accommodation",
                newName: "Distance");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Accommodation",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Accommodation",
                newName: "ImageID");

            migrationBuilder.RenameIndex(
                name: "IX_Accommodation_ImageId",
                table: "Accommodation",
                newName: "IX_Accommodation_ImageID");

            migrationBuilder.AddColumn<int>(
                name: "VoucherTypeID",
                table: "Voucher",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeID",
                table: "UserAccount",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TransferService",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TicketTypeID",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketVoucherID",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageID",
                table: "Sponsor",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageID",
                table: "ShopItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseVoucherID",
                table: "Purchase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Image",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAccountID",
                table: "Attendee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_PurchaseID",
                table: "Voucher",
                column: "PurchaseID",
                unique: true,
                filter: "[PurchaseID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_TicketID",
                table: "Voucher",
                column: "TicketID",
                unique: true,
                filter: "[TicketID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TicketTypeID",
                table: "Ticket",
                column: "TicketTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsor_ImageID",
                table: "Sponsor",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItem_ImageID",
                table: "ShopItem",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_UserAccountID",
                table: "Attendee",
                column: "UserAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodation_Image_ImageID",
                table: "Accommodation",
                column: "ImageID",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_ShopItem_Image_ImageID",
                table: "ShopItem",
                column: "ImageID",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsor_Image_ImageID",
                table: "Sponsor",
                column: "ImageID",
                principalTable: "Image",
                principalColumn: "Id",
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
                name: "FK_TransferService_TransferVehicle_TransferVehicleID",
                table: "TransferService",
                column: "TransferVehicleID",
                principalTable: "TransferVehicle",
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
                name: "FK_Accommodation_Image_ImageID",
                table: "Accommodation");

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
                name: "FK_ShopItem_Image_ImageID",
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
                name: "FK_TransferService_TransferVehicle_TransferVehicleID",
                table: "TransferService");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Purchase_PurchaseID",
                table: "Voucher");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Ticket_TicketID",
                table: "Voucher");

            migrationBuilder.DropIndex(
                name: "IX_Voucher_PurchaseID",
                table: "Voucher");

            migrationBuilder.DropIndex(
                name: "IX_Voucher_TicketID",
                table: "Voucher");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_TicketTypeID",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Sponsor_ImageID",
                table: "Sponsor");

            migrationBuilder.DropIndex(
                name: "IX_ShopItem_ImageID",
                table: "ShopItem");

            migrationBuilder.DropIndex(
                name: "IX_Attendee_UserAccountID",
                table: "Attendee");

            migrationBuilder.DropColumn(
                name: "VoucherTypeID",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "AccountTypeID",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TransferService");

            migrationBuilder.DropColumn(
                name: "TicketTypeID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "TicketVoucherID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "Sponsor");

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "ShopItem");

            migrationBuilder.DropColumn(
                name: "PurchaseVoucherID",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "UserAccountID",
                table: "Attendee");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Voucher",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "SaleDate",
                table: "Voucher",
                newName: "saleDate");

            migrationBuilder.RenameColumn(
                name: "TicketID",
                table: "Voucher",
                newName: "ticketID");

            migrationBuilder.RenameColumn(
                name: "PurchaseID",
                table: "Voucher",
                newName: "purchaseID");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "UserAccount",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "UserAccount",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "UserAccount",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "RegistrationNumber",
                table: "TransferVehicle",
                newName: "registrationNumber");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "TransferVehicle",
                newName: "capacity");

            migrationBuilder.RenameColumn(
                name: "TransferVehicleID",
                table: "TransferService",
                newName: "transferVehicleID");

            migrationBuilder.RenameColumn(
                name: "NumberOfAvailableSeats",
                table: "TransferService",
                newName: "numberOfAvailableSeats");

            migrationBuilder.RenameIndex(
                name: "IX_TransferService_TransferVehicleID",
                table: "TransferService",
                newName: "IX_TransferService_transferVehicleID");

            migrationBuilder.RenameColumn(
                name: "TransferServiceID",
                table: "TransferReservation",
                newName: "transferServiceID");

            migrationBuilder.RenameColumn(
                name: "AttendeeID",
                table: "TransferReservation",
                newName: "attendeeID");

            migrationBuilder.RenameIndex(
                name: "IX_TransferReservation_TransferServiceID",
                table: "TransferReservation",
                newName: "IX_TransferReservation_transferServiceID");

            migrationBuilder.RenameIndex(
                name: "IX_TransferReservation_AttendeeID",
                table: "TransferReservation",
                newName: "IX_TransferReservation_attendeeID");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "TicketType",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TicketType",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "AttendeeID",
                table: "Ticket",
                newName: "attendeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_AttendeeID",
                table: "Ticket",
                newName: "IX_Ticket_attendeeID");

            migrationBuilder.RenameColumn(
                name: "SponsorID",
                table: "Stage",
                newName: "sponsorID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stage",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Stage",
                newName: "capacity");

            migrationBuilder.RenameIndex(
                name: "IX_Stage_SponsorID",
                table: "Stage",
                newName: "IX_Stage_sponsorID");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Sponsor",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "ContactPersonName",
                table: "Sponsor",
                newName: "contactPersonName");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Sponsor",
                newName: "companyName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Sponsor",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ShopItem",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ShopItem",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ShopItem",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ShopItem",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "AttendeeID",
                table: "Purchase",
                newName: "attendeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_AttendeeID",
                table: "Purchase",
                newName: "IX_Purchase_attendeeID");

            migrationBuilder.RenameColumn(
                name: "PromoText",
                table: "Performer",
                newName: "promoText");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Performer",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ManagerID",
                table: "Performer",
                newName: "managerID");

            migrationBuilder.RenameColumn(
                name: "ImageID",
                table: "Performer",
                newName: "imageId");

            migrationBuilder.RenameColumn(
                name: "Fee",
                table: "Performer",
                newName: "fee");

            migrationBuilder.RenameIndex(
                name: "IX_Performer_ManagerID",
                table: "Performer",
                newName: "IX_Performer_managerID");

            migrationBuilder.RenameIndex(
                name: "IX_Performer_ImageID",
                table: "Performer",
                newName: "IX_Performer_imageId");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Performance",
                newName: "start");

            migrationBuilder.RenameColumn(
                name: "StageID",
                table: "Performance",
                newName: "stageID");

            migrationBuilder.RenameColumn(
                name: "PerformerID",
                table: "Performance",
                newName: "performerID");

            migrationBuilder.RenameIndex(
                name: "IX_Performance_StageID",
                table: "Performance",
                newName: "IX_Performance_stageID");

            migrationBuilder.RenameIndex(
                name: "IX_Performance_PerformerID",
                table: "Performance",
                newName: "IX_Performance_performerID");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Manager",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Manager",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Manager",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Attendee",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Attendee",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Attendee",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Attendee",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Accommodation",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Accommodation",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ImageID",
                table: "Accommodation",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "Distance",
                table: "Accommodation",
                newName: "distance");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Accommodation",
                newName: "description");

            migrationBuilder.RenameIndex(
                name: "IX_Accommodation_ImageID",
                table: "Accommodation",
                newName: "IX_Accommodation_ImageId");

            migrationBuilder.AddColumn<DateTime>(
                name: "datum",
                table: "TransferService",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "typeID",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "logoId",
                table: "Sponsor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imgUrl",
                table: "ShopItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Image",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "accountID",
                table: "Attendee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_purchaseID",
                table: "Voucher",
                column: "purchaseID",
                unique: true,
                filter: "[purchaseID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_ticketID",
                table: "Voucher",
                column: "ticketID",
                unique: true,
                filter: "[ticketID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_typeID",
                table: "Ticket",
                column: "typeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsor_logoId",
                table: "Sponsor",
                column: "logoId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_accountID",
                table: "Attendee",
                column: "accountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodation_Image_ImageId",
                table: "Accommodation",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendee_UserAccount_accountID",
                table: "Attendee",
                column: "accountID",
                principalTable: "UserAccount",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Performer_performerID",
                table: "Performance",
                column: "performerID",
                principalTable: "Performer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Stage_stageID",
                table: "Performance",
                column: "stageID",
                principalTable: "Stage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Performer_Image_imageId",
                table: "Performer",
                column: "imageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Performer_Manager_managerID",
                table: "Performer",
                column: "managerID",
                principalTable: "Manager",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Attendee_attendeeID",
                table: "Purchase",
                column: "attendeeID",
                principalTable: "Attendee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsor_Image_logoId",
                table: "Sponsor",
                column: "logoId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stage_Sponsor_sponsorID",
                table: "Stage",
                column: "sponsorID",
                principalTable: "Sponsor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Attendee_attendeeID",
                table: "Ticket",
                column: "attendeeID",
                principalTable: "Attendee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketType_typeID",
                table: "Ticket",
                column: "typeID",
                principalTable: "TicketType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferReservation_Attendee_attendeeID",
                table: "TransferReservation",
                column: "attendeeID",
                principalTable: "Attendee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferReservation_TransferService_transferServiceID",
                table: "TransferReservation",
                column: "transferServiceID",
                principalTable: "TransferService",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferService_TransferVehicle_transferVehicleID",
                table: "TransferService",
                column: "transferVehicleID",
                principalTable: "TransferVehicle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Purchase_purchaseID",
                table: "Voucher",
                column: "purchaseID",
                principalTable: "Purchase",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Ticket_ticketID",
                table: "Voucher",
                column: "ticketID",
                principalTable: "Ticket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
