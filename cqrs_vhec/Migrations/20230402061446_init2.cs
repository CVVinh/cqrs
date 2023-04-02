using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cqrs_vhec.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InformationTypeProduct",
                schema: "public",
                table: "InformationTypeProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailInformationTypeProduct",
                schema: "public",
                table: "DetailInformationTypeProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InformationTypeProduct",
                schema: "public",
                table: "InformationTypeProduct",
                columns: new[] { "InformationProductPgId", "TypeProductPgId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailInformationTypeProduct",
                schema: "public",
                table: "DetailInformationTypeProduct",
                columns: new[] { "InformationTypeProductPgId", "ProductPgId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InformationTypeProduct",
                schema: "public",
                table: "InformationTypeProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailInformationTypeProduct",
                schema: "public",
                table: "DetailInformationTypeProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InformationTypeProduct",
                schema: "public",
                table: "InformationTypeProduct",
                columns: new[] { "InformationProductPgId", "TypeProductPgId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailInformationTypeProduct",
                schema: "public",
                table: "DetailInformationTypeProduct",
                columns: new[] { "InformationTypeProductPgId", "ProductPgId" });
        }
    }
}
