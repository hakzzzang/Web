using System.ComponentModel.DataAnnotations;

namespace WebApp_Diary.Models
{
    public class Diary
    {
        [Key]
        public int No { get; set; }
        public DateTime Date { get; set; } = DateTime.Now.Date;
        [Required]
        public string Contents { get; set; }
        public string Writer { get; set; }
    }
}
