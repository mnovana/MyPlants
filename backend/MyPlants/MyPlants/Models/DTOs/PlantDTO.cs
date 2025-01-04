
namespace MyPlants.Models.DTOs
{
    public class PlantDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WaterFrequency { get; set; }
        public string ImageName { get; set; }
        public string BackgroundColorHex { get; set; }

        public string UserId { get; set; }

        public ICollection<WateringDTO> Waterings { get; set; }
    }
}
