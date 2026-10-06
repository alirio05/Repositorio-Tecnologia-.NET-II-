using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.Persistence.Migrations
{
    public partial class CompanyTableV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Business_CustomerType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "InternalId",
                table: "Business_CustomerType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Business_CustomerType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Business_Company",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "InternalId",
                table: "Business_Company",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Business_Company",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Business_CustomerType");

            migrationBuilder.DropColumn(
                name: "InternalId",
                table: "Business_CustomerType");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Business_CustomerType");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Business_Company");

            migrationBuilder.DropColumn(
                name: "InternalId",
                table: "Business_Company");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Business_Company");
        }
    }
}
