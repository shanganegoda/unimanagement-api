using Microsoft.EntityFrameworkCore.Migrations;

namespace unimanagement_api.Migrations
{
    public partial class updateStudentQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "StudentQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "StudentQuestions");
        }
    }
}
