using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookMyHome.BlazorWebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class dataBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "CheckIn", "CheckOut" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 2);
        }
    }
}
