using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Football_Manager_2022.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManagementPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    NationalTeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coaches_Teams_NationalTeamId",
                        column: x => x.NationalTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coaches_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Footballers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    NationalTeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footballers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Footballers_Teams_NationalTeamId",
                        column: x => x.NationalTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Footballers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagementPositionId = table.Column<int>(type: "int", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    NationalTeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_ManagementPositions_ManagementPositionId",
                        column: x => x.ManagementPositionId,
                        principalTable: "ManagementPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Managers_Teams_NationalTeamId",
                        column: x => x.NationalTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Managers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tactics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tactics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tactics_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FootballerPositions",
                columns: table => new
                {
                    FootballersId = table.Column<int>(type: "int", nullable: false),
                    PositionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballerPositions", x => new { x.FootballersId, x.PositionsId });
                    table.ForeignKey(
                        name: "FK_FootballerPositions_Footballers_FootballersId",
                        column: x => x.FootballersId,
                        principalTable: "Footballers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FootballerPositions_Positions_PositionsId",
                        column: x => x.PositionsId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_NationalTeamId",
                table: "Coaches",
                column: "NationalTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_TeamId",
                table: "Coaches",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballerPositions_PositionsId",
                table: "FootballerPositions",
                column: "PositionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Footballers_NationalTeamId",
                table: "Footballers",
                column: "NationalTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Footballers_TeamId",
                table: "Footballers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_ManagementPositionId",
                table: "Managers",
                column: "ManagementPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_NationalTeamId",
                table: "Managers",
                column: "NationalTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_TeamId",
                table: "Managers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Tactics_CoachId",
                table: "Tactics",
                column: "CoachId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FootballerPositions");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Tactics");

            migrationBuilder.DropTable(
                name: "Footballers");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "ManagementPositions");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
