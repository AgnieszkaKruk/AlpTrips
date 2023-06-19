﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlpTrips.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class getRidofTuple : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Trips");
        }
    }
}
