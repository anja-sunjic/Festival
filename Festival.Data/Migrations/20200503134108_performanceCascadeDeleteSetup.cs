using Microsoft.EntityFrameworkCore.Migrations;

namespace Festival.Data.Migrations
{
    public partial class performanceCascadeDeleteSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Performer_PerformerID",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Stage_StageID",
                table: "Performance");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Performer_PerformerID",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Stage_StageID",
                table: "Performance");

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
        }
    }
}
