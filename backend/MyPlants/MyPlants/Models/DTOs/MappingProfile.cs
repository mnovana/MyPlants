using AutoMapper;

namespace MyPlants.Models.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Watering, WateringDTO>();
            CreateMap<Plant, PlantDTO>();
        }
    }
}
