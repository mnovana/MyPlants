using System.ComponentModel.DataAnnotations;

namespace MyPlants.Models
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
