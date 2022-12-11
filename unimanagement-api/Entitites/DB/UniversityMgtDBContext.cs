using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using unimanagement_api.Entitites;

namespace unimanagement_api.Entities.DB
{
    public class UniversityMgtDBContext : DbContext
    {
        public UniversityMgtDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<GPASubject> GPASubjects { get; set; }
        public DbSet<StudentQuestion> StudentQuestions { get; set; }

    }
}
