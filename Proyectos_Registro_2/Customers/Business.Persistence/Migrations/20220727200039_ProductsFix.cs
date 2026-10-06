using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.Persistence.Migrations
{
    public partial class ProductsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "Business_Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Business_Product_Business_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Business_Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_Product_BrandId",
                table: "Business_Product",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Business_Product");

            migrationBuilder.RenameColumn(
                name: "WebSite",
                table: "Business_Customer",
                newName: "Email");
        }
    }
}
