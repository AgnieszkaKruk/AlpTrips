using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlpTrips.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Trips_TripId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "TripId1",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_TripId1",
                table: "Events",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Trips_TripId",
                table: "Events",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Trips_TripId1",
                table: "Events",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Trips_TripId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Trips_TripId1",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_TripId1",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TripId1",
                table: "Events");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Trips_TripId",
                table: "Events",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
