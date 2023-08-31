using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppDiary.Models
{
    public class DiaryClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int No { get; set; }

        public string Writer { get; set; }

        public string Title { get; set; }

        [Required]
        public string Contents { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;

    }
}
