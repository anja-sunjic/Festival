using Microsoft.EntityFrameworkCore.Migrations;

namespace Festival.Data.Migrations
{
    public partial class SponsorStageCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stage_Sponsor_SponsorID",
                table: "Stage");

            migrationBuilder.AddForeignKey(
                name: "FK_Stage_Sponsor_SponsorID",
                table: "Stage",
                column: "SponsorID",
                principalTable: "Sponsor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stage_Sponsor_SponsorID",
                table: "Stage");

            migrationBuilder.AddForeignKey(
                name: "FK_Stage_Sponsor_SponsorID",
                table: "Stage",
                column: "SponsorID",
                principalTable: "Sponsor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
