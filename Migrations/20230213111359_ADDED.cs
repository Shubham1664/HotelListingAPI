using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class ADDED : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "56e0f689-9398-40e9-984f-31dfe71cd193", "99f75158-2c80-4cde-9665-d4425ffcd0a6", "user", "USER" },
                    { "e34bda5d-d119-4e34-8458-2cf552fa2ceb", "2715c890-1557-4080-b5fd-a15dceae2b97", "administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56e0f689-9398-40e9-984f-31dfe71cd193");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e34bda5d-d119-4e34-8458-2cf552fa2ceb");
        }
    }
}
