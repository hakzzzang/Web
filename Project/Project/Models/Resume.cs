using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMiniProject.Models
{
    public class Resume
    {
        public string CorporationName { get; set; }
        public string UserId { get; set; }
        public string OneLine { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int No { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Hp { get; set; }
        public string Education { get; set; }
        public string Certificate { get; set; }
        public string Cl { get; set; }
    }
}