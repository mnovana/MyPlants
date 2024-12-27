using MyPlants.Interfaces;
using MyPlants.Models;

namespace MyPlants.Services
{
    public class WateringService : IWateringService
    {
        private readonly IWateringRepository _wateringRepository;

        public WateringService(IWateringRepository wateringRepository)
        {
            _wateringRepository = wateringRepository;
        }
        
        public async Task<Watering?> AddAsync(Watering watering)
        {
            await _wateringRepository.AddAsync(watering);

            return await _wateringRepository.GetByIdAsync(watering.PlantId, watering.Date);
        }

        public async Task<bool> DeleteAsync(int plantId, DateTime date)
        {
            return await _wateringRepository.DeleteAsync(plantId, date);
        }

        public async Task<Watering?> GetByIdAync(int plantId, DateTime date)
        {
            return await _wateringRepository.GetByIdAsync(plantId, date);
        }

        public async Task<Watering?> UpdateAsync(Watering watering)
        {
            if(await _wateringRepository.UpdateAsync(watering))
            {
                return await _wateringRepository.GetByIdAsync(watering.PlantId, watering.Date);
            }

            return null;
        }
    }
}
