using ExamsApi.Models;
using ExamsApi.Models.Auth;
using ExamsApi.Models.Questions;
using Microsoft.EntityFrameworkCore;
namespace ExamsApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ApplicationDbContext _context;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserSession> UserSessions { get; set; } = null!;
        public DbSet<AuditLog> AuditLogs { get; set; } = null!;
        public DbSet<PasswordReset> PasswordResets { get; set; } = null!;
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

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.PublicId)
                .IsUnique();

            modelBuilder.Entity<UserSession>()
                .HasOne(s => s.User)
                .WithMany(u => u.Sessions)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<AuditLog>()
                .HasOne(a => a.User)
                .WithMany(u => u.AuditLogs)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<PasswordReset>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

        }
    }
}
