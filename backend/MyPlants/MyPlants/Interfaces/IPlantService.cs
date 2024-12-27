using MyPlants.Models;

namespace MyPlants.Interfaces
{
    public interface IPlantService
    {
        Task<IEnumerable<Plant>> GetByUserAsync(string userId);
        Task<Plant?> GetByIdAsync(int id);
        Task<Plant?> AddAsync(Plant plant);
        Task<Plant?> UpdateAsync(Plant plant);
        Task<bool> DeleteAsync(int id);
    }
}
