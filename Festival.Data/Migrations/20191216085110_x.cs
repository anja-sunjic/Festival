using Microsoft.EntityFrameworkCore.Migrations;

namespace Festival.Data.Migrations
{
    public partial class x : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMediaLink");

            migrationBuilder.DropColumn(
                name: "logoUrl",
                table: "Sponsor");

            migrationBuilder.DropColumn(
                name: "imgUrl",
                table: "Performer");

            migrationBuilder.DropColumn(
                name: "imgUrl",
                table: "Accommodation");

            migrationBuilder.AddColumn<int>(
                name: "logoId",
                table: "Sponsor",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "imageId",
                table: "Performer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Accommodation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sponsor_logoId",
                table: "Sponsor",
                column: "logoId");

            migrationBuilder.CreateIndex(
                name: "IX_Performer_imageId",
                table: "Performer",
                column: "imageId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodation_ImageId",
                table: "Accommodation",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodation_Image_ImageId",
                table: "Accommodation",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Performer_Image_imageId",
                table: "Performer",
                column: "imageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsor_Image_logoId",
                table: "Sponsor",
                column: "logoId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodation_Image_ImageId",
                table: "Accommodation");

            migrationBuilder.DropForeignKey(
                name: "FK_Performer_Image_imageId",
                table: "Performer");

            migrationBuilder.DropForeignKey(
                name: "FK_Sponsor_Image_logoId",
                table: "Sponsor");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Sponsor_logoId",
                table: "Sponsor");

            migrationBuilder.DropIndex(
                name: "IX_Performer_imageId",
                table: "Performer");

            migrationBuilder.DropIndex(
                name: "IX_Accommodation_ImageId",
                table: "Accommodation");

            migrationBuilder.DropColumn(
                name: "logoId",
                table: "Sponsor");

            migrationBuilder.DropColumn(
                name: "imageId",
                table: "Performer");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Accommodation");

            migrationBuilder.AddColumn<string>(
                name: "logoUrl",
                table: "Sponsor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imgUrl",
                table: "Performer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imgUrl",
                table: "Accommodation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SocialMediaLink",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerformerID = table.Column<int>(type: "int", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaLink_PerformerID",
                table: "SocialMediaLink",
                column: "PerformerID");
        }
    }
}
