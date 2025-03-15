using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyHome.BlazorWebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class hostNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodations_Hosts_HostId",
                table: "Accommodations");

            migrationBuilder.AlterColumn<int>(
                name: "HostId",
                table: "Accommodations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodations_Hosts_HostId",
                table: "Accommodations",
                column: "HostId",
                principalTable: "Hosts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodations_Hosts_HostId",
                table: "Accommodations");

            migrationBuilder.AlterColumn<int>(
                name: "HostId",
                table: "Accommodations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodations_Hosts_HostId",
                table: "Accommodations",
                column: "HostId",
                principalTable: "Hosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
