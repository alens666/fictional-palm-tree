using Microsoft.EntityFrameworkCore.Migrations;

namespace IctWizard.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartName",
                table: "Parts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PartName",
                table: "Parts",
                nullable: false,
                defaultValue: "");
        }
    }
}
