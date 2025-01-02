using MyPlants.Models;

namespace MyPlants.Interfaces
{
    public interface IPlantRepository
    {
        Task<IEnumerable<Plant>> GetByUserAsync(string userId);
        Task<Plant?> GetByIdAsync(int id);
        Task<bool> AddAsync(Plant plant);
        Task<bool> UpdateAsync(Plant plant);
        Task<bool> DeleteAsync(int id);
    }
}
