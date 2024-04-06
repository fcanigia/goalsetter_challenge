using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalsetterChallenge.Infrastructure.Migrations
{
    public partial class AddRemovedFieldToClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 13, 15, 46, 13, 550, DateTimeKind.Local).AddTicks(9754), new DateTime(2024, 4, 6, 15, 46, 13, 550, DateTimeKind.Local).AddTicks(9749) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 13, 15, 46, 13, 550, DateTimeKind.Local).AddTicks(9758), new DateTime(2024, 4, 6, 15, 46, 13, 550, DateTimeKind.Local).AddTicks(9757) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 13, 15, 46, 13, 550, DateTimeKind.Local).AddTicks(9759), new DateTime(2024, 4, 6, 15, 46, 13, 550, DateTimeKind.Local).AddTicks(9759) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Clients");

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
    }
}
