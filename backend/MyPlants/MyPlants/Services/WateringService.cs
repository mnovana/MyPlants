using MyPlants.Interfaces;
using MyPlants.Models;
using MyPlants.CustomExceptions;

namespace MyPlants.Services
{
    public class WateringService : IWateringService
    {
        private readonly IWateringRepository _wateringRepository;
        private readonly IPlantRepository _plantRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public WateringService(IWateringRepository wateringRepository, IPlantRepository plantRepository, IHttpContextAccessor contextAccessor)
        {
            _wateringRepository = wateringRepository;
            _plantRepository = plantRepository;
            _contextAccessor = contextAccessor;
        }
        
        public async Task<Watering> AddAsync(Watering watering)
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst("user_id").Value;
            var plant = await _plantRepository.GetByIdAsync(watering.PlantId);

            if(plant == null)
            {
                throw new BadRequestException($"Invalid foreign key for plantID={watering.PlantId}.");
            }
            if (plant.UserId != userId)
            {
                throw new ForbiddenException("A user can water only his own plants.");
            }
            if(!await _wateringRepository.AddAsync(watering))
            {
                throw new Exception("Failed to add a new watering.");
            }

            return await _wateringRepository.GetByIdAsync(watering.PlantId, watering.Date);
        }

        public async Task DeleteAsync(int plantId, DateTime date)
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst("user_id").Value;
            var watering = await _wateringRepository.GetByIdAsync(plantId, date);

            if (watering == null)
            {
                throw new NotFoundException($"Watering with plantID={plantId} and date={date} was not found.");
            }
            else if (watering.Plant.UserId != userId)
            {
                throw new ForbiddenException("A user can delete only his own waterings.");
            }
            else if (!await _wateringRepository.DeleteAsync(plantId, date))
            {
                throw new Exception($"Failed to delete a watering with plantID={plantId} and date={date}.");
            }
        }
    }
}
