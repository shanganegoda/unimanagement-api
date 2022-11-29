using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace unimanagement_api.Migrations
{
    public partial class attendanceDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Attendances",
                newName: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "Attendances",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
