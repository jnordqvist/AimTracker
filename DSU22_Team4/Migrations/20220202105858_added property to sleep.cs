using Microsoft.EntityFrameworkCore.Migrations;

namespace DSU22_Team4.Migrations
{
    public partial class addedpropertytosleep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Quality",
                table: "Sleep",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quality",
                table: "Sleep");
        }
    }
}
