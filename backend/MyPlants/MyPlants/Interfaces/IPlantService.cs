using MyPlants.Models;

namespace MyPlants.Interfaces
{
    public interface IPlantService
    {
        Task<IEnumerable<Plant>> GetByUserAsync();
        Task<Plant> GetByIdAsync(int id);
        Task<Plant> AddAsync(Plant plant);
        Task<Plant> UpdateAsync(Plant plant);
        Task DeleteAsync(int id);
    }
}
