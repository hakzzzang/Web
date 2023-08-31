using Microsoft.EntityFrameworkCore;

namespace BasicCRUD1.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
    }
}
