using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppLibrary
{
    public class TestAppContext : DbContext
    {
        public TestAppContext() : base("ConnectStr")
        { }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserQuestion> UserQuestions { get; set; }
        public DbSet<UserExams> UserExams { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
    }
}
