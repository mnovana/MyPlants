using MyPlants.Models;
using MyPlants.Models.DTOs;

namespace MyPlants.Interfaces
{
    public interface IPlantService
    {
        Task<IEnumerable<PlantDTO>> GetByUserAsync();
        Task<PlantDTO> GetByIdAsync(int id);
        Task<PlantDTO> AddAsync(Plant plant);
        Task<PlantDTO> UpdateAsync(Plant plant);
        Task DeleteAsync(int id);
    }
}
