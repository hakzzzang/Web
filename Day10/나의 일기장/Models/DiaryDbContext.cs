using Microsoft.EntityFrameworkCore;

namespace WebAppDiary.Models
{
    public class DiaryDbContext : DbContext
    {
        public DiaryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DiaryClass> DiaryList { get; set; }

    }
}
