
namespace MyPlants.Models.DTOs
{
    public class WateringDTO
    {
        public DateTime Date { get; set; }
        public int PlantId { get; set; }
        public bool Fertilized { get; set; }
    }
}
