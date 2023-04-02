using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cqrs_vhec.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailInformationTypeProduct",
                schema: "public",
                table: "DetailInformationTypeProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailInformationTypeProduct",
                schema: "public",
                table: "DetailInformationTypeProduct",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DetailInformationTypeProduct_InformationTypeProductPgId",
                schema: "public",
                table: "DetailInformationTypeProduct",
                column: "InformationTypeProductPgId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailInformationTypeProduct",
                schema: "public",
                table: "DetailInformationTypeProduct");

            migrationBuilder.DropIndex(
                name: "IX_DetailInformationTypeProduct_InformationTypeProductPgId",
                schema: "public",
                table: "DetailInformationTypeProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailInformationTypeProduct",
                schema: "public",
                table: "DetailInformationTypeProduct",
                columns: new[] { "InformationTypeProductPgId", "ProductPgId", "Id" });
        }
    }
}
