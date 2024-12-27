using MyPlants.Interfaces;
using MyPlants.Models;
using System.Runtime.CompilerServices;

namespace MyPlants.Services
{
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;

        public PlantService(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public async Task<Plant?> AddAsync(Plant plant)
        {
            await _plantRepository.AddAsync(plant);

            return await _plantRepository.GetByIdAsync(plant.Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _plantRepository.DeleteAsync(id);
        }

        public async Task<Plant?> GetByIdAsync(int id)
        {
            return await _plantRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Plant>> GetByUserAsync(string userId)
        {
            return await _plantRepository.GetByUserAsync(userId);
        }

        public async Task<Plant?> UpdateAsync(Plant plant)
        {
            if(await _plantRepository.UpdateAsync(plant))
            {
                return await _plantRepository.GetByIdAsync(plant.Id);
            }

            return null;
        }
    }
}
