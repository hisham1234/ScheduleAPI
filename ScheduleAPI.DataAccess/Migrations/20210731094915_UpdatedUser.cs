using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleAPI.DataAccess.Migrations
{
    public partial class UpdatedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 1, "123", "Hisham" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 2, "321", "Fary" });

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "Description", "EndDateTime", "StartDateTime", "Title", "UserId" },
                values: new object[] { 2, "watch tutorial", new DateTime(2021, 8, 3, 18, 49, 15, 73, DateTimeKind.Local).AddTicks(4573), new DateTime(2021, 7, 31, 18, 49, 15, 73, DateTimeKind.Local).AddTicks(4568), "Learning Angular", 1 });

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "Description", "EndDateTime", "StartDateTime", "Title", "UserId" },
                values: new object[] { 1, "Learning the newest Version", new DateTime(2021, 8, 3, 18, 49, 15, 73, DateTimeKind.Local).AddTicks(3744), new DateTime(2021, 7, 31, 18, 49, 15, 71, DateTimeKind.Local).AddTicks(4479), "Learning .Net Core", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_UserId",
                table: "Schedule",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
