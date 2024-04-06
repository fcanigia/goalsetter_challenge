using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalsetterChallenge.Infrastructure.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "JohnDoe@gmail.com", "John", "Doe", "+54 9 11 3232 1212" },
                    { 2, "JuanDoe@gmail.com", "Juan", "Doe", "+54 9 11 3232 1213" },
                    { 3, "PeterEod@gmail.com", "Peter", "Eod", "+54 9 11 3232 1214" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "DailyPrice", "IsRemoved", "Model", "Type", "Year" },
                values: new object[,]
                {
                    { 1, "Volkswagen", 10.01, false, "Golf", "Car", 2023 },
                    { 2, "Volkswagen", 9.0, true, "Up", "Small Car", 2023 },
                    { 3, "Volkswagen", 15.0, false, "Nivus", "Small SUV", 2023 },
                    { 4, "Volkswagen", 11.0, false, "Virtus", "Car", 2023 },
                    { 5, "Volkswagen", 11.0, false, "Polo", "Car", 2023 },
                    { 6, "Volkswagen", 22.0, false, "Tiguan", "SUV", 2023 }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "ClientId", "EndDate", "StartDate", "VehicleId" },
                values: new object[] { 1, 1, new DateTime(2024, 4, 13, 14, 15, 3, 456, DateTimeKind.Local).AddTicks(8669), new DateTime(2024, 4, 6, 14, 15, 3, 456, DateTimeKind.Local).AddTicks(8660), 1 });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "ClientId", "EndDate", "StartDate", "VehicleId" },
                values: new object[] { 2, 2, new DateTime(2024, 4, 13, 14, 15, 3, 456, DateTimeKind.Local).AddTicks(8673), new DateTime(2024, 4, 6, 14, 15, 3, 456, DateTimeKind.Local).AddTicks(8673), 6 });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "ClientId", "EndDate", "StartDate", "VehicleId" },
                values: new object[] { 3, 3, new DateTime(2024, 4, 13, 14, 15, 3, 456, DateTimeKind.Local).AddTicks(8674), new DateTime(2024, 4, 6, 14, 15, 3, 456, DateTimeKind.Local).AddTicks(8674), 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
