using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace cqrs_vhec.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "InformationProduct",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeProduct",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformationTypeProduct",
                schema: "public",
                columns: table => new
                {
                    InformationProductPgId = table.Column<int>(type: "integer", nullable: false),
                    TypeProductPgId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationTypeProduct", x => new { x.InformationProductPgId, x.TypeProductPgId });
                    table.UniqueConstraint("AK_InformationTypeProduct_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoPro_InfoTypePro",
                        column: x => x.InformationProductPgId,
                        principalSchema: "public",
                        principalTable: "InformationProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypePro_InfoTypePro",
                        column: x => x.TypeProductPgId,
                        principalSchema: "public",
                        principalTable: "TypeProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    TypeProductPgId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypePro_Pro",
                        column: x => x.TypeProductPgId,
                        principalSchema: "public",
                        principalTable: "TypeProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailInformationTypeProduct",
                schema: "public",
                columns: table => new
                {
                    InformationTypeProductPgId = table.Column<int>(type: "integer", nullable: false),
                    ProductPgId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailInformationTypeProduct", x => new { x.InformationTypeProductPgId, x.ProductPgId });
                    table.ForeignKey(
                        name: "FK_InfoTypePro_DetailInfoTypePro",
                        column: x => x.InformationTypeProductPgId,
                        principalSchema: "public",
                        principalTable: "InformationTypeProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pro_DetailPro",
                        column: x => x.ProductPgId,
                        principalSchema: "public",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImg",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImgPath = table.Column<string>(type: "text", nullable: false),
                    ProductPgId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pro_ProImg",
                        column: x => x.ProductPgId,
                        principalSchema: "public",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailInformationTypeProduct_ProductPgId",
                schema: "public",
                table: "DetailInformationTypeProduct",
                column: "ProductPgId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationTypeProduct_TypeProductPgId",
                schema: "public",
                table: "InformationTypeProduct",
                column: "TypeProductPgId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TypeProductPgId",
                schema: "public",
                table: "Product",
                column: "TypeProductPgId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImg_ProductPgId",
                schema: "public",
                table: "ProductImg",
                column: "ProductPgId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailInformationTypeProduct",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ProductImg",
                schema: "public");

            migrationBuilder.DropTable(
                name: "InformationTypeProduct",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "public");

            migrationBuilder.DropTable(
                name: "InformationProduct",
                schema: "public");

            migrationBuilder.DropTable(
                name: "TypeProduct",
                schema: "public");
        }
    }
}
