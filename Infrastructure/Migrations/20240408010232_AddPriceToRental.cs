using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalsetterChallenge.Infrastructure.Migrations
{
    public partial class AddPriceToRental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Rentals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Price", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 22, 2, 32, 535, DateTimeKind.Local).AddTicks(5727), 70.069999999999993, new DateTime(2024, 4, 7, 22, 2, 32, 535, DateTimeKind.Local).AddTicks(5720) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "Price", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 22, 2, 32, 535, DateTimeKind.Local).AddTicks(5731), 154.0, new DateTime(2024, 4, 7, 22, 2, 32, 535, DateTimeKind.Local).AddTicks(5730) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "Price", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 22, 2, 32, 535, DateTimeKind.Local).AddTicks(5732), 105.0, new DateTime(2024, 4, 7, 22, 2, 32, 535, DateTimeKind.Local).AddTicks(5732) });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "ClientId", "EndDate", "IsRemoved", "Price", "StartDate", "VehicleId" },
                values: new object[,]
                {
                    { 4, 1, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 100.09999999999999, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, 2, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 220.0, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 6, 3, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 150.0, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, 1, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 60.060000000000002, new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, 2, new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 176.0, new DateTime(2024, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 9, 3, new DateTime(2024, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 105.0, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Rentals");

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
    }
}
