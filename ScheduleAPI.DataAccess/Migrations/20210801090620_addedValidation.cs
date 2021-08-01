using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleAPI.DataAccess.Migrations
{
    public partial class addedValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2021, 8, 4, 18, 6, 19, 857, DateTimeKind.Local).AddTicks(9138), new DateTime(2021, 8, 1, 18, 6, 19, 855, DateTimeKind.Local).AddTicks(8448) });

            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2021, 8, 4, 18, 6, 19, 858, DateTimeKind.Local).AddTicks(14), new DateTime(2021, 8, 1, 18, 6, 19, 858, DateTimeKind.Local).AddTicks(9) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2021, 8, 3, 18, 49, 15, 73, DateTimeKind.Local).AddTicks(3744), new DateTime(2021, 7, 31, 18, 49, 15, 71, DateTimeKind.Local).AddTicks(4479) });

            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2021, 8, 3, 18, 49, 15, 73, DateTimeKind.Local).AddTicks(4573), new DateTime(2021, 7, 31, 18, 49, 15, 73, DateTimeKind.Local).AddTicks(4568) });
        }
    }
}
