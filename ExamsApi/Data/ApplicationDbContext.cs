using ExamsApi.Models;
using ExamsApi.Models.Questions;
using Microsoft.EntityFrameworkCore;
namespace ExamsApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ApplicationDbContext _context;
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamModel> ExamModels { get; set; }
        public DbSet<HeadingQuestion> HeadingQuestions { get; set; }
        public DbSet<MainQuestion> MainQuestions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SingleChoice> SingleChoiceQuestions { get; set; }
        public DbSet<Paragraph> ParagraphQuestions { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure TPT mapping
            modelBuilder.Entity<SingleChoice>().ToTable("SingleChoices");
            modelBuilder.Entity<Paragraph>().ToTable("Paragraphs");
        }
    }
}
