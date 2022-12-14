namespace unimanagement_api.Entitites
{
    public class StudentQuestion
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public Question Question { get; set; }

    }
}
