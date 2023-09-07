using System.ComponentModel.DataAnnotations;

namespace WebMiniProject.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string UserGender { get; set; }
        public string UserHp { get; set; }
    }

}
