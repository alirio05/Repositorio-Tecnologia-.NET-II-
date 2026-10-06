using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.Persistence.Migrations
{
    public partial class BusinessTablesV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Business_Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Business_CustomerType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business_CustomerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Business_Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Business_Customer_Business_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Business_Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Business_Customer_Business_CustomerType_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "Business_CustomerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Business_CustomerContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business_CustomerContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Business_CustomerContact_Business_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Business_Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_Customer_CompanyId",
                table: "Business_Customer",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_Customer_CustomerTypeId",
                table: "Business_Customer",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_CustomerContact_CustomerId",
                table: "Business_CustomerContact",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Business_CustomerContact");

            migrationBuilder.DropTable(
                name: "Business_Customer");

            migrationBuilder.DropTable(
                name: "Business_Company");

            migrationBuilder.DropTable(
                name: "Business_CustomerType");
        }
    }
}
