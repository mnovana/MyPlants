using MyPlants.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace MyPlants.Models
{
    public class Plant
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [Range(1, 365)]
        public int WaterFrequency { get; set; }
        [Required]
        [StringLength(50)]
        public string ImageName { get; set; }
        [Required]
        [StringLength(7, MinimumLength = 7)]
        [HexColor]
        public string BackgroundColorHex { get; set; }

        [Required]
        public string UserId { get; set; }

        public ICollection<Watering> Waterings { get; set; }
    }
}
