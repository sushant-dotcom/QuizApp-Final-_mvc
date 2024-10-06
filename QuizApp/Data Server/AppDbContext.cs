using Microsoft.EntityFrameworkCore;
using QuizApp.Models;

namespace QuizApp.Data_Server
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Question> Question { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>().HasData(
                 new Quiz { quiz_id = 1, Topic = "SQL" },
                 new Quiz { quiz_id = 2, Topic = "C#" },
                 new Quiz { quiz_id = 3, Topic = ".Net" }
                  );
        }
        public DbSet<Quiz> Quiz { get; set; }
    }
}
