using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastighetsProjectApi_CCRA.Migrations
{
    public partial class comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_RealEstates_RealEstateId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "RealEstateId",
                table: "Comments",
                newName: "RealEstateIde");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_RealEstateId",
                table: "Comments",
                newName: "IX_Comments_RealEstateIde");

            migrationBuilder.InsertData(
                table: "RealEstates",
                columns: new[] { "ide", "Address", "CanBeRented", "CanBeSold", "ConstructionYear", "Contact", "CreatedOn", "Description", "Id", "ImageUrl", "RealestateType", "RentingPrice", "SellingPrice", "Title", "Type", "UserName" },
                values: new object[,]
                {
                    { 1, "Hallalundavägen 12", false, true, 1710, "nils", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1998), "Lägenhetshus", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991780"), null, "Lägenhetshus", null, 120000, "titel1", 2, "Björn" },
                    { 2, "Hamburgarevägen 12", false, true, 1850, "maria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1996), "Lagerlokal", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991799"), null, "Lagerlokal", null, 2000000, "titel2", 3, "Nisse" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "AvatarImageUrl", "Comments", "Rating", "RealEstates", "UserId", "UserName" },
                values: new object[,]
                {
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), null, 1, 4.0, 2, "hejj", "Börje" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a999187c"), null, 2, 5.0, 3, "hallå", "Börje" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "id", "Content", "CreatedOn", "GuidID", "RealEstateIde", "UserName" },
                values: new object[] { 1, "Superbra", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1995), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991798"), 1, "Björn" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "id", "Content", "CreatedOn", "GuidID", "RealEstateIde", "UserName" },
                values: new object[] { 2, "Superbra men jättedåligt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1994), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991797"), 2, "Nisse" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_RealEstates_RealEstateIde",
                table: "Comments",
                column: "RealEstateIde",
                principalTable: "RealEstates",
                principalColumn: "ide",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_RealEstates_RealEstateIde",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a999187c"));

            migrationBuilder.DeleteData(
                table: "RealEstates",
                keyColumn: "ide",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RealEstates",
                keyColumn: "ide",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "RealEstateIde",
                table: "Comments",
                newName: "RealEstateId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_RealEstateIde",
                table: "Comments",
                newName: "IX_Comments_RealEstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_RealEstates_RealEstateId",
                table: "Comments",
                column: "RealEstateId",
                principalTable: "RealEstates",
                principalColumn: "ide",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
