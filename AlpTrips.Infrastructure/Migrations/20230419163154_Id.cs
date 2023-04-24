using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlpTrips.Infrastructure.Migrations
{
    public partial class Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Trips",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 18, 31, 54, 88, DateTimeKind.Local).AddTicks(3363));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 18, 31, 54, 88, DateTimeKind.Local).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 18, 31, 54, 88, DateTimeKind.Local).AddTicks(3444));

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CreatedById",
                table: "Trips",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_AspNetUsers_CreatedById",
                table: "Trips",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_AspNetUsers_CreatedById",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_CreatedById",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Trips");

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 15, 22, 2, 417, DateTimeKind.Local).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 15, 22, 2, 417, DateTimeKind.Local).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 15, 22, 2, 417, DateTimeKind.Local).AddTicks(2515));
        }
    }
}
