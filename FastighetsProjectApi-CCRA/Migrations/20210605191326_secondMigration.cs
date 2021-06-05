using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastighetsProjectApi_CCRA.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_RealEstates_RealEstateId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RealEstates",
                table: "RealEstates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Comments",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "ID",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "RealEstates",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "RealEstates",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealEstates",
                table: "RealEstates",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_RealEstates_RealEstateId",
                table: "Comments",
                column: "RealEstateId",
                principalTable: "RealEstates",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_RealEstates_RealEstateId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RealEstates",
                table: "RealEstates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "id",
                table: "RealEstates");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Comments",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RealEstates",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealEstates",
                table: "RealEstates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_RealEstates_RealEstateId",
                table: "Comments",
                column: "RealEstateId",
                principalTable: "RealEstates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
