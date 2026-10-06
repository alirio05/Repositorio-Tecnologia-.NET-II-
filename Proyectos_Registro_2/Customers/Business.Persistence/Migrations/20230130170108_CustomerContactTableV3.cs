using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.Persistence.Migrations
{
    public partial class CustomerContactTableV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Business_CustomerContact",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "InternalId",
                table: "Business_CustomerContact",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Business_CustomerContact",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Business_CustomerContact");

            migrationBuilder.DropColumn(
                name: "InternalId",
                table: "Business_CustomerContact");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Business_CustomerContact");
        }
    }
}
