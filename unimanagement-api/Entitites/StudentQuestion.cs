namespace unimanagement_api.Entitites
{
    public class StudentQuestion
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public bool CorrectAnswer { get; set; }
        public Question Question { get; set; }

    }
}
