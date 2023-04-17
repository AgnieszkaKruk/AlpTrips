using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlpTrips.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MountainRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Elevation = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { 1, "dziku@gmail.com", "Dziku" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { 2, "aga@w.pl", "Aga" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { 3, "tomake@w.pl", "Tomek" });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "CreatedDate", "Description", "Elevation", "EncodedName", "ImageUrl", "Length", "Level", "Link", "MountainRange", "Name", "Time", "UserId" },
                values: new object[] { 1, new DateTime(2023, 4, 17, 10, 44, 18, 121, DateTimeKind.Local).AddTicks(2165), "3 najwyższy sczyt Austrii", 0, null, null, 0, 2, "https://dzikumaniak.pl/2022/10/28/weiskugel/", "Alpy Ötztalskie", "Weisskugel 3739m npm", 0, 1 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "CreatedDate", "Description", "Elevation", "EncodedName", "ImageUrl", "Length", "Level", "Link", "MountainRange", "Name", "Time", "UserId" },
                values: new object[] { 2, new DateTime(2023, 4, 17, 10, 44, 18, 121, DateTimeKind.Local).AddTicks(2231), "Jeden z trudnijeszych szczytów w Alpach dla średniozaawansowanych", 0, null, null, 0, 4, "https://dzikumaniak.pl/2022/08/14/weisshorn-4505m-48h/", "Alpy Pennińskie", "Weisshorn 4505m npm", 7, 2 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "CreatedDate", "Description", "Elevation", "EncodedName", "ImageUrl", "Length", "Level", "Link", "MountainRange", "Name", "Time", "UserId" },
                values: new object[] { 3, new DateTime(2023, 4, 17, 10, 44, 18, 121, DateTimeKind.Local).AddTicks(2240), "Trawers przez Ostgrat", 0, null, null, 0, 2, "https://dzikumaniak.pl/2022/06/08/trawers-wildspitze/", "Alpy Ötztalskie", "Trawers Wildspitze 3768m npm", 0, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_UserId",
                table: "Trips",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
