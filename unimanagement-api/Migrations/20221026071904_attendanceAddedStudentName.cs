using Microsoft.EntityFrameworkCore.Migrations;

namespace unimanagement_api.Migrations
{
    public partial class attendanceAddedStudentName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Attendances");
        }
    }
}
