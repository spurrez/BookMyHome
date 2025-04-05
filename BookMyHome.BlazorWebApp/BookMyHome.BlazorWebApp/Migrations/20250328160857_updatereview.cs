using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyHome.BlazorWebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class updatereview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Guests_GuestId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_GuestId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Review");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Review_GuestId",
                table: "Review",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Guests_GuestId",
                table: "Review",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
