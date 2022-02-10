using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DSU22_Team4.Migrations
{
    public partial class createdGeometryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "Geometry");

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Geometry",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lon",
                table: "Geometry",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Geometry");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "Geometry");

            migrationBuilder.AddColumn<List<double>>(
                name: "Coordinates",
                table: "Geometry",
                type: "double precision[]",
                nullable: true);
        }
    }
}
