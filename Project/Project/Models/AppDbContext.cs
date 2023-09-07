using Microsoft.EntityFrameworkCore;

namespace WebMiniProject.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Resume> Resumes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Corporation> Corporations { get; set; }
    }
}
