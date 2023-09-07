using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMiniProject.Models
{
    public class Corporation
    {
        [Key]
        public int No { get; set; }
        [Required]
        public string CorporationName { get; set; }
        [Required]
        public string Line { get; set; }
    }
}
