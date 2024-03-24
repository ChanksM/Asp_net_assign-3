using Microsoft.EntityFrameworkCore;
 
namespace AspNetAssign.Models
{
    public class StudentsContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public StudentsContext(DbContextOptions<StudentsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}