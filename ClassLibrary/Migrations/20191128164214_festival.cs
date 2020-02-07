using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Festival.Data.Migrations
{
    public partial class festival : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accommodation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    distance = table.Column<float>(nullable: false),
                    imgUrl = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sponsor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(nullable: true),
                    logoUrl = table.Column<string>(nullable: true),
                    contactPersonName = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TicketType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransferVehicle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    registrationNumber = table.Column<string>(nullable: true),
                    capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferVehicle", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Performer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    fee = table.Column<float>(nullable: false),
                    promoText = table.Column<string>(nullable: true),
                    imgUrl = table.Column<string>(nullable: true),
                    managerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Performer_Manager_managerID",
                        column: x => x.managerID,
                        principalTable: "Manager",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    capacity = table.Column<int>(nullable: false),
                    sponsorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stage_Sponsor_sponsorID",
                        column: x => x.sponsorID,
                        principalTable: "Sponsor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferService",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datum = table.Column<DateTime>(nullable: false),
                    numberOfAvailableSeats = table.Column<int>(nullable: false),
                    transferVehicleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferService", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransferService_TransferVehicle_transferVehicleID",
                        column: x => x.transferVehicleID,
                        principalTable: "TransferVehicle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attendee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    accountID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attendee_UserAccount_accountID",
                        column: x => x.accountID,
                        principalTable: "UserAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaLink",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    link = table.Column<string>(nullable: true),
                    PerformerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaLink", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SocialMediaLink_Performer_PerformerID",
                        column: x => x.PerformerID,
                        principalTable: "Performer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Performance",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start = table.Column<DateTime>(nullable: false),
                    stageID = table.Column<int>(nullable: true),
                    performerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Performance_Performer_performerID",
                        column: x => x.performerID,
                        principalTable: "Performer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Performance_Stage_stageID",
                        column: x => x.stageID,
                        principalTable: "Stage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attendeeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Purchase_Attendee_attendeeID",
                        column: x => x.attendeeID,
                        principalTable: "Attendee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeID = table.Column<int>(nullable: true),
                    attendeeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ticket_Attendee_attendeeID",
                        column: x => x.attendeeID,
                        principalTable: "Attendee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketType_typeID",
                        column: x => x.typeID,
                        principalTable: "TicketType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferReservation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attendeeID = table.Column<int>(nullable: true),
                    transferServiceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferReservation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransferReservation_Attendee_attendeeID",
                        column: x => x.attendeeID,
                        principalTable: "Attendee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferReservation_TransferService_transferServiceID",
                        column: x => x.transferServiceID,
                        principalTable: "TransferService",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShopItem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    price = table.Column<float>(nullable: false),
                    imgUrl = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    PurchaseID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShopItem_Purchase_PurchaseID",
                        column: x => x.PurchaseID,
                        principalTable: "Purchase",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    saleDate = table.Column<DateTime>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    purchaseID = table.Column<int>(nullable: true),
                    ticketID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Voucher_Purchase_purchaseID",
                        column: x => x.purchaseID,
                        principalTable: "Purchase",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voucher_Ticket_ticketID",
                        column: x => x.ticketID,
                        principalTable: "Ticket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_accountID",
                table: "Attendee",
                column: "accountID");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_performerID",
                table: "Performance",
                column: "performerID");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_stageID",
                table: "Performance",
                column: "stageID");

            migrationBuilder.CreateIndex(
                name: "IX_Performer_managerID",
                table: "Performer",
                column: "managerID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_attendeeID",
                table: "Purchase",
                column: "attendeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItem_PurchaseID",
                table: "ShopItem",
                column: "PurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaLink_PerformerID",
                table: "SocialMediaLink",
                column: "PerformerID");

            migrationBuilder.CreateIndex(
                name: "IX_Stage_sponsorID",
                table: "Stage",
                column: "sponsorID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_attendeeID",
                table: "Ticket",
                column: "attendeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_typeID",
                table: "Ticket",
                column: "typeID");

            migrationBuilder.CreateIndex(
                name: "IX_TransferReservation_attendeeID",
                table: "TransferReservation",
                column: "attendeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TransferReservation_transferServiceID",
                table: "TransferReservation",
                column: "transferServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_TransferService_transferVehicleID",
                table: "TransferService",
                column: "transferVehicleID");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accommodation");

            migrationBuilder.DropTable(
                name: "Performance");

            migrationBuilder.DropTable(
                name: "ShopItem");

            migrationBuilder.DropTable(
                name: "SocialMediaLink");

            migrationBuilder.DropTable(
                name: "TransferReservation");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "Stage");

            migrationBuilder.DropTable(
                name: "Performer");

            migrationBuilder.DropTable(
                name: "TransferService");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Sponsor");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "TransferVehicle");

            migrationBuilder.DropTable(
                name: "Attendee");

            migrationBuilder.DropTable(
                name: "TicketType");

            migrationBuilder.DropTable(
                name: "UserAccount");
        }
    }
}
