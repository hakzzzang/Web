using System.ComponentModel.DataAnnotations;

namespace BasicCRUD1.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hp { get; set; }

    }
}
