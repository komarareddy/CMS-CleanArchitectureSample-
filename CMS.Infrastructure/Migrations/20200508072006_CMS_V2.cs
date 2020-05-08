using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Infrastructure.Migrations
{
    public partial class CMS_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "ID", "UserType" },
                values: new object[] { -1, "Admin" });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "ID", "UserType" },
                values: new object[] { -2, "BrachHead" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: -1);
        }
    }
}
