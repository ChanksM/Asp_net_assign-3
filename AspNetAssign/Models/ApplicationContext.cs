using Microsoft.EntityFrameworkCore;
 
namespace AspNetAssign.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
