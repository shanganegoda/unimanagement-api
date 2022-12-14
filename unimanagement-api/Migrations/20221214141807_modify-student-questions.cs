using Microsoft.EntityFrameworkCore.Migrations;

namespace unimanagement_api.Migrations
{
    public partial class modifystudentquestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "StudentQuestions");

            migrationBuilder.RenameColumn(
                name: "CorrectAnswer",
                table: "StudentQuestions",
                newName: "IsCorrectAnswer");

            migrationBuilder.AddColumn<string>(
                name: "AnswerText",
                table: "StudentQuestions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerText",
                table: "StudentQuestions");

            migrationBuilder.RenameColumn(
                name: "IsCorrectAnswer",
                table: "StudentQuestions",
                newName: "CorrectAnswer");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "StudentQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
