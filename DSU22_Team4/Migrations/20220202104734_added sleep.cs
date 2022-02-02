using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DSU22_Team4.Migrations
{
    public partial class addedsleep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSession_WeatherCurrentDto_WeatherId",
                table: "TrainingSession");

            migrationBuilder.DropTable(
                name: "WeatherCurrentDto");

            migrationBuilder.DropIndex(
                name: "IX_TrainingSession_WeatherId",
                table: "TrainingSession");

            migrationBuilder.DropColumn(
                name: "WeatherId",
                table: "TrainingSession");

            migrationBuilder.CreateTable(
                name: "Sleep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SleepTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AwakeTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AthleteId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sleep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sleep_Athlete_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athlete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sleep_AthleteId",
                table: "Sleep",
                column: "AthleteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sleep");

            migrationBuilder.AddColumn<int>(
                name: "WeatherId",
                table: "TrainingSession",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WeatherCurrentDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Temp = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherCurrentDto", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSession_WeatherId",
                table: "TrainingSession",
                column: "WeatherId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSession_WeatherCurrentDto_WeatherId",
                table: "TrainingSession",
                column: "WeatherId",
                principalTable: "WeatherCurrentDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
