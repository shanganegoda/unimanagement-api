using Microsoft.EntityFrameworkCore.Migrations;

namespace unimanagement_api.Migrations
{
    public partial class attendanceTimeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "time",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "time",
                table: "Attendances");
        }
    }
}
