using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace National_Bank_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Code", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Helwan, Cairo", "Helwan Branch", "0225551111" },
                    { 2, "Nasr City, Cairo", "Nasr City Branch", "0225552222" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "BranchCode", "Email", "FullName", "HireDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "ahmed@bank.com", "Ahmed Mohamed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01000000001" },
                    { 2, 2, "mona@bank.com", "Mona Ali", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01000000002" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: 2);
        }
    }
}
