using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastighetsProjectApi_CCRA.Migrations
{
    public partial class Raring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CounterRating",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalRatingSum",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Commentid",
                table: "RealEstates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                column: "UserName",
                value: "Börje@shietshow.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a999187c"),
                column: "UserName",
                value: "Börje@shietshow.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CounterRating",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TotalRatingSum",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Commentid",
                table: "RealEstates");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                column: "UserName",
                value: "Börje");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a999187c"),
                column: "UserName",
                value: "Börje");
        }
    }
}
