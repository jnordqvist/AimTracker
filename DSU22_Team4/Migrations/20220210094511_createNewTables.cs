using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DSU22_Team4.Migrations
{
    public partial class createNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShotDto");

            migrationBuilder.DropTable(
                name: "FiringCoordsDto");

            migrationBuilder.DropTable(
                name: "SerieDto");

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Shot",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "Shot",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingSessionId",
                table: "Serie",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shot_SerieId",
                table: "Shot",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_Serie_TrainingSessionId",
                table: "Serie",
                column: "TrainingSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Serie_TrainingSession_TrainingSessionId",
                table: "Serie",
                column: "TrainingSessionId",
                principalTable: "TrainingSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shot_Serie_SerieId",
                table: "Shot",
                column: "SerieId",
                principalTable: "Serie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serie_TrainingSession_TrainingSessionId",
                table: "Serie");

            migrationBuilder.DropForeignKey(
                name: "FK_Shot_Serie_SerieId",
                table: "Shot");

            migrationBuilder.DropIndex(
                name: "IX_Shot_SerieId",
                table: "Shot");

            migrationBuilder.DropIndex(
                name: "IX_Serie_TrainingSessionId",
                table: "Serie");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Shot");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "Shot");

            migrationBuilder.DropColumn(
                name: "TrainingSessionId",
                table: "Serie");

            migrationBuilder.CreateTable(
                name: "FiringCoordsDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    X = table.Column<double>(type: "double precision", nullable: false),
                    Y = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiringCoordsDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SerieDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Stance = table.Column<string>(type: "text", nullable: true),
                    TrainingSessionId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SerieDto_TrainingSession_TrainingSessionId",
                        column: x => x.TrainingSessionId,
                        principalTable: "TrainingSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShotDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FiringCoordsId = table.Column<int>(type: "integer", nullable: true),
                    HeartRate = table.Column<int>(type: "integer", nullable: false),
                    Result = table.Column<string>(type: "text", nullable: true),
                    SerieDtoId = table.Column<int>(type: "integer", nullable: true),
                    SerieId = table.Column<int>(type: "integer", nullable: true),
                    ShotNr = table.Column<int>(type: "integer", nullable: false),
                    TimeToFire = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShotDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShotDto_FiringCoordsDto_FiringCoordsId",
                        column: x => x.FiringCoordsId,
                        principalTable: "FiringCoordsDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShotDto_Serie_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Serie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShotDto_SerieDto_SerieDtoId",
                        column: x => x.SerieDtoId,
                        principalTable: "SerieDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SerieDto_TrainingSessionId",
                table: "SerieDto",
                column: "TrainingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ShotDto_FiringCoordsId",
                table: "ShotDto",
                column: "FiringCoordsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShotDto_SerieDtoId",
                table: "ShotDto",
                column: "SerieDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_ShotDto_SerieId",
                table: "ShotDto",
                column: "SerieId");
        }
    }
}
