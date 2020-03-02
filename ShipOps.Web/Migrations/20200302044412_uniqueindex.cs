using Microsoft.EntityFrameworkCore.Migrations;

namespace ShipOps.Web.Migrations
{
    public partial class uniqueindex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewImageEntity_News_NewId",
                table: "NewImageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewImageEntity",
                table: "NewImageEntity");

            migrationBuilder.RenameTable(
                name: "NewImageEntity",
                newName: "NewImages");

            migrationBuilder.RenameIndex(
                name: "IX_NewImageEntity_NewId",
                table: "NewImages",
                newName: "IX_NewImages_NewId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewImages",
                table: "NewImages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Voys_Voy_number",
                table: "Voys",
                column: "Voy_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VesselTypes_Type_Vessel",
                table: "VesselTypes",
                column: "Type_Vessel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Holds_Hold_Number",
                table: "Holds",
                column: "Hold_Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Name",
                table: "Companies",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NewImages_News_NewId",
                table: "NewImages",
                column: "NewId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewImages_News_NewId",
                table: "NewImages");

            migrationBuilder.DropIndex(
                name: "IX_Voys_Voy_number",
                table: "Voys");

            migrationBuilder.DropIndex(
                name: "IX_VesselTypes_Type_Vessel",
                table: "VesselTypes");

            migrationBuilder.DropIndex(
                name: "IX_Holds_Hold_Number",
                table: "Holds");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Name",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewImages",
                table: "NewImages");

            migrationBuilder.RenameTable(
                name: "NewImages",
                newName: "NewImageEntity");

            migrationBuilder.RenameIndex(
                name: "IX_NewImages_NewId",
                table: "NewImageEntity",
                newName: "IX_NewImageEntity_NewId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewImageEntity",
                table: "NewImageEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewImageEntity_News_NewId",
                table: "NewImageEntity",
                column: "NewId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
