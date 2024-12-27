using MyPlants.Models;

namespace MyPlants.Interfaces
{
    public interface IWateringRepository
    {
        Task<Watering?> GetByIdAsync(int plantId, DateTime date);
        Task AddAsync(Watering watering);
        Task<bool> UpdateAsync(Watering watering);
        Task<bool> DeleteAsync(int plantId, DateTime date);
    }
}
