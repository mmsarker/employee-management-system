using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmpoweID.EmployeeManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0d95f621-1167-4743-9a34-aeb4426a4833"), "IT Support" },
                    { new Guid("1dad7425-84e3-4dd1-b983-d05c5456c0d7"), "Admin" },
                    { new Guid("499943c6-f83c-4348-bd04-9babf6564d96"), "Software Development" },
                    { new Guid("990231a3-4842-481c-88b4-f71857c887ea"), "Production" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("0d95f621-1167-4743-9a34-aeb4426a4833"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("1dad7425-84e3-4dd1-b983-d05c5456c0d7"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("499943c6-f83c-4348-bd04-9babf6564d96"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("990231a3-4842-481c-88b4-f71857c887ea"));
        }
    }
}
