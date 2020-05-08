using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Infrastructure.Migrations
{
    public partial class CMSv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_UserTypes_UserTypesId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserTypesId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserTypesId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "UserTypeID",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserTypeID",
                table: "Customers",
                column: "UserTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_UserTypes_UserTypeID",
                table: "Customers",
                column: "UserTypeID",
                principalTable: "UserTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_UserTypes_UserTypeID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserTypeID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserTypeID",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "UserTypesId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserTypesId",
                table: "Customers",
                column: "UserTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_UserTypes_UserTypesId",
                table: "Customers",
                column: "UserTypesId",
                principalTable: "UserTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
