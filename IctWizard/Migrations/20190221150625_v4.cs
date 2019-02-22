using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IctWizard.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierParts",
                table: "SupplierParts");

            migrationBuilder.DropIndex(
                name: "IX_SupplierParts_SupplierId",
                table: "SupplierParts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SupplierParts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierParts",
                table: "SupplierParts",
                columns: new[] { "SupplierId", "PartId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierParts",
                table: "SupplierParts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SupplierParts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierParts",
                table: "SupplierParts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierParts_SupplierId",
                table: "SupplierParts",
                column: "SupplierId");
        }
    }
}
