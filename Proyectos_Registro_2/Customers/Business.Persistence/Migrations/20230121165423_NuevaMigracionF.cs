using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.Persistence.Migrations
{
    public partial class NuevaMigracionF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Business_CustomerContact_Business_Customer_CustomerId",
                table: "Business_CustomerContact");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Business_CustomerContact",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Business_CustomerContact_Business_Customer_CustomerId",
                table: "Business_CustomerContact",
                column: "CustomerId",
                principalTable: "Business_Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Business_CustomerContact_Business_Customer_CustomerId",
                table: "Business_CustomerContact");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Business_CustomerContact",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Business_CustomerContact_Business_Customer_CustomerId",
                table: "Business_CustomerContact",
                column: "CustomerId",
                principalTable: "Business_Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
