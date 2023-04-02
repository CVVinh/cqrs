using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cqrs_vhec.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoTypePro_DetailInfoTypePro",
                schema: "public",
                table: "DetailInformationTypeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Pro_DetailPro",
                schema: "public",
                table: "DetailInformationTypeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoPro_InfoTypePro",
                schema: "public",
                table: "InformationTypeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_TypePro_InfoTypePro",
                schema: "public",
                table: "InformationTypeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_TypePro_Pro",
                schema: "public",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Pro_ProImg",
                schema: "public",
                table: "ProductImg");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoTypePro_DetailInfoTypePro",
                schema: "public",
                table: "DetailInformationTypeProduct",
                column: "InformationTypeProductPgId",
                principalSchema: "public",
                principalTable: "InformationTypeProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pro_DetailPro",
                schema: "public",
                table: "DetailInformationTypeProduct",
                column: "ProductPgId",
                principalSchema: "public",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoPro_InfoTypePro",
                schema: "public",
                table: "InformationTypeProduct",
                column: "InformationProductPgId",
                principalSchema: "public",
                principalTable: "InformationProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypePro_InfoTypePro",
                schema: "public",
                table: "InformationTypeProduct",
                column: "TypeProductPgId",
                principalSchema: "public",
                principalTable: "TypeProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypePro_Pro",
                schema: "public",
                table: "Product",
                column: "TypeProductPgId",
                principalSchema: "public",
                principalTable: "TypeProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pro_ProImg",
                schema: "public",
                table: "ProductImg",
                column: "ProductPgId",
                principalSchema: "public",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoTypePro_DetailInfoTypePro",
                schema: "public",
                table: "DetailInformationTypeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Pro_DetailPro",
                schema: "public",
                table: "DetailInformationTypeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoPro_InfoTypePro",
                schema: "public",
                table: "InformationTypeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_TypePro_InfoTypePro",
                schema: "public",
                table: "InformationTypeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_TypePro_Pro",
                schema: "public",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Pro_ProImg",
                schema: "public",
                table: "ProductImg");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoTypePro_DetailInfoTypePro",
                schema: "public",
                table: "DetailInformationTypeProduct",
                column: "InformationTypeProductPgId",
                principalSchema: "public",
                principalTable: "InformationTypeProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pro_DetailPro",
                schema: "public",
                table: "DetailInformationTypeProduct",
                column: "ProductPgId",
                principalSchema: "public",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoPro_InfoTypePro",
                schema: "public",
                table: "InformationTypeProduct",
                column: "InformationProductPgId",
                principalSchema: "public",
                principalTable: "InformationProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypePro_InfoTypePro",
                schema: "public",
                table: "InformationTypeProduct",
                column: "TypeProductPgId",
                principalSchema: "public",
                principalTable: "TypeProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypePro_Pro",
                schema: "public",
                table: "Product",
                column: "TypeProductPgId",
                principalSchema: "public",
                principalTable: "TypeProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pro_ProImg",
                schema: "public",
                table: "ProductImg",
                column: "ProductPgId",
                principalSchema: "public",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
