using System.ComponentModel.DataAnnotations;

namespace MyPlants.Models
{
    public class Watering
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int PlantId { get; set; }
        [Required]
        public bool Fertilized { get; set; }

        public Plant? Plant { get; set; }
    }
}
