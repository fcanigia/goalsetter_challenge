using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalsetterChallenge.Infrastructure.Migrations
{
    public partial class AddRemovedFieldToRental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Rentals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 13, 15, 42, 31, 851, DateTimeKind.Local).AddTicks(8055), new DateTime(2024, 4, 6, 15, 42, 31, 851, DateTimeKind.Local).AddTicks(8049) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 13, 15, 42, 31, 851, DateTimeKind.Local).AddTicks(8059), new DateTime(2024, 4, 6, 15, 42, 31, 851, DateTimeKind.Local).AddTicks(8059) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 13, 15, 42, 31, 851, DateTimeKind.Local).AddTicks(8060), new DateTime(2024, 4, 6, 15, 42, 31, 851, DateTimeKind.Local).AddTicks(8060) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Rentals");

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 13, 14, 15, 3, 456, DateTimeKind.Local).AddTicks(8669), new DateTime(2024, 4, 6, 14, 15, 3, 456, DateTimeKind.Local).AddTicks(8660) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 13, 14, 15, 3, 456, DateTimeKind.Local).AddTicks(8673), new DateTime(2024, 4, 6, 14, 15, 3, 456, DateTimeKind.Local).AddTicks(8673) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 13, 14, 15, 3, 456, DateTimeKind.Local).AddTicks(8674), new DateTime(2024, 4, 6, 14, 15, 3, 456, DateTimeKind.Local).AddTicks(8674) });
        }
    }
}
