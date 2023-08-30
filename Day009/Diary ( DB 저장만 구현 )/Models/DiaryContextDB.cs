using Microsoft.EntityFrameworkCore;

namespace WebApp_Diary.Models
{
    public class DiaryContextDB : DbContext
    {
        public DiaryContextDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Diary> Diarys { get; set; }
    }
}
