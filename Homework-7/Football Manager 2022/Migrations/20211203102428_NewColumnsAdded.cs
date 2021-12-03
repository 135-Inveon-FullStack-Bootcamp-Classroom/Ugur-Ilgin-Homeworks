using Microsoft.EntityFrameworkCore.Migrations;

namespace Football_Manager_2022.Migrations
{
    public partial class NewColumnsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tactics_Coaches_CoachId",
                table: "Tactics");

            migrationBuilder.DropIndex(
                name: "IX_Tactics_CoachId",
                table: "Tactics");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "Tactics");

            migrationBuilder.CreateTable(
                name: "CoachTactic",
                columns: table => new
                {
                    CoachesId = table.Column<int>(type: "int", nullable: false),
                    TacticsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachTactic", x => new { x.CoachesId, x.TacticsId });
                    table.ForeignKey(
                        name: "FK_CoachTactic_Coaches_CoachesId",
                        column: x => x.CoachesId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachTactic_Tactics_TacticsId",
                        column: x => x.TacticsId,
                        principalTable: "Tactics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoachTactic_TacticsId",
                table: "CoachTactic",
                column: "TacticsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachTactic");

            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "Tactics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tactics_CoachId",
                table: "Tactics",
                column: "CoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tactics_Coaches_CoachId",
                table: "Tactics",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
