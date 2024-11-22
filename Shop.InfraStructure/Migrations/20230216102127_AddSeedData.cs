using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.InfraStructure.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          //  migrationBuilder.EnsureSchema("Amir");
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf47912e-e448-459e-a37d-e6be44e43dd8", "9c033c6e-59f8-4e56-ae61-ad56473c9df7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e5ec8521-791e-4d75-9e07-e848cdebe82a", "d8f3eb8d-bb13-43a0-bf64-47979b904e5e", "Support", "SUPPORT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf47912e-e448-459e-a37d-e6be44e43dd8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5ec8521-791e-4d75-9e07-e848cdebe82a");
        }
    }
}
